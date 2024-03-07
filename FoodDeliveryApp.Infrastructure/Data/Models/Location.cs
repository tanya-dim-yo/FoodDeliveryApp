using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FoodDeliveryApp.Infrastructure.Constants.ValidationConstants.LocationValidationConstants;

namespace FoodDeliveryApp.Infrastructure.Data.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        [MaxLength(LocationAddressMaxLength)]
        public string Address { get; set; } = string.Empty;

        [Required]
        public DateTime Timestamp { get; set; }
    }
}