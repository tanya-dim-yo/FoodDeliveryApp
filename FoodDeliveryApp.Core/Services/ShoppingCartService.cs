using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Infrastructure.Data.Common;
using FoodDeliveryApp.Infrastructure.Data.Models;

namespace FoodDeliveryApp.Core.Services
{
	public class ShoppingCartService : IShoppingCartService
	{
		private readonly IRepository repository;
		private readonly IProductService productService;

		public ShoppingCartService(
			IRepository _repository,
			IProductService _productService)
		{
			repository = _repository;
			productService = _productService;
		}

		public async Task AddProductToCartAsync(int productId, int quantity)
		{
			var product = await productService.GetProductByIdAsync(productId);

			if (product == null)
			{
				throw new ArgumentException("Product not found.");
			}



			await repository.SaveChangesAsync();
		}

		public Task<decimal> CalculateTotalPriceAsync()
		{
			throw new NotImplementedException();
		}

		public Task RemoveProductFromCartAsync(int productId)
		{
			throw new NotImplementedException();
		}
	}
}