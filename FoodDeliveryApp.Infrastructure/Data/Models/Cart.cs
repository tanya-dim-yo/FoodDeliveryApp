using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public virtual IdentityUser User { get; set; } = null!;

        public virtual List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}