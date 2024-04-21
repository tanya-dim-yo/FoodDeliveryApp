using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Core.Models.Blog;
using FoodDeliveryApp.Core.Models.Product;
using FoodDeliveryApp.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;
using static FoodDeliveryApp.Core.Constants.ErrorMessagesConstants.BlogErrorMessagesConstants;
using static FoodDeliveryApp.Core.Constants.ErrorMessagesConstants.UserErrorMessagesConstants;
using static FoodDeliveryApp.Core.Constants.MessageConstants.BlogArticleMessageConstants;

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

			var modelWrapper = new BlogArticlesWithCategoriesViewModel
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

			var model = new BlogArticlesWithCategoriesViewModel
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

			var modelWrapper = new BlogArticlesWithCategoriesViewModel
			{
				CategoryNames = categories.Select(c => c.Title),
				CategoryIds = categories.Select(c => c.Id),
				Articles = results
			};

			ViewData["ListTitle"] = $"{searchResults.Results.Count()} Обекти, съответстващи на търсенето на ‘{searchResults.SanitizedKeyword}‘";

			return View(nameof(All), modelWrapper);
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Article(int articleId)
		{
			BlogArticleDetailsViewModel? model = await blogService.GetArticleByIdAsync(articleId);

			if (model == null)
			{
				return RedirectToAction("Error", "Home", new { errorMessage = NoExistingBlogArticleErrorMessage });
			}

			string? facebookUrl = Url.Action("Article", "Blog", new { articleId = model.Id }, Request.Scheme);
			string? twitterUrl = Url.Action("Article", "Blog", new { articleId = model.Id }, Request.Scheme);
			string? linkedInUrl = Url.Action("Article", "Blog", new { articleId = model.Id }, Request.Scheme);

			model.FacebookUrl = facebookUrl;
			model.TwitterUrl = twitterUrl;
			model.LinkedInUrl = linkedInUrl;

			return View(model);
		}

        [HttpGet]
        public async Task<IActionResult> Edit(int articleId)
        {
            if (User.IsAdmin() == false)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = NotAdminErrorMessage });
            }

            if (await blogService.ExistsBlogArticleAsync(articleId) == false)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = NoExistingBlogArticleErrorMessage });
            }

            var model = await blogService.GetArticleFormModelByIdAsync(articleId);

            ViewBag.ArticleId = articleId;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BlogArticleFormModel model, int articleId)
        {
            if (User.IsAdmin() == false)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = NotAdminErrorMessage });
            }

            if (await blogService.ExistsBlogArticleAsync(articleId) == false)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = NoExistingBlogArticleErrorMessage });
            }

            if (await blogService.ExistsBlogCategoryAsync(model.BlogArticleCategoryId) == false)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = NoExistingBlogCategoryErrorMessage });
            }

			DateTime pubDate = DateTime.MinValue;

			if (!DateTime.TryParseExact(
				model.PublicationDate,
				"dd.MM.yyyy",
				CultureInfo.InvariantCulture,
				DateTimeStyles.None,
				out pubDate))
			{
				ModelState.AddModelError(nameof(model.PublicationDate), InvalidDateMessage);
			}

			model.PublicationDateDT = pubDate;

			if (ModelState.IsValid == false)
            {
                model.Categories = await blogService.AllBlogCategoriesAsync();

                return View(model);
            }

            await blogService.EditArticleAsync(model, articleId);

            return RedirectToAction(nameof(Article), new { articleId });
        }
    }
}