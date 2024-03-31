using System.ComponentModel.DataAnnotations;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.ItemSpicyCategoryValidationConstants;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class ItemSpicyCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ItemSpicyCategoryTitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        public virtual IEnumerable<Item> Items { get; set; } = null!;
    }
}