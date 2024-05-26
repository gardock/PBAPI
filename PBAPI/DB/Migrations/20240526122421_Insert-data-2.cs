using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class Insertdata2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "toDoListItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 26, 12, 24, 21, 470, DateTimeKind.Utc).AddTicks(9778));

            migrationBuilder.UpdateData(
                table: "toDoListItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 26, 12, 24, 21, 470, DateTimeKind.Utc).AddTicks(9862));

            migrationBuilder.UpdateData(
                table: "toDoListItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 26, 12, 24, 21, 470, DateTimeKind.Utc).AddTicks(9875));

            migrationBuilder.UpdateData(
                table: "toDoListItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 5, 26, 12, 24, 21, 470, DateTimeKind.Utc).AddTicks(9888));

            migrationBuilder.UpdateData(
                table: "toDoListItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 5, 26, 12, 24, 21, 470, DateTimeKind.Utc).AddTicks(9900));

            migrationBuilder.InsertData(
                table: "toDoListItems",
                columns: new[] { "Id", "CreateDate", "Description", "IsDeleted", "Order", "Status", "Title" },
                values: new object[] { 6, new DateTime(2024, 5, 26, 12, 24, 21, 470, DateTimeKind.Utc).AddTicks(9944), "To jest opis zadania numer sześć", false, (byte)5, 2, "6 zadanie" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "toDoListItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "toDoListItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 5, 26, 12, 21, 42, 273, DateTimeKind.Utc).AddTicks(2791));

            migrationBuilder.UpdateData(
                table: "toDoListItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 5, 26, 12, 21, 42, 273, DateTimeKind.Utc).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "toDoListItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 5, 26, 12, 21, 42, 273, DateTimeKind.Utc).AddTicks(2879));

            migrationBuilder.UpdateData(
                table: "toDoListItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 5, 26, 12, 21, 42, 273, DateTimeKind.Utc).AddTicks(2935));

            migrationBuilder.UpdateData(
                table: "toDoListItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2024, 5, 26, 12, 21, 42, 273, DateTimeKind.Utc).AddTicks(2947));
        }
    }
}
