using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Core.Models.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryApp.Controllers
{
	public class BlogController : BaseController
	{
		private readonly IBlogService blogService;

		public BlogController(IBlogService _blogService)
		{
			blogService = _blogService;
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> All()
		{
			var (articles, categories) = await blogService.GetAllArticlesAndCategoriesAsync();

			var modelWrapper = new ArticlesWithCategoriesViewModel
			{
				CategoryNames = categories.Select(c => c.Title),
				CategoryIds = categories.Select(c => c.Id),
				Articles = articles
			};

			return View(modelWrapper);
		}
	}
}