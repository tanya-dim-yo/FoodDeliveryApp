using FoodDeliveryApp.Core.Contracts.Restaurant;
using FoodDeliveryApp.Core.Models.Item;
using FoodDeliveryApp.Core.Models.Restaurant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
			IEnumerable<RestaurantViewModel> model = await restaurantService.GetAllAsync();

			return View(model);
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
			IEnumerable<RestaurantViewModel> model = await restaurantService.HighestRatingAsync();

			return View(nameof(All), model);
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> ServiceFee()
		{
			IEnumerable<RestaurantViewModel> model = await restaurantService.ServiceFeeAsync();

			return View(nameof(All), model);
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> ByCategory(int categoryId)
		{
			IEnumerable<RestaurantViewModel> model = await restaurantService.GetByCategoryAsync(categoryId);

			return View(nameof(All), model);
		}

		[AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Search(string keyword)
        {
            IEnumerable<RestaurantViewModel> model = await restaurantService.SearchAsync(keyword);

			ViewBag.SearchedKeyword = keyword;

			return View(model);
		}

		[AllowAnonymous]
        [HttpGet]
		public async Task<IActionResult> Menu(int restaurantId)
		{
			RestaurantViewModel? restaurant = await restaurantService.GetByIdAsync(restaurantId);

			if (restaurant == null)
			{
				return NotFound();
			}

			IEnumerable<ItemViewModel> items = await restaurantService.MenuAsync(restaurantId);

			var model = new RestaurantDetailViewModel
			{
				Restaurant = restaurant,
				Items = items
			};

			return View(model);
		}

		public IActionResult RateRestaurant(int id, double newRating)
		{
			return View();
		}
	}
}
