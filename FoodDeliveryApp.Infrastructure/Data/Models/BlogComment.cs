using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.BlogCommentValidationConstants;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.UserIdValidationConstants;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class BlogComment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(UserIdMaxLength)]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public virtual IdentityUser User { get; set; } = null!;

        [Required]
        [MaxLength(BlogCommentMaxLength)]
        public string Comment { get; set; } = string.Empty;
    }
}