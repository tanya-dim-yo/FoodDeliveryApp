using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Core.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FoodDeliveryApp.Core.Constants.ErrorMessagesConstants.ProductErrorMessagesConstants;
using static FoodDeliveryApp.Core.Constants.MessageConstants.ProductMessageConstants;

namespace FoodDeliveryApp.Controllers
{
	public class ProductController : BaseController
    {
		private readonly IProductService productService;
		private readonly IRestaurantService restaurantService;

		public ProductController(IProductService _productService, IRestaurantService _restaurantService)
		{
			productService = _productService;
			restaurantService = _restaurantService;
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
			if (productId <= 0)
			{
				return BadRequest("Invalid productId");
			}

			try
			{
				var product = await productService.GetProductByIdAsync(productId);

				if (product == null)
				{
					return NotFound(); // Product not found
				}

				product.IsFavourite = !product.IsFavourite;

				await productService.UpdateFavouriteProductAsync(productId);

				return Json(new { success = true, isFavorite = product.IsFavourite });
			}
			catch (Exception ex)
			{
				// Log exception
				return StatusCode(500, "An error occurred while processing the request");
			}
		}


		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var model = new ProductFormModel()
			{
				Categories = await productService.GetCategoriesAsync(),
				SpicyCategories = await productService.GetSpicyCategoriesAsync()
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(ProductFormModel model, int restaurantId)
		{
			if (await restaurantService.ExistsRestaurantAsync(restaurantId) == false)
			{
				ModelState.AddModelError(nameof(restaurantId), InvalidRestaurantMessage);
			}

			if (await productService.ExistsProductCategoryAsync(model.ItemCategoryId) == false)
			{
				ModelState.AddModelError(nameof(model.ItemCategoryId), InvalidCategoryMessage);
			}

			if (await productService.ExistsProductSpicyCategoryAsync(model.SpicyCategoryId) == false)
			{
				ModelState.AddModelError(nameof(model.SpicyCategoryId), InvalidSpicyCategoryMessage);
			}

			if (ModelState.IsValid == false)
			{
				model.Categories = await productService.GetCategoriesAsync();
				model.SpicyCategories = await productService.GetSpicyCategoriesAsync();

				return View(model);
			}

			await productService.AddProductAsync(model, restaurantId);

			int productId = await productService.AddProductAsync(model, restaurantId);

			return RedirectToAction(nameof(Details), new { restaurantId });
		}
	}
}