using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Controllers
{
    public class ItemController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}