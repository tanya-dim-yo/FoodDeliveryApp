namespace FoodDeliveryApp.Core.Models.Restaurant
{
	public class RestaurantViewModel
    {
		public int Id { get; set; }

		public string Title { get; set; } = string.Empty;

		public decimal ServiceFee { get; set; }

		public string DeliveryTime { get; set; } = string.Empty;

		public string BackgroundImage { get; set; } = string.Empty;

		public double AverageRating { get; set; }

		public int TotalReviews { get; set; }

		public string RestaurantCategory { get; set; } = string.Empty;

		public double AverageRatingPercent => (AverageRating / 5) * 100;
	}
}