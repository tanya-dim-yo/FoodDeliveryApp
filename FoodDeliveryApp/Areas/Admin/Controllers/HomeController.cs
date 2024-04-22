using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Areas.Admin.Controllers
{
	public class HomeController : AdminBaseController
	{
		public IActionResult DashBoard()
		{
            return View();
        }
	}
}