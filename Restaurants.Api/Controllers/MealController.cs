using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Interfaces;
using Restaurants.Application.ViewModels;

namespace Restaurants.Api.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMealAppService _mealAppService;

        public MealController(IMealAppService mealAppService) : base ()
        {
            _mealAppService = mealAppService;
        }

        [HttpGet]
        public IEnumerable<MealViewModel> GetAll()
        {
            return _mealAppService.GetAll();
        }

        [HttpGet ("{id}")]
        public ActionResult<MealViewModel> GetById (Guid id) {
            return _mealAppService.GetById (id);
        }

        [HttpPost]
        public MealViewModel Post ([FromBody] MealViewModel value) {
            return _mealAppService.Insert (value);
        }

        [HttpPut ("{id}")]
        public ActionResult<MealViewModel> Put (Guid id, [FromBody] MealViewModel value) {
            if (id != value.Id) {
                return BadRequest ();
            } else {
                return _mealAppService.Update(value);
            }
        }

        [HttpDelete ("{id}")]
        public void Delete (Guid id) {
            _mealAppService.Remove(id);
        }
    }
}