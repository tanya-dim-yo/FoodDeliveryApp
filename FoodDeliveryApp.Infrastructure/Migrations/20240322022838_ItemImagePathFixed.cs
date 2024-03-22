using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Infrastructure.Migrations
{
    public partial class ItemImagePathFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "~/images/Amerikanska/BurgerKing/BurgerTenderCrisp.jpg");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "~/images/Mestna_hrana/Tarator/Salata_Kapreze.jpg");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "~/images/Mestna_hrana/Tarator/Musaka.jpg");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "~/images/Zakuska/Mikel_Coffee/Cappuccino_Mocha.jpg");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "~/images/Zakuska/Mikel_Coffee/Biscuit_Cake.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "~/FoodDeliveryApp/wwwroot/images/Amerikanska/BurgerKing/BurgerTenderCrisp.jpg");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "~/FoodDeliveryApp/wwwroot/images/Mestna_hrana/Tarator/Salata_Kapreze.jpg");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "~/FoodDeliveryApp/wwwroot/images/Mestna_hrana/Tarator/Musaka.jpg");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "~/FoodDeliveryApp/wwwroot/images/Zakuska/Mikel_Coffee/Cappuccino_Mocha.jpg");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "~/FoodDeliveryApp/wwwroot/images/Zakuska/Mikel_Coffee/Biscuit_Cake.jpg");
        }
    }
}
