using FoodDeliveryApp.Core.Models.ShoppingCart;

namespace FoodDeliveryApp.Core.Contracts
{
	public interface IShoppingCartService
	{
		Task<int> CreateCartAsync(string userId);
		Task<bool> ExistsCartAsync(int cartId);
		Task AddItemToCartAsync(int itemId, int quantity, string userId);
		Task AddAddOnToCartAsync(int itemId, int addOnId, int quantity, int cartId);
		Task RemoveItemFromCartAsync(int itemId, int cartId);
		Task RemoveAddOnFromCartAsync(int addOnId, int cardId);
		Task<ShoppingCartViewModel> GetShopCartByIdAsync(int cartId);
		Task<decimal> UpdateCartItemQuantityAsync(int cartItemId, int quantity);
		Task<IEnumerable<RecommendedItemViewModel>> GetRecommendedItemsAsync();
		Task<decimal> CalculateServiceFeeAsync(int cartId);
		Task<decimal> CalculateItemsTotalPriceAsync(int cartId);
		Task<decimal> CalculateTotalPriceAsync(int cartId);
	}
}