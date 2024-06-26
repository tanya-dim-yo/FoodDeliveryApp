﻿using FoodDeliveryApp.Infrastructure.Data.Models;

namespace FoodDeliveryApp.Core.Models.Blog
{
	public class BlogArticleDetailsViewModel
	{
		public int Id { get; set; }

		public string Title { get; set; } = string.Empty;

		public string PublicationDate { get; set; } = string.Empty;

		public int ReadingTime { get; set; }

		public string Content { get; set; } = string.Empty;

		public string Image { get; set; } = string.Empty;

		public int CategoryId { get; set; }

		public string Category { get; set; } = string.Empty;

		public string FacebookUrl { get; set; } = string.Empty;

		public string TwitterUrl { get; set; } = string.Empty;

		public string LinkedInUrl { get; set; } = string.Empty;
	}
}