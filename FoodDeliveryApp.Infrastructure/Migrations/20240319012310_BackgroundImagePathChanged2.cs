using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Infrastructure.Migrations
{
    public partial class BackgroundImagePathChanged2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "BackgroundImage",
                value: "~/images/Amerikanska/BurgerKing/BurgerKingBackground.jfif");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "BackgroundImage",
                value: "~/images/Mestna_hrana/Tarator/TaratorBackground.jpg");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "BackgroundImage",
                value: "~/images/Zakuska/Mikel_Coffee/MikelCoffeeBackground.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "BackgroundImage",
                value: "/FoodDeliveryApp/wwwroot/images/Amerikanska/BurgerKing/BurgerKingBackground.jfif");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "BackgroundImage",
                value: "/FoodDeliveryApp/wwwroot/images/Mestna_hrana/Tarator/TaratorBackground.jpg");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "BackgroundImage",
                value: "/FoodDeliveryApp/wwwroot/images/Zakuska/Mikel_Coffee/MikelCoffeeBackground.jpg");
        }
    }
}
