namespace FoodDeliveryApp.Core.Models.Restaurant
{
    public class RestaurantsWithCategoriesViewModel
    {
        public int RestaurantsPerPage { get; } = 2;
        public int CurrentPage { get; set; }
        public int TotalRestaurantsCount { get; set; }
        public IEnumerable<string> CategoryNames { get; set; } = new List<string>();
        public IEnumerable<int> CategoryIds { get; set; } = new List<int>();
        public IEnumerable<RestaurantViewModel> RestaurantViewModels { get; set; } = new List<RestaurantViewModel>();
    }

}