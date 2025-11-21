using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SpilSalesOrder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedCustomerData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "id", "AddressLine1", "AddressLine2", "City", "CustomerName", "PostalCode" },
                values: new object[,]
                {
                    { 1, "Address 1.1", "Address 1.2", "City 1", "Customer 1", "11111" },
                    { 2, "Address 2.1", "Address 2.2", "City 2", "Customer 2", "22222" },
                    { 3, "Address 3.1", "Address 3.2", "City 3", "Customer 3", "33333" },
                    { 4, "Address 4.1", "Address 4.2", "City 4", "Customer 4", "44444" },
                    { 5, "Address 5.1", "Address 5.2", "City 5", "Customer 5", "55555" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "id",
                keyValue: 5);
        }
    }
}
