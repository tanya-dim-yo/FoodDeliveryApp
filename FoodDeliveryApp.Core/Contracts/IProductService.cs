using FoodDeliveryApp.Core.Models.Product;

namespace FoodDeliveryApp.Core.Contracts
{
	public interface IProductService
	{
		Task<ProductViewModel?> GetProductByIdAsync(int id);
	}
}