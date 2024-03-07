using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.BlogCommentValidationConstants;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class BlogComment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public virtual IdentityUser User { get; set; } = null!;

        [Required]
        [MaxLength(BlogCommentMaxLength)]
        public string Comment { get; set; } = string.Empty;
    }
}