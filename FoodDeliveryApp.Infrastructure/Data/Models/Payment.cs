using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Tax { get; set; }

        [Required]
        public decimal SubTotal { get; set; }

        [Required]
        public decimal PaymentTotal { get; set; }

        [Required]
        public string Status { get; set; } = string.Empty;

        [Required]
        public int CartId { get; set; }

        [ForeignKey(nameof(CartId))]
        public virtual Cart Cart { get; set; } = null!;
    }
}