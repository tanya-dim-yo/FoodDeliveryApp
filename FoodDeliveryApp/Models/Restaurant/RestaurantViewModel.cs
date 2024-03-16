using FoodDeliveryApp.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryApp.Models.Restaurant
{
    public class RestaurantViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public decimal ServiceFee { get; set; }

        public string DeliveryTime { get; set; } = string.Empty;

        public string BackgroundImage { get; set; } = string.Empty;

        public double AverageRating { get; private set; }

        public int TotalReviews { get; private set; }
    }
}