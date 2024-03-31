using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Infrastructure.Migrations
{
    public partial class InitialRestaurantsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Restaurants");

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "AverageRating", "BackgroundImage", "City", "ClosingHour", "DeliveryTime", "Latitude", "Longitude", "OpeningHour", "RestaurantCategoryId", "ServiceFee", "Title", "TotalReviews" },
                values: new object[] { 1, "bul. \"Sitnyakovo\", 48, 1505, Oborishte, Sofia, Bulgaria", 0.0, "../../../FoodDeliveryApp/wwwroot/images/Amerikanska/BurgerKing/BurgerKingBackground.jfif", "Sofia", new DateTime(1900, 1, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), "30-40 мин.", 42.691631000000001, 23.353459999999998, new DateTime(1900, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 2, 3.99m, "Burger King", 0 });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "AverageRating", "BackgroundImage", "City", "ClosingHour", "DeliveryTime", "Latitude", "Longitude", "OpeningHour", "RestaurantCategoryId", "ServiceFee", "Title", "TotalReviews" },
                values: new object[] { 2, "\"Hristo Botev\" Blvd 117, 1303 Sofia Center, Sofia, Bulgaria", 0.0, "../../../FoodDeliveryApp/wwwroot/images/Mestna_hrana/Tarator/TaratorBackground.jpg", "Sofia", new DateTime(1900, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), "50-60 мин.", 42.703980000000001, 23.316980000000001, new DateTime(1900, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 13, 4.99m, "Tarator", 0 });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "AverageRating", "BackgroundImage", "City", "ClosingHour", "DeliveryTime", "Latitude", "Longitude", "OpeningHour", "RestaurantCategoryId", "ServiceFee", "Title", "TotalReviews" },
                values: new object[] { 3, "bulevard \"Cherni vrah\" 100, 1407 Krastova vada, Sofia, Bulgaria", 0.0, "../../../FoodDeliveryApp/wwwroot/images/Zakuska/Mikel_Coffee/MikelCoffeeBackground.jpg", "Sofia", new DateTime(1900, 1, 1, 22, 0, 0, 0, DateTimeKind.Unspecified), "40-50 мин.", 42.653649999999999, 23.31541, new DateTime(1900, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 7, 1.99m, "Mikel Coffee", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Restaurants",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
