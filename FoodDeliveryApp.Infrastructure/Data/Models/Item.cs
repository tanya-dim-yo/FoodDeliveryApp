using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        public double AverageRating { get; private set; }

        public int TotalReviews { get; private set; }

        [Required]
        public bool isPreferred { get; set; }

        [Required]
        public int SpicyCategoryId { get; set; }

        [ForeignKey(nameof(SpicyCategoryId))]
        public virtual SpicyCategory SpicyCategory { get; set; } = null!;

        [Required]
        public bool isVeggie { get; set; }

        [Required]
        public int ItemCategoryId { get; set; }

        [ForeignKey(nameof(ItemCategoryId))]
        public virtual ItemCategory ItemCategory { get; set; } = null!;
    }
}