using HomeKitchen.Api.Common.Errors;
using HomeKitchen.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace HomeKitchen.Api
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, HomeKitchenProblemDetailsFactory>();
            services.AddMappings();
            return services;
        }
    }
}
