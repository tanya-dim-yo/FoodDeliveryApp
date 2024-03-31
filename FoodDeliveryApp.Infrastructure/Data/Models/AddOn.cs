using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.AddOnValidationConstants;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class AddOn
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(AddOnTitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(AddOnImageMaxLength)]
        public string Image { get; set; } = string.Empty;

        public virtual IEnumerable<ItemAddOn> ItemsAddOns { get; set; } = new List<ItemAddOn>();
    }
}