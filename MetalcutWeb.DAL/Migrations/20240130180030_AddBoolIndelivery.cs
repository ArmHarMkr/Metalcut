using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetalcutWeb.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddBoolIndelivery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AcceptedUserId",
                table: "Deliveries",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Deliveries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "Deliveries",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "RequestedUserId",
                table: "Deliveries",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_AcceptedUserId",
                table: "Deliveries",
                column: "AcceptedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_RequestedUserId",
                table: "Deliveries",
                column: "RequestedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_AspNetUsers_AcceptedUserId",
                table: "Deliveries",
                column: "AcceptedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_AspNetUsers_RequestedUserId",
                table: "Deliveries",
                column: "RequestedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_AspNetUsers_AcceptedUserId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_AspNetUsers_RequestedUserId",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_AcceptedUserId",
                table: "Deliveries");

            migrationBuilder.DropIndex(
                name: "IX_Deliveries_RequestedUserId",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "AcceptedUserId",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "RequestedUserId",
                table: "Deliveries");
        }
    }
}
