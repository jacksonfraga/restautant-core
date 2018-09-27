using Restaurants.Domain.Interfaces;
using Restaurants.Domain.Models;
using Restaurants.Data.Repository;
using Restaurants.Data.Context;
using Restaurants.Application.Interfaces;
using Restaurants.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace Restaurants.Infra.Crosscutting.IoC {
    public class NativeInjectorBootStrapper {
        public static void RegisterServices (IServiceCollection services) 
        { 
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IRestaurantAppService, RestaurantAppService>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();

            services.AddScoped<IMealAppService, MealAppService>();
            services.AddScoped<IMealRepository, MealRepository>();

            services.AddScoped<RestautantContext>();
        }
    }
}