using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Core.Models.Product;
using FoodDeliveryApp.Core.Models.Restaurant;
using FoodDeliveryApp.Core.Services.Restaurant;
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
            ProductDetailsViewModel? model = await productService.GetProductDetailsByIdAsync(productId);

			if (model == null)
			{
				return RedirectToAction("Error", "Home", new { errorMessage = InvalidProductErrorMessage });
			}

			return View(model);
        }

		[HttpPost]
		public async Task<IActionResult> Favourite(int productId)
		{
			var product = await productService.GetProductByIdAsync(productId);

			if (product == null)
			{
				return RedirectToAction("Error", "Home", new { errorMessage = InvalidProductErrorMessage });
			}

			product.IsFavourite = !product.IsFavourite;

			await productService.UpdateFavouriteProduct(productId);

			return Json(new { success = true, isFavorite = product.IsFavourite });
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var model = new ProductFormModel()
			{
				Categories = await productService.GetCategories(),
				SpicyCategories = await productService.GetSpicyCategories()
			};

			return View(model);
		}
	}
}