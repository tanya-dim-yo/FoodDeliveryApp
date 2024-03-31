using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Infrastructure.Migrations
{
    public partial class InitialItemSpicyCategoriesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ItemSpicyCategories",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Не лютиво" },
                    { 2, "Леко лютиво" },
                    { 3, "Средно лютиво" },
                    { 4, "Много лютиво" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemSpicyCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ItemSpicyCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ItemSpicyCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ItemSpicyCategories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
