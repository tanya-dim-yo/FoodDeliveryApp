using FoodDeliveryApp.Core.Models.Product;
using FoodDeliveryApp.Infrastructure.Data.Models;

namespace FoodDeliveryApp.Core.Contracts
{
	public interface IProductService
	{
		Task<int> AddProductAsync(ProductFormModel model, int restaurantId);
		Task<IEnumerable<ProductCategoryViewModel>> GetCategoriesAsync();
		Task<IEnumerable<ProductSpicyCategoryViewModel>> GetSpicyCategoriesAsync();
		Task<bool> ExistsProductAsync(int productId);
		Task<bool> ExistsProductCategoryAsync(int productCategoryId);
		Task<bool> ExistsProductSpicyCategoryAsync(int productSpicyCategoryId);
		Task EditProductAsync(int productId, ProductFormModel model);
		Task DeleteProductAsync(int productId);
		Task<ProductDetailsViewModel?> GetProductDetailsByIdAsync(int productId);
		Task<Item?> GetProductByIdAsync(int productId);
		Task UpdateFavouriteProductAsync(int productId);
	}
}