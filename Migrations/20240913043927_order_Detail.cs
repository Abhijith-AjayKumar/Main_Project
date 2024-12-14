using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Migrations
{
    public partial class order_Detail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserCart_Id",
                table: "order_DetailsTb");

            migrationBuilder.AddColumn<float>(
                name: "Amount",
                table: "order_DetailsTb",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "order_DetailsTb");

            migrationBuilder.AddColumn<int>(
                name: "UserCart_Id",
                table: "order_DetailsTb",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
