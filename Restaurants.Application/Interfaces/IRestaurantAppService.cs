using System;
using System.Collections.Generic;
using Restaurants.Application.ViewModels;

namespace Restaurants.Application.Interfaces
{
    public interface IRestaurantAppService : IDisposable
    {
        RestaurantViewModel Insert(RestaurantViewModel restaurantViewModel);
        IEnumerable<RestaurantViewModel> GetAll();
        RestaurantViewModel GetById(Guid id);
        RestaurantViewModel Update(RestaurantViewModel restaurantViewModel);
        void Remove(Guid id);
        IEnumerable<MealViewModel> GetAllMeals(Guid id);
    }
}