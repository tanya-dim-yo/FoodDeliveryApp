using FoodDeliveryApp.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Controllers
{
    public class ProductController : BaseController
    {
		private readonly IProductService productService;

		public ProductController(IProductService _productService)
		{
			productService = _productService;
		}

		[HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int productId)
        {
            var model = await productService.GetProductByIdAsync(productId);

            return View(model);
        }
    }
}