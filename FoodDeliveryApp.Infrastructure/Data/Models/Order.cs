using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public virtual IdentityUser User { get; set; } = null!;

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        public bool IsNowToBeDelivered { get; set; }

        [Required]
        public DateTime TimeOfDelivery { get; set; }

        [Required]
        public DateTime DateOfDelivery { get; set; }

        [Required]
        public decimal SubTotal { get; set; }

        [Required]
        public decimal ServiceFee { get; set; }

        [Required]
        public decimal Tax { get; set; }

        [Required]
        public decimal OrderTotal { get; set; }

        [Required]
        public bool IsPaidOnDelivery { get; set; }

        [Required]
        public int CartId { get; set; }

        [ForeignKey(nameof(CartId))]
        public virtual Cart Cart { get; set; } = null!;

        public string? CouponId { get; set; }

        [ForeignKey(nameof(CouponId))]
        public virtual Coupon Coupon { get; set; } = null!;
    }
}