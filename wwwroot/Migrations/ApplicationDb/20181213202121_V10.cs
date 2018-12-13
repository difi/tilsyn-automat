using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("4edceffe-eb77-4ca0-a498-24be5372d333"),
                columns: new[] { "ResultString1", "ResultString2" },
                values: new object[] { "2,1,1", "2,1,1,1" });

            migrationBuilder.UpdateData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("d438e931-f57c-4a5c-bb5c-3e3a66824827"),
                columns: new[] { "ResultString1", "ResultString2" },
                values: new object[] { "1,1,1", "1,1,1,1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("4edceffe-eb77-4ca0-a498-24be5372d333"),
                columns: new[] { "ResultString1", "ResultString2" },
                values: new object[] { "2,2,1", "2,2,2,1" });

            migrationBuilder.UpdateData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("d438e931-f57c-4a5c-bb5c-3e3a66824827"),
                columns: new[] { "ResultString1", "ResultString2" },
                values: new object[] { "1,2,1", "1,2,2,1" });
        }
    }
}
