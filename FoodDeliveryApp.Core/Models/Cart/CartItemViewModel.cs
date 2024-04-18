namespace FoodDeliveryApp.Core.Models.Cart
{
	public class CartItemViewModel
	{
		public int Id { get; set; }

		public string Title { get; set; } = string.Empty;

		public string ImageURL { get; set; } = string.Empty;

		public int Quantity { get; set; }

		public decimal Price { get; set; }
	}
}