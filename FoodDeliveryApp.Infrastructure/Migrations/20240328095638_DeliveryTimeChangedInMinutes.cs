using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Infrastructure.Migrations
{
    public partial class DeliveryTimeChangedInMinutes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryTime",
                table: "Restaurants");

            migrationBuilder.AddColumn<int>(
                name: "MaxDeliveryTimeInMinutes",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinDeliveryTimeInMinutes",
                table: "Restaurants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MaxDeliveryTimeInMinutes", "MinDeliveryTimeInMinutes" },
                values: new object[] { 40, 30 });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MaxDeliveryTimeInMinutes", "MinDeliveryTimeInMinutes" },
                values: new object[] { 60, 50 });

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "MaxDeliveryTimeInMinutes", "MinDeliveryTimeInMinutes" },
                values: new object[] { 50, 40 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxDeliveryTimeInMinutes",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "MinDeliveryTimeInMinutes",
                table: "Restaurants");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryTime",
                table: "Restaurants",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1,
                column: "DeliveryTime",
                value: "30-40 мин.");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2,
                column: "DeliveryTime",
                value: "50-60 мин.");

            migrationBuilder.UpdateData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3,
                column: "DeliveryTime",
                value: "40-50 мин.");
        }
    }
}
