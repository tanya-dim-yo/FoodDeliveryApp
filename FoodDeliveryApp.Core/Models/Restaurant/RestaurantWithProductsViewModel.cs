using FoodDeliveryApp.Core.Models.Product;

namespace FoodDeliveryApp.Core.Models.Restaurant
{
	public class RestaurantWithProductsViewModel
	{
		public RestaurantViewModel Restaurant { get; set; } = new RestaurantViewModel();

		public IEnumerable<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
	}
}