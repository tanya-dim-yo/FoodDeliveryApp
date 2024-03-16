using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Controllers
{
    public class RestaurantController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
