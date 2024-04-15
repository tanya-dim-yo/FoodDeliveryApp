namespace FoodDeliveryApp.Core.Contracts
{
	public interface IShoppingCartService
	{
		Task AddProductToCartAsync(int productId, int quantity);
		Task RemoveProductFromCartAsync(int productId);
		Task<decimal> CalculateTotalPriceAsync();
	}
}