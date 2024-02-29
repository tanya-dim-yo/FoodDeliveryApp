using System.ComponentModel.DataAnnotations;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.RestaurantCategoryValidationConstants;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class RestaurantCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(RestaurantCategoryNameMaxLength)]
        public string Title { get; set; } = string.Empty;

        public virtual IEnumerable<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
}