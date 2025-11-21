using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpilSalesOrder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSalesOrderItemSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemCode",
                table: "SalesOrderItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemCode",
                table: "SalesOrderItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
