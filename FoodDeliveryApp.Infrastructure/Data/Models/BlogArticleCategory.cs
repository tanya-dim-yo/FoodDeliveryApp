using System.ComponentModel.DataAnnotations;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.BlogArticleCategoryValidationConstants;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class BlogArticleCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(BlogArticleCategoryTitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        public virtual IEnumerable<BlogArticle> BlogArticles { get; set; } = null!;
    }
}