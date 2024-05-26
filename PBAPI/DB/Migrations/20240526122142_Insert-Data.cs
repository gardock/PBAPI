using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class InsertData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "toDoListItems",
                columns: new[] { "Id", "CreateDate", "Description", "IsDeleted", "Order", "Status", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 26, 12, 21, 42, 273, DateTimeKind.Utc).AddTicks(2791), "To jest opis zadania numer jeden", false, (byte)1, 0, "Pierwsze zadanie" },
                    { 2, new DateTime(2024, 5, 26, 12, 21, 42, 273, DateTimeKind.Utc).AddTicks(2860), "To jest opis zadania numer dwa", true, (byte)1, 2, "Drugie zadanie" },
                    { 3, new DateTime(2024, 5, 26, 12, 21, 42, 273, DateTimeKind.Utc).AddTicks(2879), "To jest opis zadania numer trzy", false, (byte)2, 2, "Trzecie zadanie" },
                    { 4, new DateTime(2024, 5, 26, 12, 21, 42, 273, DateTimeKind.Utc).AddTicks(2935), "To jest opis zadania numer cztery", false, (byte)3, 2, "4 zadanie" },
                    { 5, new DateTime(2024, 5, 26, 12, 21, 42, 273, DateTimeKind.Utc).AddTicks(2947), "To jest opis zadania numer pięć", false, (byte)4, 2, "5 zadanie" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "toDoListItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "toDoListItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "toDoListItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "toDoListItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "toDoListItems",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
