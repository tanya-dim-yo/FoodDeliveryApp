using FoodDeliveryApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FoodDeliveryApp.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }


		[AllowAnonymous]
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error(string errorMessage = null)
		{
			var errorViewModel = new ErrorViewModel
			{
				RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
				ErrorMessage = errorMessage
			};

			if (!string.IsNullOrEmpty(errorMessage))
			{
				return View("Error404", errorViewModel);
			}
			else
			{
				return View("Error404");
			}
		}

		//[AllowAnonymous]
		//      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		//      public IActionResult Error()
		//      {
		//          return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		//      }
	}
}
