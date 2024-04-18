using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Infrastructure.Migrations
{
    public partial class PendingMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
