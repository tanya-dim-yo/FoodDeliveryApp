using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Infrastructure.Migrations
{
    public partial class ItemReviewSetter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemReviews_Items_ItemId",
                table: "ItemReviews");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "ItemReviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemReviews_Items_ItemId",
                table: "ItemReviews",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemReviews_Items_ItemId",
                table: "ItemReviews");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "ItemReviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemReviews_Items_ItemId",
                table: "ItemReviews",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }
    }
}
