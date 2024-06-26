﻿using FoodDeliveryApp.Core.Contracts;
using FoodDeliveryApp.Core.Models.Blog;
using FoodDeliveryApp.Core.Models.Product;
using FoodDeliveryApp.Core.Models.Restaurant;
using FoodDeliveryApp.Infrastructure.Data.Common;
using FoodDeliveryApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using static FoodDeliveryApp.Core.Extensions.StringExtensions;

namespace FoodDeliveryApp.Core.Services
{
    public class BlogService : IBlogService
	{
		private readonly IRepository repository;

		public BlogService(IRepository _repository)
		{
			repository = _repository;
		}

		public async Task<IEnumerable<string>> AllBlogCategoriesNamesAsync()
		{
			return await repository
				.AllReadOnly<BlogArticleCategory>()
				.OrderBy(c => c.Title)
				.Select(c => c.Title)
				.Distinct()
				.ToListAsync();
		}

		public async Task<IEnumerable<BlogArticleViewModel>> ArticlesByCategoryAsync(int categoryId)
		{
			return await repository
				.AllReadOnly<BlogArticle>()
				.Where(p => p.BlogArticleCategoryId == categoryId)
				.ProjectToBlogArticleViewModel()
				.ToListAsync();
		}

		public async Task<IEnumerable<BlogArticleViewModel>> AllArticlesAsync()
		{
			return await repository
				.AllReadOnly<BlogArticle>()
				.ProjectToBlogArticleViewModel()
				.ToListAsync();
		}

		public async Task<bool> ExistsBlogArticleAsync(int articleId)
		{
			return await repository
				.AllReadOnly<BlogArticle>()
				.AnyAsync(a => a.Id == articleId);
		}

		public async Task<bool> ExistsBlogCategoryAsync(int categoryId)
		{
			return await repository
				.AllReadOnly<BlogArticleCategory>()
				.AnyAsync(p => p.Id == categoryId);
		}

		public async Task<(IEnumerable<BlogArticleViewModel> Articles, IEnumerable<(int Id, string Title)> Categories)> GetAllArticlesAndCategoriesAsync()
		{
			var model = new BlogArticlesWithCategoriesViewModel();

			var categories = await AllBlogCategoriesAsync();

			var articles = await repository
				.AllReadOnly<BlogArticle>()
				.ProjectToBlogArticleViewModel()
				.ToListAsync();

			model.CategoryNames = categories.Select(c => c.Title);
			model.CategoryIds = categories.Select(c => c.Id);

			return (articles, categories.Select(c => (c.Id, c.Title)));
		}

		public async Task<IEnumerable<BlogArticleCategoryViewModel>> AllBlogCategoriesAsync()
		{
            return await repository
                .AllReadOnly<BlogArticleCategory>()
                .Select(c => new BlogArticleCategoryViewModel
                {
                    Id = c.Id,
                    Title = c.Title
                })
                .ToListAsync();
        }

		public async Task<(string SanitizedKeyword, IEnumerable<BlogArticleViewModel> Results)> SearchBlogArticlesAsync(string keyword)
		{
			string sanitizedKeyword = Sanitize(keyword);

			var characters = sanitizedKeyword.ToLower().Select(c => c.ToString()).ToArray();

			var query = repository.AllReadOnly<BlogArticle>();

			foreach (var ch in characters)
			{
				var keywordParameter = "%" + ch + "%";

				query = query
					.Where(p => EF.Functions.Like(p.Title.ToLower(), keywordParameter)
						   || EF.Functions.Like(p.Content.ToLower(), keywordParameter));
			}

			var results = await query
				.ProjectToBlogArticleViewModel()
				.ToListAsync();

			return (sanitizedKeyword, results);
		}

		public async Task<BlogArticleDetailsViewModel?> GetArticleByIdAsync(int articleId)
		{
			return await repository
				.AllReadOnly<BlogArticle>()
				.Where(a => a.Id == articleId)
				.Select(p => new BlogArticleDetailsViewModel()
				{
					Id = p.Id,
					Title = p.Title,
					PublicationDate = p.PublicationDate.ToString("dd.MM.yyyy"),
					ReadingTime = p.ReadingTime,
					Content = p.Content,
					Image = p.Image,
					CategoryId = p.BlogArticleCategoryId,
					Category = p.BlogArticleCategory.Title
				})
				.FirstOrDefaultAsync();
		}

        public async Task EditArticleAsync(BlogArticleFormModel model, int articleId)
        {
            var article = await repository.GetByIdAsync<BlogArticle>(articleId);

            if (article != null)
            {
                article.Title = model.Title;
				article.PublicationDate = model.PublicationDateDT;
				article.ReadingTime = model.ReadingTime;
				article.Content = model.Content;
				article.Image = model.Image;
				article.BlogArticleCategoryId = model.BlogArticleCategoryId;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<BlogArticleFormModel?> GetArticleFormModelByIdAsync(int articleId)
        {
            var article = await repository.AllReadOnly<BlogArticle>()
                            .Where(r => r.Id == articleId)
                            .Select(r => new BlogArticleFormModel()
                            {
                                Title = r.Title,
								PublicationDateDT = r.PublicationDate,
								ReadingTime = r.ReadingTime,
								Content = r.Content,
								Image = r.Image,
								BlogArticleCategoryId = r.BlogArticleCategoryId
                            })
                            .FirstOrDefaultAsync();

            if (article != null)
            {
                article.Categories = await AllBlogCategoriesAsync();
            }

            return article;
        }
    }
}
