using System;
using AutoMapper;
using Restaurants.Application.ViewModels;
using Restaurants.Domain.Models;

namespace Restaurants.Application.AutoMapper {
    public class AutoMapperConfig {
        public static void RegisterMappings () {
            Mapper.Initialize ((config) => {
                config.CreateMap<Restaurant, RestaurantViewModel> ().ReverseMap ();
                config.CreateMap<Meal, MealViewModel> ().ReverseMap ();
            });

        }
    }
}