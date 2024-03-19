using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.RestaurantValidationConstants;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(RestaurantTitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(RestaurantAddressMaxLength)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(RestaurantCityMaxLength)]
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
        [Column(TypeName = "decimal(18,2)")]
        public decimal ServiceFee { get; set; }

        [Required]
        [MaxLength(RestaurantDeliveryTimeMaxLength)]
        public string DeliveryTime { get; set; } = string.Empty;

        [Required]
        [MaxLength(RestaurantBackgroundImageMaxLength)]
        public string BackgroundImage { get; set; } = string.Empty;

        [Required]
        public int RestaurantCategoryId { get; set; }

        [ForeignKey(nameof(RestaurantCategoryId))]
        public virtual RestaurantCategory RestaurantCategory { get; set; } = null!;

        [Required]
        public double AverageRating { get; set; }

        [Required]
        public int TotalReviews { get; set; }

        public virtual IEnumerable<Item> Items { get; set; } = new List<Item>();

		public void UpdateRating(double newRating)
		{
			AverageRating = (AverageRating * TotalReviews + newRating) / (TotalReviews + 1);
			TotalReviews++;
		}
	}
}