using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Core.Models.ShoppingCart;
using FoodDeliveryApp.Infrastructure.Data.Common;
using FoodDeliveryApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FoodDeliveryApp.Core.Services
{
	public class ShoppingCartService : IShoppingCartService
	{
		private readonly IRepository repository;
		private readonly ILogger<ShoppingCartService> logger;

		public ShoppingCartService(
			IRepository _repository,
			ILogger<ShoppingCartService> _logger)
		{
			repository = _repository;
			logger = _logger;
		}

		public async Task AddAddOnToCartAsync(int itemId, int addOnId, int quantity, int cartId)
		{
			var cartItem = await repository.AllReadOnly<CartItem>()
						.FirstOrDefaultAsync(ci => ci.ItemId == itemId && ci.CartId == cartId);

			if (cartItem == null)
			{
				this.logger.LogError($"Продуктът не е добавен към количката.");
				return;
			}

			var itemAddon = new ItemAddOn
			{ 
				ItemId = itemId,
				AddOnId = addOnId 
			};

			await repository.AddAsync(itemAddon);
			await repository.SaveChangesAsync();
		}

		public async Task AddItemToCartAsync(int itemId, int quantity, int cartId)
		{
			var cartItem = await repository.AllReadOnly<CartItem>()
							.FirstOrDefaultAsync(ci => ci.ItemId == itemId && ci.CartId == cartId);

			if (cartItem == null)
			{
				cartItem = new CartItem(itemId, quantity, 0);
				cartItem.CartId = cartId;
				await repository.AddAsync(cartItem);
			}
			else
			{
				cartItem.Quantity += quantity;
			}

			await repository.SaveChangesAsync();
		}

		public Task CalculateServiceFeeAsync(int cartId)
		{
			throw new NotImplementedException();
		}

		public Task<decimal> CalculateTotalPriceAsync(int cartId)
		{
			throw new NotImplementedException();
		}

		public async Task<int> CreateCartAsync(string userId)
		{
			if (string.IsNullOrEmpty(userId))
			{
				throw new ArgumentNullException(nameof(userId));
			}

			var cart = new Cart()
			{
				UserId = userId
			};

			await repository.AddAsync(cart);
			await repository.SaveChangesAsync();

			return cart.Id;
		}

		public Task<bool> ExistsCartAsync(int cartId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<RecommendedItemViewModel>> GetRecommendedItemsAsync()
		{
			throw new NotImplementedException();
		}

		public Task RemoveAddOnFromCartAsync(int addOnId, int quantity, int cartId)
		{
			throw new NotImplementedException();
		}

		public Task RemoveItemFromCartAsync(int itemId, int quantity, int cartId)
		{
			throw new NotImplementedException();
		}
	}
}