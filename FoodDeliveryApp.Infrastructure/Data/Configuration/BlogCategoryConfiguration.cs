using FoodDeliveryApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodDeliveryApp.Infrastructure.Data.Configuration
{
	public class BlogArticleCategoryConfiguration : IEntityTypeConfiguration<BlogArticleCategory>
    {
        private BlogArticleCategory[] initialBlogArticleCategories = new BlogArticleCategory[]
        {
            new BlogArticleCategory() { Id = 1, Title = "Здравословно хранене" },
            new BlogArticleCategory() { Id = 2, Title = "Суперхрани" },
            new BlogArticleCategory() { Id = 3, Title = "Хранене и възраст" }
        };

        public void Configure(EntityTypeBuilder<BlogArticleCategory> builder)
        {
            builder.HasData(initialBlogArticleCategories);
        }
    }
}