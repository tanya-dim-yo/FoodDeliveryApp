using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Core.Models.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static FoodDeliveryApp.Core.Constants.ErrorMessagesConstants.ShopCartErrorMessagesConstants;

namespace FoodDeliveryApp.Controllers
{
	public class CartController : BaseController
	{
		private readonly ICartService cartService;

		public CartController(ICartService _cartService)
		{
			cartService = _cartService;
		}

		[HttpPost]
		public async Task<IActionResult> Cart()
		{
			if (!User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Login", "Account");
			}
			
			var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			if (string.IsNullOrEmpty(userId))
			{
				return Unauthorized();
			}

			ShoppingCartViewModel? model = await cartService.GetShopCartByIdAsync(userId);

			if (model == null)
			{
				return RedirectToAction("Error", "Home", new { errorMessage = NoExistingShopCartErrorMessage });
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(int itemId, int quantity)
		{
			try
			{
				var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

				if (string.IsNullOrEmpty(userId))
				{
					return Unauthorized();
				}

				var cartId = await cartService.AddItemToCartAsync(itemId, quantity, userId);

				return RedirectToAction(nameof(Cart), new { cartId });
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
				await cartService.AddAddOnToCartAsync(itemId, addOnId, quantity, cartId);
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
				await cartService.RemoveItemFromCartAsync(itemId, cartId);
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
				await cartService.RemoveAddOnFromCartAsync(addOnId, cartId);
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
				var itemsTotalPrice = await cartService.CalculateItemsTotalPriceAsync(cartId);
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
				var serviceFeeTotalPrice = await cartService.CalculateServiceFeeAsync(cartId);
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
				var totalPrice = await cartService.CalculateTotalPriceAsync(cartId);
				return Ok($"Общо: {totalPrice}");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Възникна грешка: {ex.Message}");
			}
		}
	}
}