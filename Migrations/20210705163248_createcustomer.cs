using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyWebSiteCore.Migrations
{
    public partial class createcustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomersDatas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerDescreption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerDescreptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerImgPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Companyid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersDatas", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersDatas");
        }
    }
}
