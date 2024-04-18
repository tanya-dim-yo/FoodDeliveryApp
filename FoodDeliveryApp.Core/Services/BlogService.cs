using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Core.Models.Blog;
using FoodDeliveryApp.Infrastructure.Data.Common;
using FoodDeliveryApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FoodDeliveryApp.Core.Services
{
	public class BlogService : IBlogService
	{
		private readonly IRepository repository;
		private readonly ILogger<BlogService> logger;

		public BlogService(
			IRepository _repository,
			ILogger<BlogService> _logger)
		{
			repository = _repository;
			logger = _logger;
		}

		public Task<IEnumerable<string>> AllBlogCategoriesNamesAsync()
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<BlogArticleViewModel>> ArticlesByCategoryAsync(int categoryId)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<BlogArticleViewModel>> AllArticlesAsync()
		{
			throw new NotImplementedException();
		}

		public Task<bool> ExistsBlogArticleAsync(int articleId)
		{
			throw new NotImplementedException();
		}

		public Task<bool> ExistsBlogCategoryAsync(int categoryId)
		{
			throw new NotImplementedException();
		}

		public async Task<(IEnumerable<BlogArticleViewModel> Articles, IEnumerable<(int Id, string Title)> Categories)> GetAllArticlesAndCategoriesAsync()
		{
			var model = new ArticlesWithCategoriesViewModel();

			var categories = await AllBlogCategoriesAsync();

			var articles = await repository
				.AllReadOnly<BlogArticle>()
				.ProjectToBlogArticleViewModel()
				.ToListAsync();

			model.CategoryNames = categories.Select(c => c.Title);
			model.CategoryIds = categories.Select(c => c.Id);

			return (articles, categories.Select(c => (c.Id, c.Title)));
		}

		public async Task<IEnumerable<(int Id, string Title)>> AllBlogCategoriesAsync()
		{
			var categories = await repository
				.AllReadOnly<BlogArticleCategory>()
				.Select(c => new { c.Id, c.Title })
				.ToListAsync();

			return categories.Select(c => (c.Id, c.Title));
		}
	}
}
