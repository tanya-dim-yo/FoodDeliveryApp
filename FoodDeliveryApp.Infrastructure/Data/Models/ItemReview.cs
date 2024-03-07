using System.ComponentModel.DataAnnotations;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.ItemReviewValidationConstants;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.UserIdValidationConstants;


namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class ItemReview
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(UserIdMaxLength)]
        public string UserID { get; set; } = string.Empty;

        [Required]
        [MaxLength(ItemReviewEmailMaxLength)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public double AverageRating { get; private set; }

        [Required]
        [MaxLength(ItemReviewMaxLength)]
        public string Review { get; set; } = string.Empty;
    }
}