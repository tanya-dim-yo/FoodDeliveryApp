namespace FoodDeliveryApp.Core.Models.Restaurant
{
	public class RestaurantsWithCategoriesViewModel
	{
		public int RestaurantsPerPage { get; } = 9;
		public int CurrentPage { get; init; } = 1;
		public int TotalRestaurantsCount { get; set; }
		public IEnumerable<string> CategoryNames { get; set; } = new List<string>();
		public IEnumerable<int> CategoryIds { get; set; } = new List<int>();
		public IEnumerable<RestaurantViewModel> RestaurantViewModels { get; set; } = new List<RestaurantViewModel>();
	}
}