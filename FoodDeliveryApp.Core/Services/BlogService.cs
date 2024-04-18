using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Core.Models.Blog;

namespace FoodDeliveryApp.Core.Services
{
	public class BlogService : IBlogService
	{
		public Task<IEnumerable<string>> AllBlogCategoriesNamesAsync()
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<BlogArticleViewModel>> ArticlesByCategoryAsync(int categoryId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<BlogArticleViewModel>> ArticlesListAsync()
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

		public Task<(IEnumerable<BlogArticleViewModel> Articles, IEnumerable<(int Id, string Title)> Categories)> GetAllArticlesAndCategoriesAsync()
		{
			throw new NotImplementedException();
		}
	}
}
