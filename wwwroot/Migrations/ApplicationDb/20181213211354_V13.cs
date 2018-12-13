using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("ae869b09-090d-459b-827c-4d61a1578478"),
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("c11dcd56-0aaa-4253-8565-34132b640f15"),
                column: "Order",
                value: 3);

            migrationBuilder.InsertData(
                table: "IndicatorOutcomeList",
                columns: new[] { "Id", "IndicatorItemId", "Order", "ResultString1", "ResultString2" },
                values: new object[,]
                {
                    { new Guid("e5a123b7-f2d4-4d25-b6d7-544c3b7c63b8"), new Guid("c52eb3bc-6464-4dc9-b9f3-eb975e2a012c"), 1, "1,1,1", null },
                    { new Guid("85d5b052-1f22-449d-b0a3-2883593ace54"), new Guid("c52eb3bc-6464-4dc9-b9f3-eb975e2a012c"), 2, "1,1,2", null },
                    { new Guid("d0ab6b63-c6c9-4a4f-81b0-5be0a4497278"), new Guid("c52eb3bc-6464-4dc9-b9f3-eb975e2a012c"), 3, "1,2,1", null },
                    { new Guid("402f1644-36d0-4ad5-853b-aee2f4bfbf75"), new Guid("c52eb3bc-6464-4dc9-b9f3-eb975e2a012c"), 4, "1,2,2", null },
                    { new Guid("54d4cb13-a006-4a8b-9fdb-89a01a9b9040"), new Guid("c52eb3bc-6464-4dc9-b9f3-eb975e2a012c"), 5, "2", null }
                });

            migrationBuilder.InsertData(
                table: "IndicatorOutcomeLanguageList",
                columns: new[] { "Id", "IndicatorOutcomeItemId", "LanguageItemId", "OutcomeText" },
                values: new object[,]
                {
                    { new Guid("20308d8f-c099-436a-bf7b-f91a2fac0376"), new Guid("e5a123b7-f2d4-4d25-b6d7-544c3b7c63b8"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Det finnes et skilt som viser hvor kunden skal betale varene sine. Skiltet er synlig på avstand utenfor kundens betjeningsområde og plassert over området der kunden skal betale varene sine." },
                    { new Guid("1b27cdd4-a34b-486c-a5ff-684afa4579e7"), new Guid("85d5b052-1f22-449d-b0a3-2883593ace54"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Skilt til området der kunden skal betale varene sine, er ikke synlig på avstand utenfor kundens betjeningsområde." },
                    { new Guid("8b2343e2-a121-4247-8b19-318d0d42984c"), new Guid("d0ab6b63-c6c9-4a4f-81b0-5be0a4497278"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Skilt er ikke plassert over området der kunden skal betale varene sine." },
                    { new Guid("2595a239-44fc-4837-9aee-c6dd9f46d71c"), new Guid("402f1644-36d0-4ad5-853b-aee2f4bfbf75"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Skilt til området der kunden skal betale varene sine, er ikke synlig på avstand utenfor kundens betjeningsområde. Skilt er ikke plassert over området der kunden skal betale varene sine." },
                    { new Guid("f6d58cdf-cafa-4892-a847-1a70fa2dd4e2"), new Guid("54d4cb13-a006-4a8b-9fdb-89a01a9b9040"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Det finnes ikke et skilt som viser hvor kunden skal betale." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("1b27cdd4-a34b-486c-a5ff-684afa4579e7"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("20308d8f-c099-436a-bf7b-f91a2fac0376"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("2595a239-44fc-4837-9aee-c6dd9f46d71c"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("8b2343e2-a121-4247-8b19-318d0d42984c"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("f6d58cdf-cafa-4892-a847-1a70fa2dd4e2"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("402f1644-36d0-4ad5-853b-aee2f4bfbf75"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("54d4cb13-a006-4a8b-9fdb-89a01a9b9040"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("85d5b052-1f22-449d-b0a3-2883593ace54"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("d0ab6b63-c6c9-4a4f-81b0-5be0a4497278"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("e5a123b7-f2d4-4d25-b6d7-544c3b7c63b8"));

            migrationBuilder.UpdateData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("ae869b09-090d-459b-827c-4d61a1578478"),
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("c11dcd56-0aaa-4253-8565-34132b640f15"),
                column: "Order",
                value: 1);
        }
    }
}
