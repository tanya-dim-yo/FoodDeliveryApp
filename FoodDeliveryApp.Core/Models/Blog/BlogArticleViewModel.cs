namespace FoodDeliveryApp.Core.Models.Blog
{
	public class BlogArticleViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string ImageUrl { get; set; } = string.Empty;
		public string PublicationDate { get; set; } = string.Empty;
		public string Resume { get; set; } = string.Empty;
		public string Category { get; set; } = string.Empty;
	}
}