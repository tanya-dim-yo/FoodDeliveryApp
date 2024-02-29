using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class Coupon
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Code { get; set; } = string.Empty;

        [Required]
        public decimal Discount { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}