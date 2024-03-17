using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Controllers
{
	public class LocationController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Add()
		{
			return View();
		}
	}
}