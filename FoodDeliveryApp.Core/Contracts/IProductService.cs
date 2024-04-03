using FoodDeliveryApp.Core.Models.Product;

namespace FoodDeliveryApp.Core.Contracts
{
	public interface IProductService
	{
		Task<ProductDetailsViewModel?> GetProductByIdAsync(int productId);
	}
}