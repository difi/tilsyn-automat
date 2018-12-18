using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VlPurposeOfTest",
                keyColumn: "Id",
                keyValue: 3,
                column: "Text",
                value: "Statusmåling");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VlPurposeOfTest",
                keyColumn: "Id",
                keyValue: 3,
                column: "Text",
                value: "Statysmåling");
        }
    }
}
