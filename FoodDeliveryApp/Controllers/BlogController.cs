using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Core.Models.Blog;
using FoodDeliveryApp.Core.Models.Restaurant;
using FoodDeliveryApp.Core.Services.Restaurant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FoodDeliveryApp.Core.Constants.ErrorMessagesConstants.BlogErrorMessagesConstants;
using static FoodDeliveryApp.Core.Constants.MessageConstants.BlogConstants;

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

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> ByCategory(int categoryId)
		{
			if (await blogService.ExistsBlogCategoryAsync(categoryId) == false)
			{
				return RedirectToAction("Error", "Home", new { errorMessage = NoExistingBlogCategoryErrorMessage });
			}

			var (articles, categories) = await blogService.GetAllArticlesAndCategoriesAsync();

			var categoryName = categories.FirstOrDefault(c => c.Id == categoryId).Title;

			if (categoryName == null)
			{
				return RedirectToAction("Error", "Home", new { errorMessage = NoExistingBlogCategoryErrorMessage });
			}

			var filteredArticles = articles.Where(a => a.Category == categoryName);

			var model = new ArticlesWithCategoriesViewModel
			{
				CategoryNames = categories.Select(c => c.Title),
				CategoryIds = categories.Select(c => c.Id),
				Articles = filteredArticles
			};

			ViewData["ListTitle"] = string.Format(BlogCategoryMessage, categoryName);

			return View(nameof(All), model);
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> Search(string keyword)
		{
			var searchResults = await blogService.SearchBlogArticlesAsync(keyword);
			var results = searchResults.Results;

			var (_, categories) = await blogService.GetAllArticlesAndCategoriesAsync();

			var modelWrapper = new ArticlesWithCategoriesViewModel
			{
				CategoryNames = categories.Select(c => c.Title),
				CategoryIds = categories.Select(c => c.Id),
				Articles = results
			};

			ViewData["ListTitle"] = $"{searchResults.Results.Count()} Обекти, съответстващи на търсенето на ‘{searchResults.SanitizedKeyword}‘";

			return View(nameof(All), modelWrapper);
		}
	}
}