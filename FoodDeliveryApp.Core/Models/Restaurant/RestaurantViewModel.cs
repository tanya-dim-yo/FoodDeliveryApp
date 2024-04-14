namespace FoodDeliveryApp.Core.Models.Restaurant
{
	public class RestaurantViewModel
    {
		public int Id { get; set; }

		public string Title { get; set; } = string.Empty;

		public decimal ServiceFee { get; set; }

		public int MinDeliveryTimeInMinutes { get; set; }

		public int MaxDeliveryTimeInMinutes { get; set; }

		public string ImageURL { get; set; } = string.Empty;

		public string RestaurantCategory { get; set; } = string.Empty;
	}
}