using FoodDeliveryApp.Core.Models.Product;
using FoodDeliveryApp.Core.Models.Restaurant;
using FoodDeliveryApp.Infrastructure.Data.Models;

namespace FoodDeliveryApp.Core.Contracts
{
	public interface IProductService
	{
		Task<int> AddProductAsync(ProductFormModel model, int restaurantId);
		Task<IEnumerable<ProductCategoryViewModel>> GetCategories();
		Task<IEnumerable<ProductSpicyCategoryViewModel>> GetSpicyCategories();
		Task EditProductAsync(int productId, ProductFormModel model);
		Task DeleteProductAsync(int productId);
		Task<ProductDetailsViewModel?> GetProductDetailsByIdAsync(int productId);
		Task<Item?> GetProductByIdAsync(int productId);
		Task UpdateFavouriteProduct(int productId);
	}
}