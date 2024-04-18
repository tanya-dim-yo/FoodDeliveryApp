using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Infrastructure.Migrations
{
    public partial class InitialBlogCategoriesSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9252d48e-ee15-4eb7-92d8-11e4b011226b", "AQAAAAEAACcQAAAAEJsB4f+CbGmhPGRaRjWwek/PyCg1RoNuz93I11lC95ROpphNXIJOYbTeSa8fSm9blA==", "b511a761-c290-485a-b555-45af8712f199" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec6b753c-96eb-4fd3-a6b4-5b4cadb367ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50eec863-e575-44e0-8d0f-ada76120db3b", "AQAAAAEAACcQAAAAELhOHOVYyv8f0/RUcgXhfX/E4p/cmeUnIuehZ2Ma0WIzXVlrLn/QLdkA90XpKHSxkg==", "e6739262-5048-4a6b-87dc-3e11e48bb056" });

            migrationBuilder.InsertData(
                table: "BlogArticleCategories",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Здравословно хранене" },
                    { 2, "Суперхрани" },
                    { 3, "Хранене и възраст" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogArticleCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogArticleCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogArticleCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a092320-36a4-42ec-a960-bb1acdc76f1f", "AQAAAAEAACcQAAAAEJOEodkimp0jnpDna2aXf/MrJKDdzuF74xji4LwEBwCdq08JK+iMq60YzMYegh0MrA==", "b01a2efc-bd52-4e5d-9c77-246ff5fc7d36" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec6b753c-96eb-4fd3-a6b4-5b4cadb367ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a998ab8-bb22-44fc-b5de-b2759e026dab", "AQAAAAEAACcQAAAAEAiHyyBqnIU4hx9zfNLw/kwVbQ8WKAI+sehBDg2I3h+aOYM2/G+qeySAhqrh0hX+RQ==", "f5cd3668-93e6-4b25-8258-6bfdd83bdef4" });
        }
    }
}
