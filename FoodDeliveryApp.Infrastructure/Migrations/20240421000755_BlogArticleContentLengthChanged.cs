using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Infrastructure.Migrations
{
    public partial class BlogArticleContentLengthChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1eb1303f-8b62-4e67-8e88-954fcebf91d9", "AQAAAAEAACcQAAAAEIKZD6aaU6hABOF/7C1+W9EkSipP2FD7Yk+nxHuEjPY0TuJCl+IbYY2n1rh7PpiAGw==", "5663c8ee-4821-477a-8c3e-1ef908a4bdcd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec6b753c-96eb-4fd3-a6b4-5b4cadb367ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4dc1c1f-6524-4176-80ae-ebd4906632b5", "AQAAAAEAACcQAAAAEKy+GjDxg5/iKsbpHxiYTJ8gkAEuhbv55vLaam1e3e8Va3W7Kl4czJaMx1wWUZQE0Q==", "fedf7af4-c3c0-43d1-aacb-b88b30805d83" });

            migrationBuilder.UpdateData(
                table: "BlogArticles",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationDate",
                value: new DateTime(2024, 1, 21, 0, 7, 55, 123, DateTimeKind.Utc).AddTicks(8013));

            migrationBuilder.UpdateData(
                table: "BlogArticles",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicationDate",
                value: new DateTime(2024, 3, 7, 0, 7, 55, 123, DateTimeKind.Utc).AddTicks(8066));

            migrationBuilder.UpdateData(
                table: "BlogArticles",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicationDate",
                value: new DateTime(2023, 11, 21, 0, 7, 55, 123, DateTimeKind.Utc).AddTicks(8072));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbed58fc-f89c-4f01-91be-2b7d81f495e3", "AQAAAAEAACcQAAAAEB7LPDc6mzGGa3NGzUMkgrH4/COYzVyrRl4rYeR9ta6OhctmdaL4VKFBEYzr346PiQ==", "249cc4d7-5244-4ca5-8ab3-a197ffec913f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec6b753c-96eb-4fd3-a6b4-5b4cadb367ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87b11324-491e-4a17-bfda-9c7b4a0eb3f3", "AQAAAAEAACcQAAAAEPJoyeA/KugZ6Fm9sHhT75fvxu6J5pg2rt4rEPTGDj8o6Cj+q8eOmPMsQeBxQkbYIA==", "0114df14-3f76-4321-97ee-6340fc94aad4" });

            migrationBuilder.UpdateData(
                table: "BlogArticles",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationDate",
                value: new DateTime(2024, 1, 18, 8, 18, 28, 440, DateTimeKind.Utc).AddTicks(1092));

            migrationBuilder.UpdateData(
                table: "BlogArticles",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicationDate",
                value: new DateTime(2024, 3, 4, 8, 18, 28, 440, DateTimeKind.Utc).AddTicks(1158));

            migrationBuilder.UpdateData(
                table: "BlogArticles",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicationDate",
                value: new DateTime(2023, 11, 18, 8, 18, 28, 440, DateTimeKind.Utc).AddTicks(1164));
        }
    }
}
