using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "Text",
                value: "Varslet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "Text",
                value: "Varslad");
        }
    }
}
