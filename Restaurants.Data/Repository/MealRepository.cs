using System;
using System.Linq;
using System.Collections.Generic;
using Restaurants.Domain.Interfaces;
using Restaurants.Domain.Models;
using Restaurants.Data.Context;

namespace Restaurants.Data.Repository
{
    public class MealRepository : Repository<Meal>, IMealRepository
    {
        public MealRepository(RestautantContext context)
            : base(context)
        {
            
        }

        public IQueryable<Meal> GetAllMeals(Guid restaurantId)
        {
            return DbSet.Where(x => x.RestaurantId == restaurantId);
        }
    }
}