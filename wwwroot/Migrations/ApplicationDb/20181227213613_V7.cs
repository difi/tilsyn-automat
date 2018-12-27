using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 1,
                column: "Text",
                value: "Velg betalingsterminal");

            migrationBuilder.InsertData(
                table: "VlTypeOfSupplierAndVersionList",
                columns: new[] { "Id", "Text" },
                values: new object[] { 100, "Vet ikke" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.UpdateData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 1,
                column: "Text",
                value: "Vet ikke");
        }
    }
}
