using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VetPMS.Infrastructure.Data;
using VetPMS.Infrastructure.Email;

namespace VetPMS.Infrastructure.ConfigurationService
{
    public static class ConfigurationService
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConStr"));
            });

            services.AddScoped<EmailService>();
            return services;
        }
    }
}
