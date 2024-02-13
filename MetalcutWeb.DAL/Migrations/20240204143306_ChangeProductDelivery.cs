using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetalcutWeb.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProductDelivery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price10",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Deliveries");

            migrationBuilder.RenameColumn(
                name: "Price5",
                table: "Products",
                newName: "Price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "Price5");

            migrationBuilder.AddColumn<double>(
                name: "Price1",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price10",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "Deliveries",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
