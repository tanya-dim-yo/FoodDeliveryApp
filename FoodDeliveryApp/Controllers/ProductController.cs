using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Controllers
{
    public class ProductController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Details()
        {
            return View();
        }
    }
}