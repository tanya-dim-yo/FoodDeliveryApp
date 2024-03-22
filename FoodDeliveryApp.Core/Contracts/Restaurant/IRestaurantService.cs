using FoodDeliveryApp.Core.Models.Item;
using FoodDeliveryApp.Core.Models.Restaurant;

namespace FoodDeliveryApp.Core.Contracts.Restaurant
{
	public interface IRestaurantService
	{
		Task AddAsync(RestaurantDetailViewModel model);
		Task EditAsync(RestaurantDetailViewModel model);
		Task<IEnumerable<RestaurantViewModel>> GetAllAsync();
		Task<IEnumerable<RestaurantViewModel>> GetByCategoryAsync(int categoryId);
        Task<IEnumerable<RestaurantViewModel>> SearchAsync(string keyword);
        Task<IEnumerable<RestaurantViewModel>> HighestRatingAsync();
		Task<IEnumerable<RestaurantViewModel>> ServiceFeeAsync();
		Task<IEnumerable<ItemViewModel>> MenuAsync(int restaurantId);
		Task<RestaurantViewModel?> GetByIdAsync(int id);
		Task RateRestaurant(int restaurantId, double newRating);
	}
}