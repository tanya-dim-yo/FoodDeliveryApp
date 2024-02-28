using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class SpicyCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}