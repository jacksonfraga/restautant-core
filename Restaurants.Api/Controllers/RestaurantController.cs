using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Interfaces;
using Restaurants.Application.ViewModels;

namespace Restaurants.Api.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase {
        private readonly IRestaurantAppService _restaurantAppService;

        public RestaurantController (IRestaurantAppService restaurantAppService) : base () {
            _restaurantAppService = restaurantAppService;
        }

        [HttpGet]
        public IEnumerable<RestaurantViewModel> GetAll () {
            return _restaurantAppService.GetAll ();
        }

        [HttpGet ("{id}")]
        public ActionResult<RestaurantViewModel> GetById (Guid id) {
            return _restaurantAppService.GetById (id);
        }

        [HttpPost]
        public RestaurantViewModel Post ([FromBody] RestaurantViewModel value) {
            return _restaurantAppService.Insert (value);
        }

        [HttpPut ("{id}")]
        public ActionResult<RestaurantViewModel> Put (Guid id, [FromBody] RestaurantViewModel value) {
            if (id != value.Id) {
                return BadRequest ();
            } else {
                return _restaurantAppService.Update (value);
            }
        }

        [HttpDelete ("{id}")]
        public void Delete (Guid id) {
            _restaurantAppService.Remove (id);
        }

        [HttpGet("{id}/meals")]
        public IEnumerable<MealViewModel> GetMeals(Guid id)
        {
            // List<MealViewModel> lista = new List<MealViewModel>();
            // lista.Add(new MealViewModel() {
            //     RestaurantId = id
            // });
            //return lista;
            return _restaurantAppService.GetAllMeals(id);
        }
    }
}