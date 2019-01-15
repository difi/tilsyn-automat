using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VlTypeOfResult",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Nb", "Nn", "Text" },
                values: new object[] { "Samsvar", "Samsvar", null });

            migrationBuilder.UpdateData(
                table: "VlTypeOfResult",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Nb", "Nn", "Text" },
                values: new object[] { "Brudd", "Brot", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VlTypeOfResult",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Nb", "Nn", "Text" },
                values: new object[] { null, null, "Samsvar" });

            migrationBuilder.UpdateData(
                table: "VlTypeOfResult",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Nb", "Nn", "Text" },
                values: new object[] { null, null, "Brudd" });
        }
    }
}
