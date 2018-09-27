using System;
using Restaurants.Domain.Core.Models;

namespace Restaurants.Domain.Models 
{
    public class Meal : Entity 
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Guid RestaurantId { get; set; }
    }
}