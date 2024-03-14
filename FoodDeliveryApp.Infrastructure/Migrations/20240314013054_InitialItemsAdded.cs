using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Infrastructure.Migrations
{
    public partial class InitialItemsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "AverageRating", "Description", "Image", "IsFavourite", "IsVeggie", "ItemCategoryId", "Price", "RestaurantId", "SpicyCategoryId", "Title", "TotalReviews" },
                values: new object[,]
                {
                    { 1, 0.0, "4\" питка, криспи чикън кюфте, майонеза, домати, айсберг", "../../../FoodDeliveryApp/wwwroot/images/Amerikanska/BurgerKing/BurgerCrispyChicken.jpg", false, false, 1, 9.95m, 1, 1, "Бургер Crispy Chicken (183г)", 0 },
                    { 2, 0.0, "4 1/2\" питка, тендър крисп, майонеза, домати, айсберг", "../../../FoodDeliveryApp/wwwroot/images/Amerikanska/BurgerKing/BurgerTenderCrisp.jpg", false, false, 1, 12.65m, 1, 1, "Бургер Tender Crisp (283г)", 0 },
                    { 3, 0.0, "пресни домати, босилек и сирене Моцарела", "../../../FoodDeliveryApp/wwwroot/images/Mestna_hrana/Tarator/Salata_Kapreze.jpg", false, false, 2, 6.76m, 2, 1, "Салата Капрезе (300г)", 0 },
                    { 4, 0.0, "Традиционна българска мусака", "../../../FoodDeliveryApp/wwwroot/images/Mestna_hrana/Tarator/Musaka.jpg", false, false, 3, 11.20m, 2, 1, "Мусака (350г)", 0 },
                    { 5, 0.0, "Капучино с топка сладолед Mока", "../../../FoodDeliveryApp/wwwroot/images/Zakuska/Mikel_Coffee/Cappuccino_Mocha.jpg", false, false, 4, 6.90m, 3, 1, "Капучино Мока", 0 },
                    { 6, 0.0, "Класическа бисквитена торта", "../../../FoodDeliveryApp/wwwroot/images/Zakuska/Mikel_Coffee/Biscuit_Cake.jpg", false, false, 5, 7.40m, 3, 1, "Бисквитена торта - Biscuit cake", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
