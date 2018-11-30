using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("8a12d92b-8a6a-44e7-9517-74331a4c2483"),
                column: "Order",
                value: 4);

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("bf459d05-702d-47d7-a5b7-19f8b3fb67c9"),
                columns: new[] { "Bool", "BoolFalseText", "BoolTrueText", "MaxInt", "MinInt", "TypeOfAnswerId" },
                values: new object[] { true, "0-219 cm, ", "220 cm eller mer", 0, 0, 2 });

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("f98f67e5-cf6a-4afe-8998-3132640f9d70"),
                column: "BoolFalseText",
                value: "Annat, ");

            migrationBuilder.InsertData(
                table: "AnswerList",
                columns: new[] { "Id", "AlwaysVisible", "Bool", "BoolFalseText", "BoolTrueText", "LinkedParentCorrectId", "LinkedParentFailedId", "MaxInt", "MinInt", "Order", "Question", "RuleItemId", "TypeOfAnswerId" },
                values: new object[] { new Guid("5544b740-0b5f-400c-b7b2-7e6472d4160b"), true, false, null, null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("bf459d05-702d-47d7-a5b7-19f8b3fb67c9"), 130, 75, 3, "Mål i cm", new Guid("b64cac7e-6525-49e8-9112-0238e1588ed8"), 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("5544b740-0b5f-400c-b7b2-7e6472d4160b"));

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("8a12d92b-8a6a-44e7-9517-74331a4c2483"),
                column: "Order",
                value: 3);

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("bf459d05-702d-47d7-a5b7-19f8b3fb67c9"),
                columns: new[] { "Bool", "BoolFalseText", "BoolTrueText", "MaxInt", "MinInt", "TypeOfAnswerId" },
                values: new object[] { false, null, null, -1, 220, 3 });

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("f98f67e5-cf6a-4afe-8998-3132640f9d70"),
                column: "BoolFalseText",
                value: "Nej");
        }
    }
}
