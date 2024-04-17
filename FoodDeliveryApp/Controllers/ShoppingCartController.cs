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
	}
}