using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyWebSiteCore.Migrations
{
    public partial class updatecomptbl2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WelecomePageTitle",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WelecomePageTitleEn",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WelecomePageTitle",
                table: "CompanyDatas");

            migrationBuilder.DropColumn(
                name: "WelecomePageTitleEn",
                table: "CompanyDatas");
        }
    }
}
