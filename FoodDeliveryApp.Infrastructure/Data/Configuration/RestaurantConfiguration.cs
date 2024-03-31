using FoodDeliveryApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodDeliveryApp.Infrastructure.Data.Configuration
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        private Restaurant[] initialRestaurants = new Restaurant[]
        {
            new Restaurant()
            { 
                Id = 1,
                Title = "Burger King",
                Address = "bul. \"Sitnyakovo\", 48, 1505, Oborishte, Sofia, Bulgaria",
                CityId = 1,
                OpeningHour = new DateTime(1900, 1, 1, 10, 0, 0),
                ClosingHour = new DateTime(1900, 1, 1, 21, 0, 0),
                Latitude = 42.691631,
                Longitude = 23.353460,
                ServiceFee = 3.99m,
                MinDeliveryTimeInMinutes = 30,
				MaxDeliveryTimeInMinutes = 40,
				ImageURL = "~/images/Amerikanska/BurgerKing/BurgerKingBackground.jpg",
                RestaurantCategoryId = 2,
            },

            new Restaurant()
            {
                Id = 2,
                Title = "Tarator",
                Address = "\"Hristo Botev\" Blvd 117, 1303 Sofia Center, Sofia, Bulgaria",
                CityId = 1,
                OpeningHour = new DateTime(1900, 1, 1, 10, 30, 0),
                ClosingHour = new DateTime(1900, 1, 1, 18, 0, 0),
                Latitude = 42.703980,
                Longitude = 23.316980,
                ServiceFee = 4.99m,
				MinDeliveryTimeInMinutes = 50,
				MaxDeliveryTimeInMinutes = 60,
				ImageURL = "~/images/Mestna_hrana/Tarator/TaratorBackground.jpg",
                RestaurantCategoryId = 13,
            },

            new Restaurant()
            {
                Id = 3,
                Title = "Mikel Coffee",
                Address = "bulevard \"Cherni vrah\" 100, 1407 Krastova vada, Sofia, Bulgaria",
                CityId = 1,
                OpeningHour = new DateTime(1900, 1, 1, 8, 0, 0),
                ClosingHour = new DateTime(1900, 1, 1, 22, 0, 0),
                Latitude = 42.653650,
                Longitude = 23.315410,
                ServiceFee = 1.99m,
				MinDeliveryTimeInMinutes = 40,
				MaxDeliveryTimeInMinutes = 50,
				ImageURL = "~/images/Zakuska/Mikel_Coffee/MikelCoffeeBackground.jpg",
				RestaurantCategoryId = 7,
            },
        };

        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasData(initialRestaurants);
        }
    }
}