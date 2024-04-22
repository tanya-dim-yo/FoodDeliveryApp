using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Controllers
{
	public class ContactController : BaseController
	{
		[AllowAnonymous]
		public IActionResult ContactUs()
		{
			return View();
		}
	}
}