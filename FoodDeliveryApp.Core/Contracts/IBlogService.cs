using FoodDeliveryApp.Core.Models.Blog;
using FoodDeliveryApp.Core.Models.Restaurant;

namespace FoodDeliveryApp.Core.Contracts
{
	public interface IBlogService
	{
		Task<bool> ExistsBlogCategoryAsync(int categoryId);
		Task<bool> ExistsBlogArticleAsync(int articleId);
		Task<IEnumerable<BlogArticleViewModel>> AllArticlesAsync();
		Task<IEnumerable<(int Id, string Title)>> AllBlogCategoriesAsync();
		Task<IEnumerable<BlogArticleViewModel>> ArticlesByCategoryAsync(int categoryId);
		Task<IEnumerable<string>> AllBlogCategoriesNamesAsync();
		Task<(string SanitizedKeyword, IEnumerable<BlogArticleViewModel> Results)> SearchBlogArticlesAsync(string keyword);
		Task<(IEnumerable<BlogArticleViewModel> Articles, IEnumerable<(int Id, string Title)> Categories)> GetAllArticlesAndCategoriesAsync();
	}
}