using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Infrastructure.Migrations
{
    public partial class UserIdRemovedFromBlogArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogArticles_AspNetUsers_UserId",
                table: "BlogArticles");

            migrationBuilder.DropIndex(
                name: "IX_BlogArticles_UserId",
                table: "BlogArticles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BlogArticles");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BlogArticles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_BlogArticles_UserId",
                table: "BlogArticles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogArticles_AspNetUsers_UserId",
                table: "BlogArticles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
