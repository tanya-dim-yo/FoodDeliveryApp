using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class ItemAddOn
    {
        [Required]
        public int ItemId { get; set; }

        [ForeignKey(nameof(ItemId))]
        public virtual Item Item { get; set; } = null!;

        [Required]
        public int AddOnId { get; set; }

        [ForeignKey(nameof(AddOnId))]
        public virtual AddOn AddOn { get; set; } = null!;
    }
}