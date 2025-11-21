using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SpilSalesOrder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedItemData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "Description", "ItemCode", "Price", "TaxRate" },
                values: new object[,]
                {
                    { 1, "Laptop", 1001, 1200.00m, 0.15m },
                    { 2, "Mouse", 1002, 25.00m, 0.15m },
                    { 3, "Keyboard", 1003, 75.00m, 0.15m },
                    { 4, "Monitor", 1004, 300.00m, 0.15m },
                    { 5, "Webcam", 1005, 50.00m, 0.15m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
