using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyWebSiteCore.Migrations
{
    public partial class createServicesData1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServicesDatas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceTitleDescreption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceTitleDescreptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceDescreption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceDescreptionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Companyid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesDatas", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicesDatas");
        }
    }
}
