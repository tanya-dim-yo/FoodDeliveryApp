using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.CartValidationConstants;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
	public class Cart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        [MaxLength(UserIdMaxLength)]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = null!;

        public virtual IEnumerable<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}