using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyWebSiteCore.Migrations
{
    public partial class update6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServiceTitleDescreption",
                table: "ServicesDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceTitleDescreptionEn",
                table: "ServicesDatas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceTitleDescreption",
                table: "ServicesDatas");

            migrationBuilder.DropColumn(
                name: "ServiceTitleDescreptionEn",
                table: "ServicesDatas");
        }
    }
}
