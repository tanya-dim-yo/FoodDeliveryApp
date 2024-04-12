using FoodDeliveryApp.Core.Contracts;
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
			var (model, categories, totalRestaurantsCount) = await restaurantService.GetAllRestaurantsAndCategoriesAsync();

			var modelWrapper = new RestaurantsWithCategoriesViewModel
			{
				RestaurantViewModels = model,
				CategoryNames = categories.Select(c => c.Title),
				CategoryIds = categories.Select(c => c.Id),
				TotalRestaurantsCount = totalRestaurantsCount
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
		public async Task<IActionResult> HighestRating(int? currentPage = null, int restaurantsPerPage = 6)
		{
			currentPage ??= 1;

			var restaurants = await restaurantService.HighestRatingRestaurantsAsync();

			var categories = Enumerable.Empty<(int Id, string Title)>();
			var totalRestaurantsCount = 0;

			var paginatedRestaurants = restaurants
				.Skip((currentPage.Value - 1) * restaurantsPerPage)
				.Take(restaurantsPerPage)
				.ToList();

			var modelWrapper = new RestaurantsWithCategoriesViewModel
			{
				RestaurantViewModels = paginatedRestaurants,
				CategoryNames = categories.Select(c => c.Title),
				CategoryIds = categories.Select(c => c.Id),
				TotalRestaurantsCount = totalRestaurantsCount
			};

			ViewData["ListTitle"] = RestaurantsSortedByHighestRatingMessage;

			return View(nameof(All), modelWrapper);
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> ServiceFee(int? currentPage = null, int restaurantsPerPage = 6)
		{
			currentPage ??= 1;

			var restaurants = await restaurantService.RestaurantsByServiceFeeAsync();

			var categories = Enumerable.Empty<(int Id, string Title)>();
			var totalRestaurantsCount = 0;

			var paginatedRestaurants = restaurants
				.Skip((currentPage.Value - 1) * restaurantsPerPage)
				.Take(restaurantsPerPage)
				.ToList();

			var modelWrapper = new RestaurantsWithCategoriesViewModel
			{
				RestaurantViewModels = paginatedRestaurants,
				CategoryNames = categories.Select(c => c.Title),
				CategoryIds = categories.Select(c => c.Id),
				TotalRestaurantsCount = totalRestaurantsCount
			};

			ViewData["ListTitle"] = RestaurantsSortedByServiceFeeMessage;

			return View(nameof(All), modelWrapper);
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> ByCategory(int categoryId, int currentPage = 1, int restaurantsPerPage = 6)
		{
			if (await restaurantService.ExistsRestaurantCategoryAsync(categoryId) == false)
			{
				return RedirectToAction("Error", "Home", new { errorMessage = InvalidCategoryErrorMessage });
			}

			var (restaurants, categories, totalRestaurantsCount) = await restaurantService.GetAllRestaurantsAndCategoriesAsync();

			var categoryName = categories.FirstOrDefault(c => c.Id == categoryId).Title;

			if (categoryName == null)
			{
				return RedirectToAction("Error", "Home", new { errorMessage = InvalidCategoryErrorMessage });
			}

			var filteredRestaurants = restaurants.Where(r => r.RestaurantCategory == categoryName);

			var paginatedRestaurants = filteredRestaurants
				.Skip((currentPage - 1) * restaurantsPerPage)
				.Take(restaurantsPerPage)
				.ToList();

			var model = new RestaurantsWithCategoriesViewModel
			{
				CategoryNames = categories.Select(c => c.Title),
				CategoryIds = categories.Select(c => c.Id),
				RestaurantViewModels = paginatedRestaurants,
				TotalRestaurantsCount = filteredRestaurants.Count()
			};

			ViewData["ListTitle"] = string.Format(RestaurantCategoryMessage, categoryName);

			return View(nameof(All), model);
		}


		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> Search(string keyword, int currentPage = 1, int restaurantsPerPage = 6)
		{
			var searchResults = await restaurantService.SearchRestaurantsAsync(keyword);
			var results = searchResults.Results;

			var (_, categories, totalRestaurantsCount) = await restaurantService.GetAllRestaurantsAndCategoriesAsync();

			var modelWrapper = new RestaurantsWithCategoriesViewModel
			{
				CategoryNames = categories.Select(c => c.Title),
				CategoryIds = categories.Select(c => c.Id),
			};

			var paginatedResults = results
				.Skip((currentPage - 1) * restaurantsPerPage)
				.Take(restaurantsPerPage)
				.ToList();

			modelWrapper.RestaurantViewModels = paginatedResults;

			ViewData["ListTitle"] = $"{searchResults.Results.Count()} Обекти, съответстващи на търсенето на ‘{searchResults.SanitizedKeyword}‘";

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
			var (restaurants, categories, _) = await restaurantService.GetAllRestaurantsAndCategoriesAsync();
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
				var (_, categories, _) = await restaurantService.GetAllRestaurantsAndCategoriesAsync();
				model.Categories = categories.Select(c => new RestaurantCategoryViewModel { Id = c.Id, Title = c.Title });
				return View(model);
			}

			await restaurantService.AddRestaurantAsync(model, openHour, closeHour);

			return RedirectToAction(nameof(All));
		}

		[HttpGet]
		public async Task<IActionResult> RestaurantCategories()
		{
			var model = new RestaurantsWithCategoriesViewModel
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
				var (_, categories, _) = await restaurantService.GetAllRestaurantsAndCategoriesAsync();
				model.Categories = categories.Select(c => new RestaurantCategoryViewModel { Id = c.Id, Title = c.Title });
				model.Cities = await restaurantService.AllRestaurantCitiesAsync();

				return View(model);
			}

			await restaurantService.EditAsync(restaurantId, model);

			return RedirectToAction("Menu", new { restaurantId });
		}
	}
}