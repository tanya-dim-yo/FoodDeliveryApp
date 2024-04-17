using FoodDeliveryApp.Infrastructure.Data.Models;

namespace FoodDeliveryApp.Core.Models.ShoppingCart
{
	public class ShoppingCartViewModel
	{
		public int Id { get; set; }

		public string UserId { get; set; } = string.Empty;

		public decimal ItemsTotalPrice { get; set; }

		public decimal ServiceFee { get; set; }

		public decimal TotalPrice { get; set; }

		public virtual IEnumerable<CartItemViewModel> CartItems { get; set; } = new List<CartItemViewModel>();

		//public virtual IEnumerable<RecommendedItemViewModel> RecommendedItems { get; set; } = new List<RecommendedItemViewModel>();
	}
}