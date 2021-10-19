using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyWebSiteCore.Migrations
{
    public partial class createproducttbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductsDatas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDescreption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDescreptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductImgPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Companyid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsDatas", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsDatas");
        }
    }
}
