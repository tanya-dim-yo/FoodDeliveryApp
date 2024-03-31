namespace FoodDeliveryApp.Core.Models.Item
{
	public class ItemViewModel
    {
		public int Id { get; set; }

		public string Title { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public decimal Price { get; set; }

		public double AverageRating { get; set; }

		public int TotalReviews { get; set; }

		public string Image { get; set; } = string.Empty;

		public string ItemCategory { get; set; } = string.Empty;

		public double AverageRatingPercent => (AverageRating / 5) * 100;
	}
}