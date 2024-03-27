using FoodDeliveryApp.Core.Models.Item;
using FoodDeliveryApp.Core.Models.Restaurant;

namespace FoodDeliveryApp.Core.Contracts.Restaurant
{
	public interface IRestaurantService
	{
		Task AddRestaurantAsync(RestaurantDetailViewModel model);
		Task EditRestaurantAsync(RestaurantDetailViewModel model);
		Task DeleteRestaurantAsync(RestaurantDetailViewModel model);
		Task<IEnumerable<RestaurantViewModel>> GetAllRestaurantsAsync();
		Task<IEnumerable<RestaurantViewModel>> GetRestaurantsByCategoryAsync(int categoryId);
        Task<IEnumerable<RestaurantViewModel>> SearchRestaurantsAsync(string keyword);
        Task<IEnumerable<RestaurantViewModel>> HighestRatingRestaurantsAsync();
		Task<IEnumerable<RestaurantViewModel>> RestaurantsByServiceFeeAsync();
		Task<IEnumerable<ItemViewModel>> MenuAsync(int restaurantId);
		Task<RestaurantViewModel?> GetRestaurantByIdAsync(int id);
		Task RateRestaurant(int restaurantId, double newRating);
	}
}