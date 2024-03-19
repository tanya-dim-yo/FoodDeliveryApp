using FoodDeliveryApp.Core.Models.Restaurant;

namespace FoodDeliveryApp.Core.Contracts.Restaurant
{
	public interface IRestaurantService
	{
		Task AddAsync(RestaurantDetailViewModel model);
		Task EditAsync(RestaurantDetailViewModel model);
		Task<IEnumerable<RestaurantViewModel>> GetAllAsync();
		Task<IEnumerable<RestaurantViewModel>> GetByCategoryAsync();
		Task<IEnumerable<RestaurantViewModel>> HighestRatingAsync();
		Task<IEnumerable<RestaurantViewModel>> ServiceFeeAsync();
		Task<RestaurantDetailViewModel?> GetByIdAsync(int id);
		Task RateRestaurant(int restaurantId, double newRating);
	}
}