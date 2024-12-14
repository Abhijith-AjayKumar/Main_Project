using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Migrations
{
    public partial class @as : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order_Id",
                table: "user_Order_Status_DetailsTb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_user_Order_Status_DetailsTb_Order_Id",
                table: "user_Order_Status_DetailsTb",
                column: "Order_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_Order_Status_DetailsTb_order_DetailsTb_Order_Id",
                table: "user_Order_Status_DetailsTb",
                column: "Order_Id",
                principalTable: "order_DetailsTb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_Order_Status_DetailsTb_order_DetailsTb_Order_Id",
                table: "user_Order_Status_DetailsTb");

            migrationBuilder.DropIndex(
                name: "IX_user_Order_Status_DetailsTb_Order_Id",
                table: "user_Order_Status_DetailsTb");

            migrationBuilder.DropColumn(
                name: "Order_Id",
                table: "user_Order_Status_DetailsTb");
        }
    }
}
