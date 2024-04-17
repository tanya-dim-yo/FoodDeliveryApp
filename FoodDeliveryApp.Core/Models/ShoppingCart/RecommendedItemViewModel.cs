namespace FoodDeliveryApp.Core.Models.ShoppingCart
{
	public class RecommendedItemViewModel
	{
		public int Id { get; set; }

		public string Title { get; set; } = string.Empty;

		public decimal Price { get; set; }

		public string ImageURL { get; set; } = string.Empty;

		public int RestaurantId { get; set; }

		public string Restaurant { get; set; } = string.Empty;
	}
}
