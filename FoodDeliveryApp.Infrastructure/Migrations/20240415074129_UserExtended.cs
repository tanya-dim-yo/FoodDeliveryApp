using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Infrastructure.Migrations
{
    public partial class UserExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "ItemReviews");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ItemReviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0bc4885a-a08b-4d37-9507-6c06a7ecf735", "", "", "AQAAAAEAACcQAAAAEFPGYO1Zbt05OwtE2z1+8lXhYT1EXug/NXK7uCTuJxAflFjXJeLChUz1vkBBqogSeA==", "0754a75d-b810-474d-bd78-9a73a7fb1bd2" });

            migrationBuilder.CreateIndex(
                name: "IX_ItemReviews_UserId",
                table: "ItemReviews",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemReviews_AspNetUsers_UserId",
                table: "ItemReviews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemReviews_AspNetUsers_UserId",
                table: "ItemReviews");

            migrationBuilder.DropIndex(
                name: "IX_ItemReviews_UserId",
                table: "ItemReviews");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ItemReviews");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "ItemReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "890dd898-f326-4a32-a60e-81f42a9ec4e5", "AQAAAAEAACcQAAAAEOGuEPi3Tewd2j8Fbbhw7I2OxVtkd8rcjqW5trCb5IOd5687u6AQiIA3hdr+OQKomg==", "0ce8b867-873e-4915-9e9f-24f407d4372c" });
        }
    }
}
