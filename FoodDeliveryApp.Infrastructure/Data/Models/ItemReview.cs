using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class ItemReview
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserID { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public double AverageRating { get; private set; }

        [Required]
        public string Review { get; set; } = string.Empty;
    }
}