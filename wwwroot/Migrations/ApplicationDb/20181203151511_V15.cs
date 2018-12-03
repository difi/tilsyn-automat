using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.InsertData(
                table: "VlTypeOfSupplierAndVersionList",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 200, "Ingenico iCT250" },
                    { 2200, "Verifone Xenteo ECO" },
                    { 2100, "Verifone VX 820 Duet" },
                    { 2000, "Verifone VX 820" },
                    { 1900, "Verifone VX 690" },
                    { 1800, "Verifone VX 680" },
                    { 1700, "Verifone VX 520 C" },
                    { 1600, "SumUp Air" },
                    { 1500, "iZettle Reader" },
                    { 1400, "Ingenico iWL252" },
                    { 2300, "Verifone Yomani XR" },
                    { 1300, "Ingenico iWL251" },
                    { 1100, "Ingenico iWL250B " },
                    { 1000, "Ingenico iWL250" },
                    { 900, "Ingenico iUP" },
                    { 800, "Ingenico isMP4" },
                    { 700, "Ingenico iSMP" },
                    { 600, "Ingenico iSelf" },
                    { 500, "Ingenico iPP350" },
                    { 400, "Ingenico iCT250r" },
                    { 300, "Ingenico iCT250E" },
                    { 1200, "Ingenico iWL250G" },
                    { 99999, "Annet" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 500);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 600);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 700);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 800);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 900);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 1000);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 1100);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 1200);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 1300);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 1400);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 1500);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 1600);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 1700);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 1800);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 1900);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 2000);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 2100);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 2200);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 2300);

            migrationBuilder.DeleteData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 99999);

            migrationBuilder.InsertData(
                table: "VlTypeOfSupplierAndVersionList",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 2, "Ingenico iCT250" },
                    { 21, "Verifone VX 820 Duet" },
                    { 20, "Verifone VX 820" },
                    { 19, "Verifone VX 690" },
                    { 18, "Verifone VX 680" },
                    { 17, "Verifone VX 520 C" },
                    { 16, "SumUp Air" },
                    { 15, "iZettle Reader" },
                    { 14, "Ingenico iWL252" },
                    { 13, "Ingenico iWL251" },
                    { 12, "Ingenico iWL250G" },
                    { 11, "Ingenico iWL250B " },
                    { 10, "Ingenico iWL250" },
                    { 9, "Ingenico iUP" },
                    { 8, "Ingenico isMP4" },
                    { 7, "Ingenico iSMP" },
                    { 6, "Ingenico iSelf" },
                    { 5, "Ingenico iPP350" },
                    { 4, "Ingenico iCT250r" },
                    { 3, "Ingenico iCT250E" },
                    { 22, "Verifone Xenteo ECO" },
                    { 23, "Verifone Yomani XR" }
                });
        }
    }
}
