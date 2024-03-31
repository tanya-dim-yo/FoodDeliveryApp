using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Infrastructure.Migrations
{
    public partial class ImagePathFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "~/images/Zakuska/Mikel_Coffee/Cappuccino_Mocha.png");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "~/images/Zakuska/Mikel_Coffee/Biscuit_Cake.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
