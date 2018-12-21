using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("8da3f1e2-4ed3-4957-b94d-797ed932ec73"),
                column: "BoolFalseText",
                value: "Annet, ");

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Text", "TextCompany" },
                values: new object[] { "Åpen for korreksjon", "Åpen for korreksjon" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("8da3f1e2-4ed3-4957-b94d-797ed932ec73"),
                column: "BoolFalseText",
                value: "Annat, ");

            migrationBuilder.UpdateData(
                table: "VlTypeOfStatus",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Text", "TextCompany" },
                values: new object[] { "Sendt tilbake", "Fullføringer pågår" });
        }
    }
}
