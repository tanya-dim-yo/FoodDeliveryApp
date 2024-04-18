using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Infrastructure.Migrations
{
    public partial class CreatedDatabaseAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fbf0d65-12cc-4022-aaeb-adb20a20459d", "AQAAAAEAACcQAAAAEEpRWzslzHAbM/wLgbmZ9zk3ZST14hs7dt6InwmQd9Qfe+C3KBs/e3hwJP+cV9Folw==", "b44dc259-3bc1-41a7-8d3d-364978a29a8b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec6b753c-96eb-4fd3-a6b4-5b4cadb367ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c5d4122-e207-4375-a7fd-9c7681f87f4f", "AQAAAAEAACcQAAAAEFiHoO3nxfn2ACKcRzSCEWrOkDwoRCdu8FbzCL89X5kzQjiXWLdpNBXH/TEYDz5iuQ==", "2eaf809b-d806-450a-aec0-903a37ab1519" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
