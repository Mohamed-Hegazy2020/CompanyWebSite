using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyWebSiteCore.Migrations
{
    public partial class updatecomptbl3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutPageDescreption",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutPageDescreptionEn",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutPageHeader",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AboutPageHeaderEn",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutPageDescreption",
                table: "CompanyDatas");

            migrationBuilder.DropColumn(
                name: "AboutPageDescreptionEn",
                table: "CompanyDatas");

            migrationBuilder.DropColumn(
                name: "AboutPageHeader",
                table: "CompanyDatas");

            migrationBuilder.DropColumn(
                name: "AboutPageHeaderEn",
                table: "CompanyDatas");
        }
    }
}
