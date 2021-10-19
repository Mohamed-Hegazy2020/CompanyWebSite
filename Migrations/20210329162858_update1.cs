using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyWebSiteCore.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceTitleDescreption",
                table: "ServicesDatas");

            migrationBuilder.RenameColumn(
                name: "ServiceTitleDescreptionEn",
                table: "ServicesDatas",
                newName: "ServiceIcon");

            migrationBuilder.AddColumn<string>(
                name: "ClientsTitleDescreption",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientsTitleDescreptionEn",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactTitleDescreption",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactTitleDescreptionEn",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductsTitleDescreption",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductsTitleDescreptionEn",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServicesTitleDescreption",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServicesTitleDescreptionEn",
                table: "CompanyDatas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientsTitleDescreption",
                table: "CompanyDatas");

            migrationBuilder.DropColumn(
                name: "ClientsTitleDescreptionEn",
                table: "CompanyDatas");

            migrationBuilder.DropColumn(
                name: "ContactTitleDescreption",
                table: "CompanyDatas");

            migrationBuilder.DropColumn(
                name: "ContactTitleDescreptionEn",
                table: "CompanyDatas");

            migrationBuilder.DropColumn(
                name: "ProductsTitleDescreption",
                table: "CompanyDatas");

            migrationBuilder.DropColumn(
                name: "ProductsTitleDescreptionEn",
                table: "CompanyDatas");

            migrationBuilder.DropColumn(
                name: "ServicesTitleDescreption",
                table: "CompanyDatas");

            migrationBuilder.DropColumn(
                name: "ServicesTitleDescreptionEn",
                table: "CompanyDatas");

            migrationBuilder.RenameColumn(
                name: "ServiceIcon",
                table: "ServicesDatas",
                newName: "ServiceTitleDescreptionEn");

            migrationBuilder.AddColumn<string>(
                name: "ServiceTitleDescreption",
                table: "ServicesDatas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
