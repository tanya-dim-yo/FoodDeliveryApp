using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Infrastructure.Migrations
{
    public partial class SeedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67c3f9d9-5952-484b-b058-2917ad0c6a76", "Tanya", "Yordanova", "AQAAAAEAACcQAAAAEA2s29iWyG/9+LyNGCv6cB0aP1uIdEmYOPRRSmQ343ShBkdNtmcKatkNoX3AHdCcDQ==", "fd9b954c-0355-4fa3-8aa7-6cbf9b95786a" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ec6b753c-96eb-4fd3-a6b4-5b4cadb367ac", 0, "2b6ea95c-9c13-42ab-ba9d-f7a7ed24fc5a", "admin@mail.com", false, "Tanya", "Stoyanova", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEBLMkgfzl5hNViobxwkLyKLLkVMT1DTi6NrOAbkAJ7wYyaUNnB4K7cV6mcx22ky+IQ==", null, false, "9af64977-97c6-46cc-9f39-a44c8e150e2e", false, "admin@mail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec6b753c-96eb-4fd3-a6b4-5b4cadb367ac");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0bc4885a-a08b-4d37-9507-6c06a7ecf735", "", "", "AQAAAAEAACcQAAAAEFPGYO1Zbt05OwtE2z1+8lXhYT1EXug/NXK7uCTuJxAflFjXJeLChUz1vkBBqogSeA==", "0754a75d-b810-474d-bd78-9a73a7fb1bd2" });
        }
    }
}
