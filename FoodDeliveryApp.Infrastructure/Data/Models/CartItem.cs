using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class CartItem
    {
        public CartItem(int itemId, int quantity)
        {
            ItemId = itemId;
            Quantity = quantity;
        }

        [Key]
        public int Id { get; set; }


        [Required]
        public int Quantity { get; set; }

        [Required]
        public int ItemId { get; set; }

        [ForeignKey(nameof(ItemId))]
        public virtual Item Item { get; set; }

        [Required]
        public int CartId { get; set; }

        [ForeignKey(nameof(CartId))]
        public virtual Cart Cart { get; set; }
    }
}