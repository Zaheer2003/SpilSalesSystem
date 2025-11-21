using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpilSalesOrder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCustomerSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "AddressLine1", "AddressLine2", "City", "CustomerName", "PostalCode" },
                values: new object[] { "10 Galle Road", "Colombo 03", "Colombo", "Ariya Perera", "00300" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "AddressLine1", "AddressLine2", "City", "CustomerName", "PostalCode" },
                values: new object[] { "25 Kandy Road", "Peradeniya", "Kandy", "Saman Kumara", "20400" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "AddressLine1", "AddressLine2", "City", "CustomerName", "PostalCode" },
                values: new object[] { "5 Main Street", "Mount Lavinia", "Mount Lavinia", "Nimali Fernando", "10370" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "AddressLine1", "AddressLine2", "City", "CustomerName", "PostalCode" },
                values: new object[] { "Borella Cross Road", "Borella", "Colombo", "Chamara Silva", "00800" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "AddressLine1", "AddressLine2", "City", "CustomerName", "PostalCode" },
                values: new object[] { "15 Station Road", "Dehiwala", "Dehiwala", "Priya Rajapakse", "10350" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "AddressLine1", "AddressLine2", "City", "CustomerName", "PostalCode" },
                values: new object[] { "Address 1.1", "Address 1.2", "City 1", "Customer 1", "11111" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "AddressLine1", "AddressLine2", "City", "CustomerName", "PostalCode" },
                values: new object[] { "Address 2.1", "Address 2.2", "City 2", "Customer 2", "22222" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "AddressLine1", "AddressLine2", "City", "CustomerName", "PostalCode" },
                values: new object[] { "Address 3.1", "Address 3.2", "City 3", "Customer 3", "33333" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "AddressLine1", "AddressLine2", "City", "CustomerName", "PostalCode" },
                values: new object[] { "Address 4.1", "Address 4.2", "City 4", "Customer 4", "44444" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "AddressLine1", "AddressLine2", "City", "CustomerName", "PostalCode" },
                values: new object[] { "Address 5.1", "Address 5.2", "City 5", "Customer 5", "55555" });
        }
    }
}
