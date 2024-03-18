using FoodDeliveryApp.Core.Models.Restaurant;

namespace FoodDeliveryApp.Core.Contracts.Restaurant
{
	public interface IRestaurantService
	{
		Task AddAsync(RestaurantDetailViewModel model);
		Task EditAsync(RestaurantDetailViewModel model);
		Task<IEnumerable<RestaurantViewModel>> GetAllAsync();
		Task<RestaurantDetailViewModel?> GetByIdAsync(int id);
	}
}