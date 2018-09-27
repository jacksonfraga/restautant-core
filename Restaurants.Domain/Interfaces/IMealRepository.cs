using System;
using System.Collections.Generic;
using System.Linq;
using Restaurants.Domain.Models;

namespace Restaurants.Domain.Interfaces
{
    public interface IMealRepository : IRepository<Meal>
    {         
        IQueryable<Meal> GetAllMeals(Guid restaurantId);
    }
}