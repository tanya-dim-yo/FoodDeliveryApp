using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Infrastructure.Migrations
{
    public partial class ReservationEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5f7b994-c510-41eb-895b-cfb31a70d14e", "AQAAAAEAACcQAAAAEBU/Bb0Oa68qUd10jcxix2MQ9aWOP/BabR+gI5jKFZD+oljDR+dDT3IbDUFULGYULw==", "8dedb34d-b229-440b-aa14-69dd30f83f0e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec6b753c-96eb-4fd3-a6b4-5b4cadb367ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3a0adfa-3de1-4c79-a562-8f05fd47c969", "AQAAAAEAACcQAAAAEE4Buts8/5DFMleo/N50c3r+c/lDr79NAeOQeXRxpNMfM7+/4oQSYghfppNKw777Pw==", "c38f983e-2a9e-4205-bbe1-c16854bdd899" });

            migrationBuilder.UpdateData(
                table: "BlogArticles",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationDate",
                value: new DateTime(2024, 1, 22, 11, 38, 41, 144, DateTimeKind.Utc).AddTicks(9133));

            migrationBuilder.UpdateData(
                table: "BlogArticles",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicationDate",
                value: new DateTime(2024, 3, 8, 11, 38, 41, 144, DateTimeKind.Utc).AddTicks(9182));

            migrationBuilder.UpdateData(
                table: "BlogArticles",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicationDate",
                value: new DateTime(2023, 11, 22, 11, 38, 41, 144, DateTimeKind.Utc).AddTicks(9187));

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RestaurantId",
                table: "Reservations",
                column: "RestaurantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

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
    }
}
