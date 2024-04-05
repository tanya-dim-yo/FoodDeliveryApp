using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.ItemValidationConstants;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ItemTitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(ItemDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public double AverageRating { get; set; }

        [Required]
        public int TotalReviews { get; set; }

        [Required]
        public bool IsFavourite { get; set; }

        [Required]
        public bool IsVeggie { get; set; }

        [Required]
        [MaxLength(ItemImageMaxLength)]
        public string ImageURL { get; set; } = string.Empty;

        [Required]
        public int ItemCategoryId { get; set; }

        [ForeignKey(nameof(ItemCategoryId))]
        public virtual ItemCategory ItemCategory { get; set; } = null!;

        [Required]
        public int RestaurantId { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurant Restaurant { get; set; } = null!;

        [Required]
        public int SpicyCategoryId { get; set; }

        [ForeignKey(nameof(SpicyCategoryId))]
        public virtual ItemSpicyCategory SpicyCategory { get; set; } = null!;

        public virtual IEnumerable<ItemReview> Reviews { get; set; } = new List<ItemReview>();

        public virtual IEnumerable<ItemAddOn> ItemsAddOns { get; set; } = new List<ItemAddOn>();
    }
}