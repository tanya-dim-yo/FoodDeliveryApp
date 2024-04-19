using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Core.Models.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace FoodDeliveryApp.Controllers
{
	public class CartController : BaseController
	{
		private readonly ICartService cartService;
		private readonly IHttpContextAccessor httpContextAccessor;

		public CartController(ICartService _cartService, IHttpContextAccessor _httpContextAccessor)
		{
			cartService = _cartService;
			httpContextAccessor = _httpContextAccessor;
		}

		[HttpGet]
		[AllowAnonymous]
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

			ShoppingCartViewModel model;

			if (httpContextAccessor.HttpContext.Session.TryGetValue("Cart", out byte[] cartData))
			{
				model = JsonSerializer.Deserialize<ShoppingCartViewModel>(cartData);
			}
			else
			{
				model = await cartService.GetShopCartByIdAsync(userId);

				if (model == null)
				{
					return RedirectToAction("Error", "Home", new { errorMessage = "No existing shop cart." });
				}

				httpContextAccessor.HttpContext.Session.Set("Cart", JsonSerializer.SerializeToUtf8Bytes(model));
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

				var model = await cartService.GetShopCartByIdAsync(userId);
				httpContextAccessor.HttpContext.Session.Set("Cart", JsonSerializer.SerializeToUtf8Bytes(model));

				return RedirectToAction(nameof(Cart), new { cartId });
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

		[HttpPost]
		public async Task<IActionResult> AddAddOnToCart(int itemId, int addOnId, int quantity, int cartId)
		{
			try
			{
				await cartService.AddAddOnToCartAsync(itemId, addOnId, quantity, cartId);
				return Ok("Add-on was successfully added to the cart!");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

		[HttpGet]
		public async Task<IActionResult> RemoveItemFromCart(int itemId, int cartId)
		{
			try
			{
				await cartService.RemoveItemFromCartAsync(itemId, cartId);
				return Ok("Item was successfully removed from the cart!");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

		[HttpGet]
		public async Task<IActionResult> RemoveAddOnFromCart(int addOnId, int cartId)
		{
			try
			{
				await cartService.RemoveAddOnFromCartAsync(addOnId, cartId);
				return Ok("Add-on was successfully removed from the cart!");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

		[HttpGet]
		public async Task<IActionResult> CalculateItemsTotalPrice(int cartId)
		{
			try
			{
				var itemsTotalPrice = await cartService.CalculateItemsTotalPriceAsync(cartId);
				return Ok($"Total: {itemsTotalPrice}");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

		[HttpGet]
		public async Task<IActionResult> CalculateServiceFee(int cartId)
		{
			try
			{
				var serviceFeeTotalPrice = await cartService.CalculateServiceFeeAsync(cartId);
				return Ok($"Total: {serviceFeeTotalPrice}");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}

		[HttpGet]
		public async Task<IActionResult> CalculateTotalPriceAsync(int cartId)
		{
			try
			{
				var totalPrice = await cartService.CalculateTotalPriceAsync(cartId);
				return Ok($"Total: {totalPrice}");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"An error occurred: {ex.Message}");
			}
		}
	}
}