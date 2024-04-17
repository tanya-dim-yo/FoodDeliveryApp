﻿using FoodDeliveryApp.Core.Models.ShoppingCart;

namespace FoodDeliveryApp.Core.Contracts
{
	public interface IShoppingCartService
	{
		Task<bool> ExistsCartAsync(int cartId);
		Task AddItemToCartAsync(int itemId, int quantity, int cartId);
		Task AddAddOnToCartAsync(int addOnId, int quantity, int cartId);
		Task RemoveItemFromCartAsync(int itemId, int quantity, int cartId);
		Task RemoveAddOnFromCartAsync(int addOnId, int quantity, int cartId);
		Task<IEnumerable<RecommendedItemViewModel>> GetRecommendedItemsAsync();
		Task CalculateServiceFeeAsync(int cartId);
		Task<decimal> CalculateTotalPriceAsync(int cartId);
	}
}