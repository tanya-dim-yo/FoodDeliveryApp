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
        public string ApplicationUserId { get; set; } = string.Empty;

        [Required]
        public virtual IdentityUser ApplicationUser { get; set; } = null!;

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        public bool IsNowToBeDelivered { get; set; }

        public DateTime TimeOfDelivery { get; set; }

        public DateTime DateOfDelivery { get; set; }

        [Required]
        public decimal SubTotal { get; set; }

        [Required]
        public decimal OrderTotal { get; set; }
        
        public string CouponId { get; set; } = string.Empty;

        [ForeignKey(nameof(CouponId))]
        public virtual Coupon Coupon { get; set; } = null!;
    }
}