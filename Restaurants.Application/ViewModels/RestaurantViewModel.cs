using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurants.Application.ViewModels
{
    public class RestaurantViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }
    }
}