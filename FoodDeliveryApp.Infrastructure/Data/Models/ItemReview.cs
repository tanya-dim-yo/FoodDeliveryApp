using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.ItemReviewValidationConstants;


namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class ItemReview
    {
        [Key]
        public int Id { get; set; }

		[Required]
		public string UserId { get; set; } = string.Empty;

		[ForeignKey(nameof(UserId))]
		public virtual ApplicationUser User { get; set; } = null!;

		[Required]
        [MaxLength(ItemReviewEmailMaxLength)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public int ItemId { get; set; }

        [ForeignKey(nameof(ItemId))]
        public virtual Item Item { get; set; } = null!;

        [Required]
        public double AverageRating { get; set; }

        [Required]
        [MaxLength(ItemReviewMaxLength)]
        public string Review { get; set; } = string.Empty;
    }
}