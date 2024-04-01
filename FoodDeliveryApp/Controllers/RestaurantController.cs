using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Core.Models.Item;
using FoodDeliveryApp.Core.Models.Restaurant;
using FoodDeliveryApp.Core.Services.Restaurant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
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

			var modelWrapper = new RestaurantViewModelWrapper
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

			return View(nameof(All), model);
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> ServiceFee()
		{
			IEnumerable<RestaurantViewModel> model = await restaurantService.RestaurantsByServiceFeeAsync();

			return View(nameof(All), model);
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> ByCategory(int categoryId)
		{
			if (await restaurantService.ExistsRestaurantCategoryAsync(categoryId) == false)
			{
				return BadRequest();
			}

			var (restaurants, categories) = await restaurantService.GetAllRestaurantsAndCategoriesAsync();
			var categoryName = categories.FirstOrDefault(c => c.Id == categoryId).Title;

			if (categoryName == null)
			{
				return BadRequest("Category not found.");
			}

			var model = new RestaurantViewModelWrapper
			{
				CategoryNames = categories.Select(c => c.Title),
				CategoryIds = categories.Select(c => c.Id),
				RestaurantViewModels = restaurants.Where(r => r.RestaurantCategory == categoryName).ToList(),
			};

			ViewData["CategoryName"] = categoryName;
			return View(nameof(All), model);
		}

		[AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Search(string keyword)
        {
			var searchResults = await restaurantService.SearchRestaurantsAsync(keyword);

			ViewBag.SearchedKeyword = searchResults.SanitizedKeyword;
			IEnumerable<RestaurantViewModel> results = searchResults.Results;

			return View(results);
		}

		[AllowAnonymous]
        [HttpGet]
		public async Task<IActionResult> Menu(int restaurantId)
		{
			RestaurantViewModel? restaurant = await restaurantService.GetRestaurantByIdAsync(restaurantId);

			if (restaurant == null)
			{
				return NotFound();
			}

			IEnumerable<ItemViewModel> items = await restaurantService.MenuRestaurantAsync(restaurantId);

			var model = new RestaurantDetailViewModel
			{
				Restaurant = restaurant,
				Items = items
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
			var categoryViewModels = categories.Select(c => new RestaurantCategoryModel { Id = c.Id, Title = c.Title });

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
				model.Categories = categories.Select(c => new RestaurantCategoryModel { Id = c.Id, Title = c.Title });
				return View(model);
			}

			await restaurantService.AddRestaurantAsync(model, openHour, closeHour);

			return RedirectToAction(nameof(All));
		}

		public async Task<IActionResult> RestaurantCategories()
		{
			var model = new RestaurantViewModelWrapper
			{
				CategoryNames = await restaurantService.AllRestaurantCategoriesNamesAsync()
			};

			return View(model);
		}
	}
}
