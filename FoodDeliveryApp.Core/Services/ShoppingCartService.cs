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

		public async Task AddItemToCartAsync(int itemId, int quantity, int cartId, string userId)
		{
			if (!await ExistsCartAsync(cartId))
			{
				cartId = await CreateCartAsync(userId);
			}

			var cartItem = await repository.AllReadOnly<CartItem>()
				.FirstOrDefaultAsync(ci => ci.ItemId == itemId && ci.CartId == cartId);

			if (cartItem == null)
			{
				cartItem = new CartItem(itemId, quantity);
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

		public async Task<decimal> CalculateTotalPriceAsync(int cartId)
		{
			var cartItems = await repository.AllReadOnly<CartItem>()
							.Where(ci => ci.CartId == cartId)
							.ToListAsync();

			decimal totalPrice = 0;

			foreach (var cartItem in cartItems)
			{
				totalPrice += cartItem.Quantity * cartItem.Item.Price;
			}

			return totalPrice;
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

		public async Task<bool> ExistsCartAsync(int cartId)
		{
			return await repository
				.AllReadOnly<Cart>().AnyAsync(c => c.Id == cartId);
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