using System.ComponentModel.DataAnnotations;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.CityValidationConstants;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
	public class City
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(CityNameMaxLength)]
		public string Name { get; set; } = string.Empty;

		public virtual IEnumerable<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
	}
}