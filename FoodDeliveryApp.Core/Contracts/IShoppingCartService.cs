using FoodDeliveryApp.Core.Models.ShoppingCart;

namespace FoodDeliveryApp.Core.Contracts
{
	public interface IShoppingCartService
	{
		Task<int> CreateCartAsync(string userId);
		Task<bool> ExistsCartAsync(int cartId);
		Task AddItemToCartAsync(int itemId, int quantity, int cartId, string userId);
		Task AddAddOnToCartAsync(int itemId, int addOnId, int quantity, int cartId);
		Task RemoveItemFromCartAsync(int itemId, int cartId);
		Task RemoveAddOnFromCartAsync(int addOnId, int quantity, int cartId);
		Task<IEnumerable<RecommendedItemViewModel>> GetRecommendedItemsAsync();
		Task CalculateServiceFeeAsync(int cartId);
		Task<decimal> CalculateTotalPriceAsync(int cartId);
	}
}