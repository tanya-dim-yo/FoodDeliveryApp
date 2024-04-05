using FoodDeliveryApp.Core.Models.Product;
using FoodDeliveryApp.Infrastructure.Data.Models;

namespace FoodDeliveryApp.Core.Contracts
{
	public interface IProductService
	{
		Task<ProductDetailsViewModel?> GetProductDetailsByIdAsync(int productId);
		Task<Item?> GetProductByIdAsync(int productId);
		Task UpdateFavouriteProduct(int productId);
	}
}