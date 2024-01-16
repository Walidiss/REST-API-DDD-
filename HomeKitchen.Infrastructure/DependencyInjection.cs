using HomeKitchen.Application.Abstractions;
using HomeKitchen.Application.Common.Interfaces.Authentication;
using HomeKitchen.Application.Persistence;
using HomeKitchen.Application.Services.Authentication;
using HomeKitchen.Infrastructure.Authentication;
using HomeKitchen.Infrastructure.Persistence;
using HomeKitchen.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeKitchen.Infrastructure
{
    public static class DependencyInjection
    {
       public static IServiceCollection AddInfrastructure(this IServiceCollection services,ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IAuthenticationService,AuthenticationService>();
            services.AddScoped<IJwTokenGenerator,JwTokenGenerator>();
            services.AddScoped<IUserRepository,UserRepository>();
            return services;
        }
    }
}
