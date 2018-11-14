using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddressZip",
                table: "CompanyList",
                newName: "OwenerCorporateIdentityNumber");

            migrationBuilder.RenameColumn(
                name: "AddressStreet",
                table: "CompanyList",
                newName: "MailingAddressZip");

            migrationBuilder.RenameColumn(
                name: "AddressCity",
                table: "CompanyList",
                newName: "MailingAddressStreet");

            migrationBuilder.AddColumn<string>(
                name: "BusinessAddressCity",
                table: "CompanyList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessAddressStreet",
                table: "CompanyList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessAddressZip",
                table: "CompanyList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExternalId",
                table: "CompanyList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IndustryGroupAggregated",
                table: "CompanyList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IndustryGroupCode",
                table: "CompanyList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IndustryGroupDescription",
                table: "CompanyList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstitutionalSectorCode",
                table: "CompanyList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstitutionalSectorDescription",
                table: "CompanyList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationAddressCity",
                table: "CompanyList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationAddressStreet",
                table: "CompanyList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocationAddressZip",
                table: "CompanyList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailingAddressCity",
                table: "CompanyList",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessAddressCity",
                table: "CompanyList");

            migrationBuilder.DropColumn(
                name: "BusinessAddressStreet",
                table: "CompanyList");

            migrationBuilder.DropColumn(
                name: "BusinessAddressZip",
                table: "CompanyList");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "CompanyList");

            migrationBuilder.DropColumn(
                name: "IndustryGroupAggregated",
                table: "CompanyList");

            migrationBuilder.DropColumn(
                name: "IndustryGroupCode",
                table: "CompanyList");

            migrationBuilder.DropColumn(
                name: "IndustryGroupDescription",
                table: "CompanyList");

            migrationBuilder.DropColumn(
                name: "InstitutionalSectorCode",
                table: "CompanyList");

            migrationBuilder.DropColumn(
                name: "InstitutionalSectorDescription",
                table: "CompanyList");

            migrationBuilder.DropColumn(
                name: "LocationAddressCity",
                table: "CompanyList");

            migrationBuilder.DropColumn(
                name: "LocationAddressStreet",
                table: "CompanyList");

            migrationBuilder.DropColumn(
                name: "LocationAddressZip",
                table: "CompanyList");

            migrationBuilder.DropColumn(
                name: "MailingAddressCity",
                table: "CompanyList");

            migrationBuilder.RenameColumn(
                name: "OwenerCorporateIdentityNumber",
                table: "CompanyList",
                newName: "AddressZip");

            migrationBuilder.RenameColumn(
                name: "MailingAddressZip",
                table: "CompanyList",
                newName: "AddressStreet");

            migrationBuilder.RenameColumn(
                name: "MailingAddressStreet",
                table: "CompanyList",
                newName: "AddressCity");
        }
    }
}
