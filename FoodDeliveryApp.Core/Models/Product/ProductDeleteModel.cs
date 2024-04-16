namespace FoodDeliveryApp.Core.Models.Product
{
	public class ProductDeleteModel
	{
		public int Id { get; set; }

		public string Title { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public decimal Price { get; set; }

		public bool IsVeggie { get; set; }

		public string ItemCategory { get; set; } = string.Empty;

		public string Restaurant { get; set; } = string.Empty;

		public string SpicyCategory { get; set; } = string.Empty;
	}
}