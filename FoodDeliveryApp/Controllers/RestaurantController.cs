using FoodDeliveryApp.Core.Contracts.Restaurant;
using FoodDeliveryApp.Core.Models.Restaurant;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Controllers
{
	public class RestaurantController : Controller
    {
		private readonly IRestaurantService restaurantService;

		public RestaurantController(IRestaurantService _restaurantService)
		{
			restaurantService = _restaurantService;
		}

		[HttpGet]
        public async Task<IActionResult> All()
        {
			IEnumerable<RestaurantViewModel> model = await restaurantService.GetAllAsync();

			return View(model);
		}

		public IActionResult Nearest()
		{
			return View();
		}

		public IActionResult HighestRating()
		{
			return View();
		}

		public IActionResult ServiceFee()
		{
			return View();
		}

		public IActionResult GetCategory()
		{
			return View();
		}

		public IActionResult GetRestaurant(int id)
		{
			return View();
		}

		public IActionResult RateRestaurant(int id, double newRating)
		{
			return View();
		}
	}
}
