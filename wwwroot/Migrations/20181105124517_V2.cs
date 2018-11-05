using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressCity",
                table: "CompanyList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressStreet",
                table: "CompanyList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressZip",
                table: "CompanyList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomName",
                table: "CompanyList",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressCity",
                table: "CompanyList");

            migrationBuilder.DropColumn(
                name: "AddressStreet",
                table: "CompanyList");

            migrationBuilder.DropColumn(
                name: "AddressZip",
                table: "CompanyList");

            migrationBuilder.DropColumn(
                name: "CustomName",
                table: "CompanyList");
        }
    }
}
