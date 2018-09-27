using System;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.AutoMapper;

namespace Restaurants.Api.Configurations {
    public static class AutoMapperSetup {
        public static void AddAutoMapperSetup (this IServiceCollection services) {

            if (services == null)
                throw new ArgumentNullException (nameof (services));

            services.AddAutoMapper();

            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project
            AutoMapperConfig.RegisterMappings ();
        }
    }
}