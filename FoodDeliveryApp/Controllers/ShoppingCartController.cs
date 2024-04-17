using FoodDeliveryApp.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

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
				await shoppingCartService.AddItemToCartAsync(itemId, quantity, cartId);
				return Ok("Продуктът е добавен успешно към количката!");
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Възникна грешка: {ex.Message}");
			}
		}

		
	}
}