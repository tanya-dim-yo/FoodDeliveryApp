using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Controllers
{
    public class BlogController : BaseController
    {
        public IActionResult All()
        {
            return View();
        }
    }
}