using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 5,
                column: "TextCompany",
                value: "Fullføringer pågår");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 5,
                column: "TextCompany",
                value: "Sendt tilbake for korreksjon");
        }
    }
}
