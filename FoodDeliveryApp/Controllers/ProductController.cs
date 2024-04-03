using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Core.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FoodDeliveryApp.Core.Constants.ErrorMessagesConstants.ProductErrorMessagesConstants;

namespace FoodDeliveryApp.Controllers
{
	public class ProductController : BaseController
    {
		private readonly IProductService productService;

		public ProductController(IProductService _productService)
		{
			productService = _productService;
		}

		[HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int productId)
        {
            ProductDetailsViewModel? model = await productService.GetProductByIdAsync(productId);

			if (model == null)
			{
				return RedirectToAction("Error", "Home", new { errorMessage = InvalidProductErrorMessage });
			}

			return View(model);
        }
    }
}