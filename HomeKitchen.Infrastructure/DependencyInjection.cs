﻿using HomeKitchen.Application.Abstractions;
using HomeKitchen.Application.Common.Interfaces.Authentication;
using HomeKitchen.Application.Persistence;
using HomeKitchen.Infrastructure.Authentication;
using HomeKitchen.Infrastructure.Persistence;
using HomeKitchen.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HomeKitchen.Infrastructure
{
    public static class DependencyInjection
    {
       public static IServiceCollection AddInfrastructure(this IServiceCollection services,ConfigurationManager configuration)
        {
            services
            .AddAuth(configuration)
            .AddPersistance();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            return services;
        }
        //public static IServiceCollection AddAuth(
        //    this IServiceCollection services, 
        //    IConfiguration configuration)
        //{
        //    var jwtSettings = new JwtSettings();
        //    configuration.Bind(JwtSettings.SectionName, jwtSettings);

        //    services.AddSingleton(Options.Create(jwtSettings));
        //    services.AddScoped<IJwTokenGenerator, JwTokenGenerator>();

        //    //the authentication handler it validate the token and the user identity 
        //    services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
        //        .AddJwtBearer(options =>options.TokenValidationParameters = new TokenValidationParameters
        //        {
        //          ValidateIssuer = true,
        //          ValidateAudience = true,
        //          ValidateLifetime = true,
        //          ValidateIssuerSigningKey = true,
        //          ValidIssuer = jwtSettings.Issuer,
        //          ValidAudience = jwtSettings.Audience,
        //          IssuerSigningKey = new SymmetricSecurityKey(
        //               Encoding.UTF8.GetBytes(jwtSettings.Secret))
        //    });

        //    return services;

        //}


        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;

        }
        public static IServiceCollection AddAuth(
        this IServiceCollection services,
        IConfiguration configration)
        {
            var jwtSettings = new JwtSettings();
            configration.Bind(JwtSettings.SectionName, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));
             //services.AddScoped<IJwTokenGenerator, JwTokenGenerator>();
            services.AddSingleton<IJwTokenGenerator, JwTokenGenerator>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret))
                });

            return services;
        }
    }
}
