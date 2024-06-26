﻿using FoodDeliveryApp.Core.Models.Blog;

namespace FoodDeliveryApp.Core.Contracts
{
    public interface IBlogService
	{
		Task<bool> ExistsBlogCategoryAsync(int categoryId);
		Task<bool> ExistsBlogArticleAsync(int articleId);
		Task<BlogArticleDetailsViewModel?> GetArticleByIdAsync(int articleId);
        Task<BlogArticleFormModel?> GetArticleFormModelByIdAsync(int articleId);
        Task EditArticleAsync(BlogArticleFormModel model, int articleId);
        Task<IEnumerable<BlogArticleViewModel>> AllArticlesAsync();
		Task<IEnumerable<BlogArticleCategoryViewModel>> AllBlogCategoriesAsync();
		Task<IEnumerable<BlogArticleViewModel>> ArticlesByCategoryAsync(int categoryId);
		Task<IEnumerable<string>> AllBlogCategoriesNamesAsync();
		Task<(string SanitizedKeyword, IEnumerable<BlogArticleViewModel> Results)> SearchBlogArticlesAsync(string keyword);
		Task<(IEnumerable<BlogArticleViewModel> Articles, IEnumerable<(int Id, string Title)> Categories)> GetAllArticlesAndCategoriesAsync();
	}
}