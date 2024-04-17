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

			await repository.SaveChangesAsync();
		}

		public async Task<decimal> CalculateServiceFeeAsync(int cartId)
		{
			decimal serviceFeeTotalPrice = 0;

			var cartItems = await repository.AllReadOnly<CartItem>()
				.Where(ci => ci.CartId == cartId)
				.ToListAsync();

			foreach (var cartItem in cartItems)
			{
				serviceFeeTotalPrice += cartItem.Item.Restaurant.ServiceFee;
			}

			return serviceFeeTotalPrice;
		}

		public async Task<decimal> CalculateItemsTotalPriceAsync(int cartId)
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

		public async Task RemoveAddOnFromCartAsync(int addOnId, int cartId)
		{
			if (await ExistsCartAsync(cartId) == false)
			{
				throw new InvalidOperationException("Количката не е намерена.");
			}

			var itemAddon = await repository.All<ItemAddOn>()
				.FirstOrDefaultAsync(ia => ia.AddOnId == addOnId);

			if (itemAddon == null)
			{
				throw new InvalidOperationException("Добавката не е намерена в количката.");
			}

			await repository.DeleteAsync<ItemAddOn>(itemAddon.AddOnId);
			await repository.SaveChangesAsync();
		}

		public async Task RemoveItemFromCartAsync(int itemId, int cartId)
		{
			var cartItem = await repository.All<CartItem>()
				.FirstOrDefaultAsync(ci => ci.ItemId == itemId && ci.CartId == cartId);

			if (cartItem == null)
			{
				throw new InvalidOperationException("Несъществуващ продукт!");
			}

			await repository.DeleteAsync<CartItem>(cartItem.Id);
			await repository.SaveChangesAsync();
		}

		public async Task<decimal> CalculateTotalPriceAsync(int cartId)
		{
			return await CalculateItemsTotalPriceAsync(cartId) + await CalculateServiceFeeAsync(cartId);
		}

		public async Task<decimal> UpdateCartItemQuantityAsync(int cartItemId, int quantity)
		{
			var cartItem = await repository.GetByIdAsync<CartItem>(cartItemId);

			if (cartItem == null)
			{
				throw new InvalidOperationException("Продуктът не е намерен.");
			}

			cartItem.Quantity = quantity;

			await repository.SaveChangesAsync();

			return cartItem.Item.Price * cartItem.Quantity;
		}
	}
}