using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using System.IdentityModel.Tokens.Jwt;
using VetPMS;
using VetPMS.AuthConfiguration;
using VetPMS.Constants;
using VetPMS.ExceptionHandling;
using VetPMS.Services;
using VetPMS.Services.Authentication;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiSettings = builder.Configuration.GetSection("ApiSettings").Get<ApiSettings>() ?? throw new KeyNotFoundException();
builder.Services.AddSingleton(apiSettings);

// ErrorHandlingMessageHandler configuration
builder.Services.AddTransient<ErrorHandlingMessageHandler>(sp =>
{
    var logger = sp.GetRequiredService<ILogger<ErrorHandlingMessageHandler>>();
    return new ErrorHandlingMessageHandler(logger);
});

builder.Services.AddTransient<AuthorizationMessageHandler>(sp =>
{
    var localStorage = sp.GetRequiredService<ILocalStorageService>();
    return new AuthorizationMessageHandler(localStorage);
});

// HttpClient configuration for authenticated requests
builder.Services.AddHttpClient(_HttpClient.Client, client =>
{
    client.BaseAddress = new Uri(apiSettings.BaseUrl!);
})
.AddHttpMessageHandler<AuthorizationMessageHandler>()
.AddHttpMessageHandler<ErrorHandlingMessageHandler>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();
builder.Services.AddRadzenComponents();
builder.Services.AddScoped<OwnerService>();
builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<BreedService>();
builder.Services.AddScoped<RegisterService>();
builder.Services.AddScoped<ResetPasswordService>();
builder.Services.AddScoped<SetNewPasswordService>();
builder.Services.AddScoped<MedicineService>();
builder.Services.AddScoped<AppointmentService>();
builder.Services.AddScoped<ClinicService>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddScoped<JwtSecurityTokenHandler>();
builder.Services.AddScoped<ApiAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(p =>
                p.GetRequiredService<ApiAuthenticationStateProvider>());

builder.Services.AddAuthorizationCore();
await builder.Build().RunAsync();
