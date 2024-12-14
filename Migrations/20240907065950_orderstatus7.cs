using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Migrations
{
    public partial class orderstatus7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "order_DetailsTb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Register_Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pin = table.Column<int>(type: "int", nullable: false),
                    UserCart_Id = table.Column<int>(type: "int", nullable: false),
                    Order_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_DetailsTb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_order_DetailsTb_registers_Register_Id",
                        column: x => x.Register_Id,
                        principalTable: "registers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_Order_Status_DetailsTb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Register_Id = table.Column<int>(type: "int", nullable: false),
                    Shipping_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Payment_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Carrier = table.Column<string>(type: "varchar(50)", nullable: true),
                    Tracking_Id = table.Column<string>(type: "varchar(50)", nullable: true),
                    Transcation_Id = table.Column<string>(type: "varchar(50)", nullable: true),
                    Payment_Status = table.Column<string>(type: "varchar(50)", nullable: true),
                    Order_Status = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_Order_Status_DetailsTb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_Order_Status_DetailsTb_registers_Register_Id",
                        column: x => x.Register_Id,
                        principalTable: "registers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_DetailsTb_Register_Id",
                table: "order_DetailsTb",
                column: "Register_Id");

            migrationBuilder.CreateIndex(
                name: "IX_user_Order_Status_DetailsTb_Register_Id",
                table: "user_Order_Status_DetailsTb",
                column: "Register_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_DetailsTb");

            migrationBuilder.DropTable(
                name: "user_Order_Status_DetailsTb");
        }
    }
}
