using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class AddOn
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        public virtual IEnumerable<ItemAddOn> ItemsAddOns { get; set; } = new List<ItemAddOn>();
    }
}