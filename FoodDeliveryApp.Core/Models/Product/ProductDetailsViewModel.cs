namespace FoodDeliveryApp.Core.Models.Product
{
	public class ProductDetailsViewModel
	{
		public int Id { get; set; }

		public string Title { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public decimal Price { get; set; }

		public bool IsVeggie { get; set; }

		public string ImageURL { get; set; } = string.Empty;

		public string ItemCategory { get; set; } = string.Empty;

		public int RestaurantId { get; set; }

		public string Restaurant { get; set; } = string.Empty;

		public int MinDeliveryTimeInMinutes { get; set; }

		public int MaxDeliveryTimeInMinutes { get; set; }

		public string SpicyCategory { get; set; } = string.Empty;
	}
}