using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Infrastructure.Migrations
{
    public partial class PriceRemovedFromCartItemEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "CartItems");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9e8b039-26c3-4a70-bbf8-3c06897c3f0e", "AQAAAAEAACcQAAAAEKqKCEhs8XC8EAmaj09uRRpCnGysTbOT1d3eRvwcCpCYSQNLnuWuZ0Lo2D5Jlfo6nQ==", "d107f1fa-7f7b-408a-bd43-e9b56e9e2ff1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec6b753c-96eb-4fd3-a6b4-5b4cadb367ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee20f7f6-bbbe-44e5-a315-bf676528da43", "AQAAAAEAACcQAAAAEA+z4PPldgcKG65FAPUSEHaUGtmT2saNhwl1gnrkhMUDorJwhrOophIMXFS4GlZSZg==", "f2f2b46c-d4bc-4b8e-b46b-f01ca47d00a7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "CartItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00a4ff4c-3f8e-4d55-94a5-58bd026e347c", "AQAAAAEAACcQAAAAEELRBnAGYT5p7SaS9lWCuq4b+zFjzxTlTyEJMUIwelX0or+BYLCG3AAuf+IkLETu6Q==", "4b5ecde4-ae94-41f9-85ec-a19565c57c11" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec6b753c-96eb-4fd3-a6b4-5b4cadb367ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "992cb2cc-2406-4397-b1c1-435fe1884761", "AQAAAAEAACcQAAAAEMLfsMMTGom8kBv8BVfzufkojINQQ7G2Pwvi8v2hXq6+5+rSpwk4jbmC7c02QDjpgQ==", "56a2cd52-a06e-45a9-aef9-487e96a3aa6e" });
        }
    }
}
