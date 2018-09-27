using System;
using System.Collections.Generic;
using Restaurants.Application.ViewModels;

namespace Restaurants.Application.Interfaces
{
    public interface IMealAppService : IDisposable
    {
        MealViewModel Insert(MealViewModel mealViewModel);
        IEnumerable<MealViewModel> GetAll();
        MealViewModel GetById(Guid id);
        MealViewModel Update(MealViewModel mealViewModel);
        void Remove(Guid id);
    }
}