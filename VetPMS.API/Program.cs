using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Net.Mail;
using System.Net;
using System.Text;
using VetPMS.API;
using VetPMS.Application.ConfigurationService;
using VetPMS.Application.Exceptions;
using VetPMS.Infrastructure.ConfigurationService;
using VetPMS.Infrastructure.Data;
using VetPMS.Infrastructure.Email;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using VetPMS.Infrastructure.SMS;
using VetPMS.API.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
     .WriteTo.File($"logs/log-{DateTime.Now:yyyyMMdd_HHmmss}.txt", rollingInterval: RollingInterval.Infinite)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddControllers();
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ClinicIdActionFilter>(); 
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
  
// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;

    var secret = builder.Configuration["JWT:Secret"] ?? throw new KeyNotFoundException("JWT Secret not found");
    var validIssuer = builder.Configuration["JWT:ValidIssuer"] ?? throw new KeyNotFoundException("ValidIssuer not found");
    var validAudience = builder.Configuration["JWT:ValidAudience"] ?? throw new KeyNotFoundException("ValidAudience not found");

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = validAudience,
        ValidIssuer = validIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
        ValidateIssuerSigningKey = true
    };
});


builder.Services.AddAuthorization();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "VetPMS", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
           Array.Empty<string>()
        }
    });
});

builder.Services.Configure<APISetting>(builder.Configuration.GetSection("APISetting"));

var apiSetting = builder.Configuration.GetSection("APISetting").Get<APISetting>();
if (apiSetting == null || string.IsNullOrEmpty(apiSetting.URL))
{
    throw new InvalidOperationException("APISetting or URL is not configured properly.");
}
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", policyBuilder =>
    {
        policyBuilder.WithOrigins(apiSetting.URL)
                     .AllowAnyHeader()
                     .AllowAnyMethod();
    });
});

var emailOptions = builder.Configuration.GetSection("EmailOptions").Get<EmailOptions>()??throw new KeyNotFoundException();

// Register FluentEmail
builder.Services.AddFluentEmail(emailOptions.FromEmail, emailOptions.FromName)
    .AddRazorRenderer()  // Optional, if you are using Razor templates
    .AddSmtpSender(new SmtpClient(emailOptions.SmtpServer)
    {
        Port = emailOptions.SmtpPort,
        Credentials = new NetworkCredential(emailOptions.SmtpUsername, emailOptions.SmtpPassword),
        EnableSsl = emailOptions.EnableSsl
    });

builder.Services.AddSingleton<SmsService>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    return new SmsService(
        configuration["Twilio:AccountSid"]!,
        configuration["Twilio:AuthToken"]!,
        configuration["Twilio:FromNumber"]!);
});

var app = builder.Build();

app.MapDefaultEndpoints();

using var scope = app.Services.CreateScope();
var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
await SeedRolesAsync(roleManager);

static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
{
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    if (!await roleManager.RoleExistsAsync("Clinic"))
    {
        await roleManager.CreateAsync(new IdentityRole("Clinic"));
    }
}


app.UseCors("MyPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
await app.RunAsync();
