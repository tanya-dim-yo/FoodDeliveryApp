namespace FoodDeliveryApp.Core.Models.Restaurant
{
	public class RestaurantWithCategoriesViewModel
	{
		public IEnumerable<string> CategoryNames { get; set; } = new List<string>();
		public IEnumerable<int> CategoryIds { get; set; } = new List<int>();
		public IEnumerable<RestaurantViewModel> RestaurantViewModels { get; set; } = new List<RestaurantViewModel>();
	}
}