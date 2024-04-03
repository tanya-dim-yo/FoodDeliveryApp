using FoodDeliveryApp.Core.Models.Product;

namespace FoodDeliveryApp.Core.Models.Restaurant
{
	public class RestaurantDetailViewModel
	{
		public RestaurantViewModel Restaurant { get; set; } = new RestaurantViewModel();

		public IEnumerable<ProductViewModel> Items { get; set; } = new List<ProductViewModel>();
	}
}