using FoodDeliveryApp.Core.Models.City;
using FoodDeliveryApp.Core.Models.Product;
using FoodDeliveryApp.Core.Models.Restaurant;

namespace FoodDeliveryApp.Core.Contracts
{
    public interface IRestaurantService
    {
		Task<int> AddRestaurantAsync(RestaurantFormModel model, DateTime openHour, DateTime closeHour);
		Task<IEnumerable<RestaurantReservationViewModel>> GetRestaurantsAsync();
		Task EditRestaurantAsync(int restaurantId, RestaurantFormModel model);
		Task DeleteRestaurantAsync(int restaurantId);
		Task<RestaurantFormModel?> GetRestaurantFormModelByIdAsync(int restaurantId);
		Task<RestaurantDeleteModel?> GetRestaurantDeleteModelByIdAsync(int restaurantId);
		Task<IEnumerable<CityServiceModel>> AllRestaurantCitiesAsync();
		Task<(IEnumerable<RestaurantViewModel> Restaurants, IEnumerable<(int Id, string Title)> Categories)> GetAllRestaurantsAndCategoriesAsync();
		Task<IEnumerable<string>> AllRestaurantCategoriesNamesAsync();
		Task<IEnumerable<RestaurantViewModel>> GetAllRestaurantsAsync();
		Task<IEnumerable<RestaurantViewModel>> GetRestaurantsByCategoryAsync(int categoryId);
		Task<RestaurantViewModel?> GetRestaurantByIdAsync(int id);
		Task<IEnumerable<RestaurantViewModel>> RestaurantsByServiceFeeAsync();
		Task<IEnumerable<ProductViewModel>> MenuRestaurantAsync(int restaurantId);
		Task<(string SanitizedKeyword, IEnumerable<RestaurantViewModel> Results)> SearchRestaurantsAsync(string keyword);
		Task<bool> ExistsRestaurantAsync(int id);
		Task<bool> ExistsRestaurantCategoryAsync(int categoryId);
		Task<bool> ExistsCityAsync(int cityId);
	}
}