using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurants.Application.ViewModels
{
    public class MealViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Price is Required")]
        [DisplayName("Price")]
        public double Price { get; set; }
        

        [Required(ErrorMessage = "The Restaurant is Required")]
        [DisplayName("Restaurant")]
        public Guid RestaurantId { get; set; }
    }
}