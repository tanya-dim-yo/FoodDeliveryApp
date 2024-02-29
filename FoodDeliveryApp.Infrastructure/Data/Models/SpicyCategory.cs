using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class SpicyCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
    }
}