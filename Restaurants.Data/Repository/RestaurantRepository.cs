using Restaurants.Domain.Interfaces;
using Restaurants.Domain.Models;
using Restaurants.Data.Context;

namespace Restaurants.Data.Repository
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(RestautantContext context)
            : base(context)
        {
            
        }
    }
}