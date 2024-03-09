using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetalcutWeb.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDelivery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_AspNetUsers_AcceptedUserId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_AspNetUsers_RequestedUserId",
                table: "Deliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Products_DeliveryProductId",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "EmployeeCount",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "DeliveryProductId",
                table: "Deliveries",
                newName: "DeliveryProductId1");

            migrationBuilder.RenameIndex(
                name: "IX_Deliveries_DeliveryProductId",
                table: "Deliveries",
                newName: "IX_Deliveries_DeliveryProductId1");

            migrationBuilder.AlterColumn<string>(
                name: "RequestedUserId",
                table: "Deliveries",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AcceptedUserId",
                table: "Deliveries",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_AspNetUsers_AcceptedUserId",
                table: "Deliveries",
                column: "AcceptedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_AspNetUsers_RequestedUserId",
                table: "Deliveries",
                column: "RequestedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Products_DeliveryProductId1",
                table: "Deliveries",
                column: "DeliveryProductId1",
                principalTable: "Products",
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

            migrationBuilder.DropForeignKey(
                name: "FK_Deliveries_Products_DeliveryProductId1",
                table: "Deliveries");

            migrationBuilder.RenameColumn(
                name: "DeliveryProductId1",
                table: "Deliveries",
                newName: "DeliveryProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Deliveries_DeliveryProductId1",
                table: "Deliveries",
                newName: "IX_Deliveries_DeliveryProductId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeCount",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "RequestedUserId",
                table: "Deliveries",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "AcceptedUserId",
                table: "Deliveries",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Deliveries_Products_DeliveryProductId",
                table: "Deliveries",
                column: "DeliveryProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
