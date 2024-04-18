using FoodDeliveryApp.Core.Models.Blog;
using FoodDeliveryApp.Infrastructure.Data.Models;

namespace System.Linq
{
	public static class IQuerableBlogArticleExtension
	{
		public static IQueryable<BlogArticleViewModel> ProjectToBlogArticleViewModel(this IQueryable<BlogArticle> articles)
		{
			return articles
				.Select(a => new BlogArticleViewModel
				{
					Id = a.Id,
					Title = a.Title,
					ImageUrl = a.Image,
					PublicationDate = a.PublicationDate.ToString("d"),
					Resume = (a.Content.Length > 90) ? a.Content.Substring(0, 90) + "..." : a.Content
				});
		}
	}
}
