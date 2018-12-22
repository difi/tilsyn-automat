using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomAddressZip",
                table: "CompanyList",
                newName: "CustomLocationAddressZip");

            migrationBuilder.RenameColumn(
                name: "CustomAddressStreet",
                table: "CompanyList",
                newName: "CustomLocationAddressStreet");

            migrationBuilder.RenameColumn(
                name: "CustomAddressCity",
                table: "CompanyList",
                newName: "CustomLocationAddressCity");

            migrationBuilder.AddColumn<string>(
                name: "CustomBusinessAddressCity",
                table: "CompanyList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomBusinessAddressStreet",
                table: "CompanyList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomBusinessAddressZip",
                table: "CompanyList",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomBusinessAddressCity",
                table: "CompanyList");

            migrationBuilder.DropColumn(
                name: "CustomBusinessAddressStreet",
                table: "CompanyList");

            migrationBuilder.DropColumn(
                name: "CustomBusinessAddressZip",
                table: "CompanyList");

            migrationBuilder.RenameColumn(
                name: "CustomLocationAddressZip",
                table: "CompanyList",
                newName: "CustomAddressZip");

            migrationBuilder.RenameColumn(
                name: "CustomLocationAddressStreet",
                table: "CompanyList",
                newName: "CustomAddressStreet");

            migrationBuilder.RenameColumn(
                name: "CustomLocationAddressCity",
                table: "CompanyList",
                newName: "CustomAddressCity");
        }
    }
}
