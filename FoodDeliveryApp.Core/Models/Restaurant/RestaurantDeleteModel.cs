using Microsoft.VisualBasic;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.RestaurantValidationConstants;

namespace FoodDeliveryApp.Core.Models.Restaurant
{
	public class RestaurantDeleteModel
	{
		public RestaurantDeleteModel(
		   int id,
		   string title,
		   string address,
		   string city,
		   DateTime openingHour,
		   DateTime closingHour,
		   decimal serviceFee,
		   string restaurantCategory)
		{
			Id = id;
			Title = title;
			Address = address;
			City = city;
			OpeningHour = openingHour.ToString(DateTimeFormat);
			ClosingHour = closingHour.ToString(DateTimeFormat);
			ServiceFee = serviceFee;
			RestaurantCategory = restaurantCategory;
		}

		public int Id { get; set; }

		public string Title { get; set; } = string.Empty;

		public string Address { get; set; } = string.Empty;

		public string City { get; set; }

		public string OpeningHour { get; set; } = string.Empty;

		public string ClosingHour { get; set; } = string.Empty;

		public decimal ServiceFee { get; set; }

		public string RestaurantCategory { get; set; } = string.Empty;
	}
}