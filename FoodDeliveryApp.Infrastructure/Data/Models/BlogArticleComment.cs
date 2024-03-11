using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.BlogArticleCommentValidationConstants;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class BlogArticleComment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public virtual IdentityUser User { get; set; } = null!;

        [Required]
        [MaxLength(BlogArticleCommentMaxLength)]
        public string Comment { get; set; } = string.Empty;
    }
}