using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Migrations
{
    public partial class orderstatus8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_Order_Status_DetailsTb_registers_Register_Id",
                table: "user_Order_Status_DetailsTb");

            migrationBuilder.DropIndex(
                name: "IX_user_Order_Status_DetailsTb_Register_Id",
                table: "user_Order_Status_DetailsTb");

            migrationBuilder.DropColumn(
                name: "Carrier",
                table: "user_Order_Status_DetailsTb");

            migrationBuilder.DropColumn(
                name: "Order_Status",
                table: "user_Order_Status_DetailsTb");

            migrationBuilder.DropColumn(
                name: "Payment_Date",
                table: "user_Order_Status_DetailsTb");

            migrationBuilder.DropColumn(
                name: "Payment_Status",
                table: "user_Order_Status_DetailsTb");

            migrationBuilder.DropColumn(
                name: "Shipping_Date",
                table: "user_Order_Status_DetailsTb");

            migrationBuilder.DropColumn(
                name: "Tracking_Id",
                table: "user_Order_Status_DetailsTb");

            migrationBuilder.DropColumn(
                name: "Transcation_Id",
                table: "user_Order_Status_DetailsTb");

            migrationBuilder.RenameColumn(
                name: "Register_Id",
                table: "user_Order_Status_DetailsTb",
                newName: "product_count");

            migrationBuilder.AddColumn<float>(
                name: "Order_Price",
                table: "user_Order_Status_DetailsTb",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Product_Id",
                table: "user_Order_Status_DetailsTb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Carrier",
                table: "order_DetailsTb",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Order_Status",
                table: "order_DetailsTb",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Payment_Date",
                table: "order_DetailsTb",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Payment_Status",
                table: "order_DetailsTb",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Shipping_Date",
                table: "order_DetailsTb",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Tracking_Id",
                table: "order_DetailsTb",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Transcation_Id",
                table: "order_DetailsTb",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_Order_Status_DetailsTb_Product_Id",
                table: "user_Order_Status_DetailsTb",
                column: "Product_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_Order_Status_DetailsTb_admin_ProductLists_Product_Id",
                table: "user_Order_Status_DetailsTb",
                column: "Product_Id",
                principalTable: "admin_ProductLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_Order_Status_DetailsTb_admin_ProductLists_Product_Id",
                table: "user_Order_Status_DetailsTb");

            migrationBuilder.DropIndex(
                name: "IX_user_Order_Status_DetailsTb_Product_Id",
                table: "user_Order_Status_DetailsTb");

            migrationBuilder.DropColumn(
                name: "Order_Price",
                table: "user_Order_Status_DetailsTb");

            migrationBuilder.DropColumn(
                name: "Product_Id",
                table: "user_Order_Status_DetailsTb");

            migrationBuilder.DropColumn(
                name: "Carrier",
                table: "order_DetailsTb");

            migrationBuilder.DropColumn(
                name: "Order_Status",
                table: "order_DetailsTb");

            migrationBuilder.DropColumn(
                name: "Payment_Date",
                table: "order_DetailsTb");

            migrationBuilder.DropColumn(
                name: "Payment_Status",
                table: "order_DetailsTb");

            migrationBuilder.DropColumn(
                name: "Shipping_Date",
                table: "order_DetailsTb");

            migrationBuilder.DropColumn(
                name: "Tracking_Id",
                table: "order_DetailsTb");

            migrationBuilder.DropColumn(
                name: "Transcation_Id",
                table: "order_DetailsTb");

            migrationBuilder.RenameColumn(
                name: "product_count",
                table: "user_Order_Status_DetailsTb",
                newName: "Register_Id");

            migrationBuilder.AddColumn<string>(
                name: "Carrier",
                table: "user_Order_Status_DetailsTb",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Order_Status",
                table: "user_Order_Status_DetailsTb",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Payment_Date",
                table: "user_Order_Status_DetailsTb",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Payment_Status",
                table: "user_Order_Status_DetailsTb",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Shipping_Date",
                table: "user_Order_Status_DetailsTb",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Tracking_Id",
                table: "user_Order_Status_DetailsTb",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Transcation_Id",
                table: "user_Order_Status_DetailsTb",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_Order_Status_DetailsTb_Register_Id",
                table: "user_Order_Status_DetailsTb",
                column: "Register_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_Order_Status_DetailsTb_registers_Register_Id",
                table: "user_Order_Status_DetailsTb",
                column: "Register_Id",
                principalTable: "registers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
