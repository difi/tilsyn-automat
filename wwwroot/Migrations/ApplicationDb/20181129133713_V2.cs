using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaseNumber",
                table: "DeclarationTestItem");

            migrationBuilder.AddColumn<string>(
                name: "CaseNumber",
                table: "DeclarationList",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaseNumber",
                table: "DeclarationList");

            migrationBuilder.AddColumn<string>(
                name: "CaseNumber",
                table: "DeclarationTestItem",
                nullable: true);
        }
    }
}
