using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public DateTime OpeningHour { get; set; }

        [Required]
        public DateTime ClosingHour { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public decimal ServiceFee { get; set; }

        [Required]
        public string DeliveryTime { get; set; } = string.Empty;

        [Required]
        public string Logo { get; set; } = string.Empty;

        [Required]
        public string BackgroundImage { get; set; } = string.Empty;

        [Required]
        public int RestaurantCategoryId { get; set; }

        [ForeignKey(nameof(RestaurantCategoryId))]
        public virtual RestaurantCategory RestaurantCategory { get; set; } = null!;

        public double AverageRating { get; private set; }

        public int TotalReviews { get; private set; }

        public virtual IEnumerable<Item> Items { get; set; } = new List<Item>();
    }
}