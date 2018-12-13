using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "IndicatorOutcomeList",
                columns: new[] { "Id", "IndicatorItemId", "Order", "ResultString1", "ResultString2" },
                values: new object[] { new Guid("30f07a36-ff0b-4692-b7bf-0f2d8dee923a"), new Guid("6b4bf385-9174-4634-bc9e-bfbdab98586e"), 1, "1,1", "1,1,1" });

            migrationBuilder.InsertData(
                table: "IndicatorOutcomeList",
                columns: new[] { "Id", "IndicatorItemId", "Order", "ResultString1", "ResultString2" },
                values: new object[] { new Guid("ae869b09-090d-459b-827c-4d61a1578478"), new Guid("6b4bf385-9174-4634-bc9e-bfbdab98586e"), 1, "2,2,2", null });

            migrationBuilder.InsertData(
                table: "IndicatorOutcomeList",
                columns: new[] { "Id", "IndicatorItemId", "Order", "ResultString1", "ResultString2" },
                values: new object[] { new Guid("c11dcd56-0aaa-4253-8565-34132b640f15"), new Guid("6b4bf385-9174-4634-bc9e-bfbdab98586e"), 1, "1", null });

            migrationBuilder.InsertData(
                table: "IndicatorOutcomeLanguageList",
                columns: new[] { "Id", "IndicatorOutcomeItemId", "LanguageItemId", "OutcomeText" },
                values: new object[] { new Guid("541fde0f-502e-4e6f-82f1-aca378d76b60"), new Guid("30f07a36-ff0b-4692-b7bf-0f2d8dee923a"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Det er minst 150 cm mellom betalingsterminalene." });

            migrationBuilder.InsertData(
                table: "IndicatorOutcomeLanguageList",
                columns: new[] { "Id", "IndicatorOutcomeItemId", "LanguageItemId", "OutcomeText" },
                values: new object[] { new Guid("6b3a3de6-d6ff-45a4-8061-6e62d6970747"), new Guid("ae869b09-090d-459b-827c-4d61a1578478"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Betalingsterminalene står for tett." });

            migrationBuilder.InsertData(
                table: "IndicatorOutcomeLanguageList",
                columns: new[] { "Id", "IndicatorOutcomeItemId", "LanguageItemId", "OutcomeText" },
                values: new object[] { new Guid("8bb7a824-82ca-4fbc-bb33-151a38b0a054"), new Guid("c11dcd56-0aaa-4253-8565-34132b640f15"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Betalingsterminalen står ikke på rett linje ved siden av en annen betalingsterminal." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("541fde0f-502e-4e6f-82f1-aca378d76b60"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("6b3a3de6-d6ff-45a4-8061-6e62d6970747"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("8bb7a824-82ca-4fbc-bb33-151a38b0a054"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("30f07a36-ff0b-4692-b7bf-0f2d8dee923a"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("ae869b09-090d-459b-827c-4d61a1578478"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("c11dcd56-0aaa-4253-8565-34132b640f15"));
        }
    }
}
