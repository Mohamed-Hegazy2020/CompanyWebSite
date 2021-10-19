using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyWebSiteCore.Migrations
{
    public partial class updatecomptbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressEn",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyNameEn",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaceBookLink",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstgramLink",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedinLink",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterLink",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WelecomePageDescription",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WelecomePageDescriptionEn",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressEn",
                table: "CompanyDatas");

            migrationBuilder.DropColumn(
                name: "CompanyNameEn",
                table: "CompanyDatas");

            migrationBuilder.DropColumn(
                name: "FaceBookLink",
                table: "CompanyDatas");

            migrationBuilder.DropColumn(
                name: "InstgramLink",
                table: "CompanyDatas");

            migrationBuilder.DropColumn(
                name: "LinkedinLink",
                table: "CompanyDatas");

            migrationBuilder.DropColumn(
                name: "TwitterLink",
                table: "CompanyDatas");

            migrationBuilder.DropColumn(
                name: "WelecomePageDescription",
                table: "CompanyDatas");

            migrationBuilder.DropColumn(
                name: "WelecomePageDescriptionEn",
                table: "CompanyDatas");
        }
    }
}
