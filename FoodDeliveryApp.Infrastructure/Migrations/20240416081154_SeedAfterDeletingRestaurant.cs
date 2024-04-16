using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Infrastructure.Migrations
{
    public partial class SeedAfterDeletingRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb06db77-e493-4ff8-9976-da5bf035e8de", "AQAAAAEAACcQAAAAECh4Exhpno7OEmv5lGKCJ5p1pH3R4HVLhmBgu1m7l2nllTv7R6yiGu+I4bR6QeHeXA==", "2b7a9ff8-960b-4f46-817e-a5c6b54f5d43" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec6b753c-96eb-4fd3-a6b4-5b4cadb367ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "806c1725-ea90-4982-994b-af6d781ea8df", "AQAAAAEAACcQAAAAEPeIaMNzKEECvtOGA6gsKYYX1FHNWLEORXo4GPtAAcoERU68I1WqNULt9lo9RoTpoA==", "307f9cd9-a6ef-4a2e-a96a-3b6510cfdb99" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67c3f9d9-5952-484b-b058-2917ad0c6a76", "AQAAAAEAACcQAAAAEA2s29iWyG/9+LyNGCv6cB0aP1uIdEmYOPRRSmQ343ShBkdNtmcKatkNoX3AHdCcDQ==", "fd9b954c-0355-4fa3-8aa7-6cbf9b95786a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec6b753c-96eb-4fd3-a6b4-5b4cadb367ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b6ea95c-9c13-42ab-ba9d-f7a7ed24fc5a", "AQAAAAEAACcQAAAAEBLMkgfzl5hNViobxwkLyKLLkVMT1DTi6NrOAbkAJ7wYyaUNnB4K7cV6mcx22ky+IQ==", "9af64977-97c6-46cc-9f39-a44c8e150e2e" });
        }
    }
}
