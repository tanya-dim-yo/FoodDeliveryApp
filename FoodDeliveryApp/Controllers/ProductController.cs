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
		private readonly ILogger logger;

		public ProductController(
			IProductService _productService,
			IRestaurantService _restaurantService,
			ILogger _logger)
		{
			productService = _productService;
			restaurantService = _restaurantService;
			logger = _logger;
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

			return RedirectToAction(nameof(Details), new { productId });
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int productId)
		{
			if (await productService.ExistsProductAsync(productId) == false)
			{
				return RedirectToAction("Error", "Home", new { errorMessage = InvalidProductErrorMessage });
			}

			var model = await productService.GetProductFormModelByIdAsync(productId);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(ProductFormModel model, int productId)
		{
			if (await productService.ExistsProductAsync(productId) == false)
			{
				return RedirectToAction("Error", "Home", new { errorMessage = InvalidProductErrorMessage });
			}

			if (await productService.ExistsProductCategoryAsync(model.ItemCategoryId) == false)
			{
				return RedirectToAction("Error", "Home", new { errorMessage = InvalidProductCategoryErrorMessage });
			}

			if (ModelState.IsValid == false)
			{
				model.Categories = await productService.GetCategoriesAsync();
				model.SpicyCategories = await productService.GetSpicyCategoriesAsync();

				return View(model);
			}

			await productService.EditProductAsync(model, productId);

			return RedirectToAction(nameof(Details), new { productId });
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int productId)
		{
			var product = await productService.GetProductByIdAsync(productId);

			if (product == null)
			{
				return RedirectToAction("Error", "Home", new { errorMessage = InvalidProductErrorMessage });
			
			}

			await productService.DeleteProductAsync(productId);

			return RedirectToAction("Menu", "Restaurant", new { product.RestaurantId });
		}
	}
}