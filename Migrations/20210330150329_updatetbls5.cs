using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyWebSiteCore.Migrations
{
    public partial class updatetbls5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FooterAboutDescreption",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FooterAboutDescreptionEn",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeBackGImage",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FooterAboutDescreption",
                table: "CompanyDatas");

            migrationBuilder.DropColumn(
                name: "FooterAboutDescreptionEn",
                table: "CompanyDatas");

            migrationBuilder.DropColumn(
                name: "HomeBackGImage",
                table: "CompanyDatas");
        }
    }
}
