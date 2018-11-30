using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("202d20e0-61df-4a7c-8287-104e3b439f64"),
                columns: new[] { "BoolFalseText", "BoolTrueText" },
                values: new object[] { "Nej", "Ja" });

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("9a51cc68-857e-4822-ac81-0ec3ebe7bf43"),
                columns: new[] { "BoolFalseText", "BoolTrueText" },
                values: new object[] { "Nej", "Ja" });

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("a1964762-5c8f-40bb-a22d-c907149079d4"),
                columns: new[] { "BoolFalseText", "BoolTrueText" },
                values: new object[] { "Nej", "Ja" });

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("d8611e84-0f00-4d75-bcab-cbf127fb68b5"),
                columns: new[] { "BoolFalseText", "BoolTrueText" },
                values: new object[] { "Nej", "Ja" });

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("f69c1e45-99d8-4293-a242-c5ed9e126e99"),
                columns: new[] { "BoolFalseText", "BoolTrueText" },
                values: new object[] { "Nej", "Ja" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("202d20e0-61df-4a7c-8287-104e3b439f64"),
                columns: new[] { "BoolFalseText", "BoolTrueText" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("9a51cc68-857e-4822-ac81-0ec3ebe7bf43"),
                columns: new[] { "BoolFalseText", "BoolTrueText" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("a1964762-5c8f-40bb-a22d-c907149079d4"),
                columns: new[] { "BoolFalseText", "BoolTrueText" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("d8611e84-0f00-4d75-bcab-cbf127fb68b5"),
                columns: new[] { "BoolFalseText", "BoolTrueText" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("f69c1e45-99d8-4293-a242-c5ed9e126e99"),
                columns: new[] { "BoolFalseText", "BoolTrueText" },
                values: new object[] { null, null });
        }
    }
}
