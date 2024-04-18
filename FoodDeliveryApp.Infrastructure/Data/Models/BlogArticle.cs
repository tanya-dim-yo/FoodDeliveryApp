using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.BlogArticleValidationConstants;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class BlogArticle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(BlogArticleTitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public DateTime PublicationDate { get; set; }

        [Required]
        public int ReadingTime { get; set; }

        [Required]
        public int Likes { get; set; }

        [Required]
        [MaxLength(BlogArticleContentMaxLength)]
        public string Content { get; set; } = string.Empty;

        [Required]
        [MaxLength(BlogArticleImageMaxLength)]
        public string Image { get; set; } = string.Empty;

        [Required]
        public int BlogArticleCategoryId { get; set; }

        [ForeignKey(nameof(BlogArticleCategoryId))]
        public virtual BlogArticleCategory BlogArticleCategory { get; set; } = null!;

        public virtual IEnumerable<BlogArticleComment> BlogArticleComments { get; set; } = new List<BlogArticleComment>();
    }
}