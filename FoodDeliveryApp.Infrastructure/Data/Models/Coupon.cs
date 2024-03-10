using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.CouponValidationConstants;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class Coupon
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CodeMaxLength)]
        public string Code { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}