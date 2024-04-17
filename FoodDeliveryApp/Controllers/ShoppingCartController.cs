using FoodDeliveryApp.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FoodDeliveryApp.Controllers
{
	public class ShoppingCartController : BaseController
	{
		private readonly IShoppingCartService shoppingCartService;

		public ShoppingCartController(IShoppingCartService _shoppingCartService)
		{
			shoppingCartService = _shoppingCartService;
		}

		[HttpPost]
		public async Task<IActionResult> AddItemToCart(int itemId, int quantity, int cartId)
		{
			try
			{
				var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

				if (string.IsNullOrEmpty(userId))
				{
					return Unauthorized();
				}

				await shoppingCartService.AddItemToCartAsync(itemId, quantity, cartId, userId);

				return Ok("Продуктът е добавен успешно към количката!");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Възникна грешка: {ex.Message}");
			}
		}

		[HttpPost]
		public async Task<IActionResult> AddAddOnToCart(int itemId, int addOnId, int quantity, int cartId)
		{
			try
			{
				await shoppingCartService.AddAddOnToCartAsync(itemId, addOnId, quantity, cartId);
				return Ok("Добавката беше добавена успешно към количката!");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Възникна грешка: {ex.Message}");
			}
		}

		[HttpGet]
		public async Task<IActionResult> RemoveItemFromCart(int itemId, int cartId)
		{
			try
			{
				await shoppingCartService.RemoveItemFromCartAsync(itemId, cartId);
				return Ok("Продуктът е премахнат успешно от количката!");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Възникна грешка: {ex.Message}");
			}
		}

		[HttpGet]
		public async Task<IActionResult> RemoveAddOnFromCart(int addOnId, int cartId)
		{
			try
			{
				await shoppingCartService.RemoveAddOnFromCartAsync(addOnId, cartId);
				return Ok("Добавката е премахната успешно от количката!");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Възникна грешка: {ex.Message}");
			}
		}

		[HttpGet]
		public async Task<IActionResult> CalculateItemsTotalPrice(int cartId)
		{
			try
			{
				var itemsTotalPrice = await shoppingCartService.CalculateItemsTotalPriceAsync(cartId);
				return Ok($"Общо: {itemsTotalPrice}");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Възникна грешка: {ex.Message}");
			}
		}

		[HttpGet]
		public async Task<IActionResult> CalculateServiceFee(int cartId)
		{
			try
			{
				var serviceFeeTotalPrice = await shoppingCartService.CalculateServiceFeeAsync(cartId);
				return Ok($"Общо: {serviceFeeTotalPrice}");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Възникна грешка: {ex.Message}");
			}
		}

		[HttpGet]
		public async Task<IActionResult> CalculateTotalPriceAsync(int cartId)
		{
			try
			{
				var totalPrice = await shoppingCartService.CalculateTotalPriceAsync(cartId);
				return Ok($"Общо: {totalPrice}");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Възникна грешка: {ex.Message}");
			}
		}
	}
}