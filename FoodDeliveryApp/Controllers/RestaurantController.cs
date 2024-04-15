using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Core.Models.Product;
using FoodDeliveryApp.Core.Models.Restaurant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;
using static FoodDeliveryApp.Core.Constants.ErrorMessagesConstants.RestaurantErrorMessagesConstants;
using static FoodDeliveryApp.Core.Constants.ErrorMessagesConstants.UserErrorMessagesConstants;
using static FoodDeliveryApp.Core.Constants.MessageConstants.RestaurantMessageConstants;

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

            var modelWrapper = new RestaurantsWithCategoriesViewModel
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
		public async Task<IActionResult> ServiceFee()
		{
			var restaurants = await restaurantService.RestaurantsByServiceFeeAsync();
			var categories = Enumerable.Empty<(int Id, string Title)>();

			var modelWrapper = new RestaurantsWithCategoriesViewModel
			{
				RestaurantViewModels = restaurants,
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

			var filteredRestaurants = restaurants.Where(r => r.RestaurantCategory == categoryName);

			var model = new RestaurantsWithCategoriesViewModel
			{
				CategoryNames = categories.Select(c => c.Title),
				CategoryIds = categories.Select(c => c.Id),
				RestaurantViewModels = filteredRestaurants
			};

			ViewData["ListTitle"] = string.Format(RestaurantCategoryMessage, categoryName);

			return View(nameof(All), model);
		}


		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> Search(string keyword)
		{
			var searchResults = await restaurantService.SearchRestaurantsAsync(keyword);
			var results = searchResults.Results;

			var (_, categories) = await restaurantService.GetAllRestaurantsAndCategoriesAsync();

			var modelWrapper = new RestaurantsWithCategoriesViewModel
			{
				CategoryNames = categories.Select(c => c.Title),
				CategoryIds = categories.Select(c => c.Id),
				RestaurantViewModels = results
			};

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

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			if (User.IsAdmin() == false)
			{
                return RedirectToAction("Error", "Home", new { errorMessage = NotAdminErrorMessage });
            }

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
            if (User.IsAdmin() == false)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = NotAdminErrorMessage });
            }

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
			var model = new RestaurantsWithCategoriesViewModel
			{
				CategoryNames = await restaurantService.AllRestaurantCategoriesNamesAsync()
			};

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int restaurantId)
		{
            if (User.IsAdmin() == false)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = NotAdminErrorMessage });
            }

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
            if (User.IsAdmin() == false)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = NotAdminErrorMessage });
            }

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

        [HttpGet]
        public async Task<IActionResult> Delete(int restaurantId)
        {
            if (User.IsAdmin() == false)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = NotAdminErrorMessage });
            }

            if (await restaurantService.ExistsRestaurantAsync(restaurantId) == false)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = InvalidRestaurantErrorMessage });
            }

            var model = await restaurantService.GetRestaurantFormModelByIdAsync(restaurantId);

            return View(model);
        }

		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(int restaurantId)
		{
            if (User.IsAdmin() == false)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = NotAdminErrorMessage });
            }

            if (await restaurantService.ExistsRestaurantAsync(restaurantId) == false)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = InvalidRestaurantErrorMessage });
            }

            await restaurantService.DeleteAsync(restaurantId);

			return RedirectToAction(nameof(All));
		}
	}
}