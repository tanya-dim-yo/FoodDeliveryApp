using System.ComponentModel.DataAnnotations;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.BlogCategoryValidationConstants;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class BlogCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(BlogCategoryTitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        public virtual IEnumerable<BlogArticle> BlogArticles { get; set; } = null!;
    }
}