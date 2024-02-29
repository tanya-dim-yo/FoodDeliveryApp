using System.ComponentModel.DataAnnotations;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.ItemCategoryValidationConstants;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class ItemCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ItemCategoryNameMaxLength)]
        public string Title { get; set; } = string.Empty;

        public virtual IEnumerable<Item> Items { get; set; } = new List<Item>();
    }
}