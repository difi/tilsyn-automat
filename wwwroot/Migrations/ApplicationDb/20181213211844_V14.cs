using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "IndicatorOutcomeList",
                columns: new[] { "Id", "IndicatorItemId", "Order", "ResultString1", "ResultString2" },
                values: new object[] { new Guid("043ccfc1-ff23-43f3-a130-3d399638f24f"), new Guid("5b2a0a78-039f-4173-bf9e-1ca0060d1c53"), 1, "1", "1,1" });

            migrationBuilder.InsertData(
                table: "IndicatorOutcomeList",
                columns: new[] { "Id", "IndicatorItemId", "Order", "ResultString1", "ResultString2" },
                values: new object[] { new Guid("8d69236d-8940-417e-aab6-d41d74539ef2"), new Guid("5b2a0a78-039f-4173-bf9e-1ca0060d1c53"), 2, "2,2", null });

            migrationBuilder.InsertData(
                table: "IndicatorOutcomeLanguageList",
                columns: new[] { "Id", "IndicatorOutcomeItemId", "LanguageItemId", "OutcomeText" },
                values: new object[] { new Guid("c80f2711-1229-48d5-a15d-eb790d00f7f2"), new Guid("043ccfc1-ff23-43f3-a130-3d399638f24f"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Betalingsterminalen er mellom 75 og 130 cm over gulvet." });

            migrationBuilder.InsertData(
                table: "IndicatorOutcomeLanguageList",
                columns: new[] { "Id", "IndicatorOutcomeItemId", "LanguageItemId", "OutcomeText" },
                values: new object[] { new Guid("840d94f6-0c3c-47d8-bcfd-7d4a148eec06"), new Guid("8d69236d-8940-417e-aab6-d41d74539ef2"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Betalingsterminalen er ikke mellom 75 og 130 cm over gulvet." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("840d94f6-0c3c-47d8-bcfd-7d4a148eec06"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("c80f2711-1229-48d5-a15d-eb790d00f7f2"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("043ccfc1-ff23-43f3-a130-3d399638f24f"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("8d69236d-8940-417e-aab6-d41d74539ef2"));
        }
    }
}
