using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Migrations
{
    public partial class productlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin_ProductLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ISBN = table.Column<int>(type: "int", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ListPrice = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Price50 = table.Column<float>(type: "real", nullable: false),
                    Price100 = table.Column<float>(type: "real", nullable: false),
                    Cover_TypeID = table.Column<int>(type: "int", nullable: false),
                    Catergory_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin_ProductLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_admin_ProductLists_admin_cats_Catergory_Id",
                        column: x => x.Catergory_Id,
                        principalTable: "admin_cats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_admin_ProductLists_admin_CoverTypess_Cover_TypeID",
                        column: x => x.Cover_TypeID,
                        principalTable: "admin_CoverTypess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_admin_ProductLists_Catergory_Id",
                table: "admin_ProductLists",
                column: "Catergory_Id");

            migrationBuilder.CreateIndex(
                name: "IX_admin_ProductLists_Cover_TypeID",
                table: "admin_ProductLists",
                column: "Cover_TypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admin_ProductLists");
        }
    }
}
