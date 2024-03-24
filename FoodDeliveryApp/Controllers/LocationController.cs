using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Controllers
{
	public class LocationController : BaseController
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