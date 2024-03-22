using FoodDeliveryApp.Core.Models.Item;

namespace FoodDeliveryApp.Core.Models.Restaurant
{
	public class RestaurantDetailViewModel
	{
		public RestaurantViewModel Restaurant { get; set; } = new RestaurantViewModel();

		public IEnumerable<ItemViewModel> Items { get; set; } = new List<ItemViewModel>();
	}
}