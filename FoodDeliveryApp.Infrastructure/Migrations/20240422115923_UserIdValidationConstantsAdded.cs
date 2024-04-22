using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodDeliveryApp.Infrastructure.Migrations
{
    public partial class UserIdValidationConstantsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Reservations");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Reservations",
                type: "nvarchar(600)",
                maxLength: 600,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Reservations",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Reservations",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74f7ed4d-2e71-41e1-904c-4c3ba7347a24", "AQAAAAEAACcQAAAAEFWWgUMk9XhC7HzvReEXt+UoBnDE0H3lW/FR1opZ52aeMTN43BG/puDtItQSy5ufSQ==", "0cd75441-3873-4e19-8704-f56d6cec51f8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec6b753c-96eb-4fd3-a6b4-5b4cadb367ac",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44970366-4781-4fb9-9e56-9648f21f403e", "AQAAAAEAACcQAAAAEFRul/7/nnX1yrAPquOJCZa9oaxJBrMMCPiQgNHxzarqvdUhlmTIY5REIwR95SD9Bg==", "7e3f78a4-e539-4a8d-9999-de7f25766287" });

            migrationBuilder.UpdateData(
                table: "BlogArticles",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationDate",
                value: new DateTime(2024, 1, 22, 11, 59, 22, 966, DateTimeKind.Utc).AddTicks(7047));

            migrationBuilder.UpdateData(
                table: "BlogArticles",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicationDate",
                value: new DateTime(2024, 3, 8, 11, 59, 22, 966, DateTimeKind.Utc).AddTicks(7098));

            migrationBuilder.UpdateData(
                table: "BlogArticles",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublicationDate",
                value: new DateTime(2023, 11, 22, 11, 59, 22, 966, DateTimeKind.Utc).AddTicks(7104));

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_UserId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reservations");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(600)",
                oldMaxLength: 600);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
        }
    }
}
