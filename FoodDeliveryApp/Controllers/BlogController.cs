using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}