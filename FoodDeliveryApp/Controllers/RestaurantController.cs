﻿using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Core.Models.Product;
using FoodDeliveryApp.Core.Models.Restaurant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static FoodDeliveryApp.Core.Constants.MessageConstants.RestaurantMessageConstants;
using static FoodDeliveryApp.Core.Constants.ErrorMessagesConstants.RestaurantErrorMessagesConstants;

namespace FoodDeliveryApp.Controllers
{
	public class RestaurantController : BaseController
	{
		private readonly IRestaurantService restaurantService;

		public RestaurantController(IRestaurantService _restaurantService)
		{
			restaurantService = _restaurantService;
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> All()
		{
			var (model, categories) = await restaurantService.GetAllRestaurantsAndCategoriesAsync();

			var modelWrapper = new RestaurantWithCategoriesViewModel
			{
				RestaurantViewModels = model,
				CategoryNames = categories.Select(c => c.Title),
				CategoryIds = categories.Select(c => c.Id)
			};

			return View(modelWrapper);
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Nearest()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> HighestRating()
		{
			IEnumerable<RestaurantViewModel> model = await restaurantService.HighestRatingRestaurantsAsync();

			var (_, categories) = await restaurantService.GetAllRestaurantsAndCategoriesAsync();

			var modelWrapper = new RestaurantWithCategoriesViewModel
			{
				RestaurantViewModels = model,
				CategoryNames = categories.Select(c => c.Title),
				CategoryIds = categories.Select(c => c.Id)
			};

			ViewData["ListTitle"] = RestaurantsSortedByHighestRatingMessage;
			return View(nameof(All), modelWrapper);
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> ServiceFee()
		{
			IEnumerable<RestaurantViewModel> model = await restaurantService.RestaurantsByServiceFeeAsync();

			var (_, categories) = await restaurantService.GetAllRestaurantsAndCategoriesAsync();

			var modelWrapper = new RestaurantWithCategoriesViewModel
			{
				RestaurantViewModels = model,
				CategoryNames = categories.Select(c => c.Title),
				CategoryIds = categories.Select(c => c.Id)
			};

			ViewData["ListTitle"] = RestaurantsSortedByServiceFeeMessage;
			return View(nameof(All), modelWrapper);
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> ByCategory(int categoryId)
		{
			if (await restaurantService.ExistsRestaurantCategoryAsync(categoryId) == false)
			{
				return RedirectToAction("Error", "Home", new { errorMessage = InvalidCategoryErrorMessage });
			}

			var (restaurants, categories) = await restaurantService.GetAllRestaurantsAndCategoriesAsync();
			var categoryName = categories.FirstOrDefault(c => c.Id == categoryId).Title;

			if (categoryName == null)
			{
				return RedirectToAction("Error", "Home", new { errorMessage = InvalidCategoryErrorMessage });
			}

			var model = new RestaurantWithCategoriesViewModel
			{
				CategoryNames = categories.Select(c => c.Title),
				CategoryIds = categories.Select(c => c.Id),
				RestaurantViewModels = restaurants.Where(r => r.RestaurantCategory == categoryName).ToList(),
			};

			ViewData["ListTitle"] = string.Format(RestaurantCategoryMessage, categoryName);
			return View(nameof(All), model);
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> Search(string keyword)
		{
			var searchResults = await restaurantService.SearchRestaurantsAsync(keyword);
			IEnumerable<RestaurantViewModel> results = searchResults.Results;

			var (_, categories) = await restaurantService.GetAllRestaurantsAndCategoriesAsync();

			var modelWrapper = new RestaurantWithCategoriesViewModel
			{
				RestaurantViewModels = results,
				CategoryNames = categories.Select(c => c.Title),
				CategoryIds = categories.Select(c => c.Id)
			};

			ViewData["ListTitle"] = searchResults.SanitizedKeyword;

			return View(nameof(All), modelWrapper);
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> Menu(int restaurantId)
		{
			RestaurantViewModel? restaurant = await restaurantService.GetRestaurantByIdAsync(restaurantId);

			if (restaurant == null)
			{
				return RedirectToAction("Error", "Home", new { errorMessage = InvalidRestaurantErrorMessage });
			}

			IEnumerable<ProductViewModel> items = await restaurantService.MenuRestaurantAsync(restaurantId);

			var model = new RestaurantWithProductsViewModel
			{
				Restaurant = restaurant,
				Products = items
			};

			return View(model);
		}

		public async Task<IActionResult> RateRestaurant(int id, double newRating)
		{
			await restaurantService.RateRestaurant(id, newRating);

			return RedirectToAction(nameof(All));
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var (restaurants, categories) = await restaurantService.GetAllRestaurantsAndCategoriesAsync();
			var categoryViewModels = categories.Select(c => new RestaurantCategoryViewModel { Id = c.Id, Title = c.Title });

			var model = new RestaurantFormModel()
			{
				Categories = categoryViewModels
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(RestaurantFormModel model)
		{
			if (await restaurantService.ExistsCityAsync(model.CityId) == false)
			{
				ModelState.AddModelError(nameof(model.CityId), InvalidCityMessage);
			}

			if (await restaurantService.ExistsRestaurantCategoryAsync(model.RestaurantCategoryId) == false)
			{
				ModelState.AddModelError(nameof(model.RestaurantCategoryId), InvalidRestaurantCategoryMessage);
			}

			DateTime openHour = DateTime.MinValue;
			DateTime closeHour = DateTime.MinValue;

			if (!DateTime.TryParseExact(
				model.OpeningHour,
				"HH:mm",
				CultureInfo.InvariantCulture,
				DateTimeStyles.None,
				out openHour))
			{
				ModelState.AddModelError(nameof(model.OpeningHour), InvalidTimeMessage);
			}

			if (!DateTime.TryParseExact(
				model.ClosingHour,
				"HH:mm",
				CultureInfo.InvariantCulture,
				DateTimeStyles.None,
				out closeHour))
			{
				ModelState.AddModelError(nameof(model.ClosingHour), InvalidTimeMessage);
			}

			if (model.OpeningHour == model.ClosingHour)
			{
				ModelState.AddModelError(nameof(model.OpeningHour), InvalidSameTimeMessage);
			}

			if (openHour > closeHour)
			{
				ModelState.AddModelError(nameof(model.OpeningHour), OpenHourBiggerMessage);
			}

			model.OpenHourDateTime = openHour;
			model.CloseHourDateTime = closeHour;

			if (ModelState.IsValid == false)
			{
				var (_, categories) = await restaurantService.GetAllRestaurantsAndCategoriesAsync();
				model.Categories = categories.Select(c => new RestaurantCategoryViewModel { Id = c.Id, Title = c.Title });
				return View(model);
			}

			await restaurantService.AddRestaurantAsync(model, openHour, closeHour);

			return RedirectToAction(nameof(All));
		}

		[HttpGet]
		public async Task<IActionResult> RestaurantCategories()
		{
			var model = new RestaurantWithCategoriesViewModel
			{
				CategoryNames = await restaurantService.AllRestaurantCategoriesNamesAsync()
			};

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int restaurantId)
		{
			if (await restaurantService.ExistsRestaurantAsync(restaurantId) == false)
			{
				return RedirectToAction("Error", "Home", new { errorMessage = InvalidRestaurantErrorMessage });
			}

			var model = await restaurantService.GetRestaurantFormModelByIdAsync(restaurantId);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int restaurantId, RestaurantFormModel model)
		{
			if (await restaurantService.ExistsRestaurantAsync(restaurantId) == false)
			{
				return RedirectToAction("Error", "Home", new { errorMessage = InvalidRestaurantErrorMessage });
			}

			if (await restaurantService.ExistsRestaurantCategoryAsync(model.RestaurantCategoryId) == false)
			{
				return RedirectToAction("Error", "Home", new { errorMessage = InvalidRestaurantCategoryMessage });
			}

			if (ModelState.IsValid == false)
			{
				var (_, categories) = await restaurantService.GetAllRestaurantsAndCategoriesAsync();
				model.Categories = categories.Select(c => new RestaurantCategoryViewModel { Id = c.Id, Title = c.Title });
				model.Cities = await restaurantService.AllRestaurantCitiesAsync();

				return View(model);
			}

			await restaurantService.EditAsync(restaurantId, model);

			return RedirectToAction("Menu", new { restaurantId });
		}
	}
}