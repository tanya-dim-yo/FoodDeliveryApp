using FoodDeliveryApp.Core.Models.Item;
using FoodDeliveryApp.Core.Models.Restaurant;

namespace FoodDeliveryApp.Core.Contracts
{
    public interface IRestaurantService
    {
		Task<int> AddRestaurantAsync(RestaurantFormModel model, DateTime openHour, DateTime closeHour);
        Task EditRestaurantAsync(RestaurantDetailViewModel model);
        Task DeleteRestaurantAsync(RestaurantDetailViewModel model);
        Task<bool> ExistsRestaurantAsync(int id);
        Task<bool> ExistsRestaurantCategoryAsync(int categoryId);
		Task<bool> ExistsCityAsync(int cityId);
		Task<IEnumerable<RestaurantCategoryModel>> AllRestaurantCategoriesAsync();
        Task<IEnumerable<RestaurantViewModel>> GetRestaurantsByCategoryAsync(int categoryId);
        Task<IEnumerable<string>> AllRestaurantCategoriesNamesAsync();
        Task<IEnumerable<RestaurantViewModel>> GetAllRestaurantsAsync();
        Task<(string SanitizedKeyword, IEnumerable<RestaurantViewModel> Results)> SearchRestaurantsAsync(string keyword);
        Task<IEnumerable<RestaurantViewModel>> HighestRatingRestaurantsAsync();
        Task<IEnumerable<RestaurantViewModel>> RestaurantsByServiceFeeAsync();
        Task<IEnumerable<ItemViewModel>> MenuRestaurantAsync(int restaurantId);
        Task<RestaurantViewModel?> GetRestaurantByIdAsync(int id);
        Task RateRestaurant(int restaurantId, double newRating);
    }
}