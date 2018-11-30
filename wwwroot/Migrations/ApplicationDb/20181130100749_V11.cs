using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("13d6d530-e533-4510-9a66-8b862899dbdf"),
                column: "Order",
                value: 4);

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("89fd2205-1047-403d-a5bd-f70a1de2f247"),
                columns: new[] { "Bool", "BoolFalseText", "BoolTrueText", "MaxInt", "MinInt", "TypeOfAnswerId" },
                values: new object[] { true, "0-149 cm, ", "150 cm eller mer", 0, 0, 2 });

            migrationBuilder.InsertData(
                table: "AnswerList",
                columns: new[] { "Id", "AlwaysVisible", "Bool", "BoolFalseText", "BoolTrueText", "LinkedParentCorrectId", "LinkedParentFailedId", "MaxInt", "MinInt", "Order", "Question", "RuleItemId", "TypeOfAnswerId" },
                values: new object[] { new Guid("78b8d910-c0bb-4467-acbe-1320f51fe658"), true, false, null, null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("89fd2205-1047-403d-a5bd-f70a1de2f247"), -1, 150, 3, "Mål i cm", new Guid("0d6c763e-e0f6-4049-adeb-ae9429262b57"), 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("78b8d910-c0bb-4467-acbe-1320f51fe658"));

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("13d6d530-e533-4510-9a66-8b862899dbdf"),
                column: "Order",
                value: 3);

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("89fd2205-1047-403d-a5bd-f70a1de2f247"),
                columns: new[] { "Bool", "BoolFalseText", "BoolTrueText", "MaxInt", "MinInt", "TypeOfAnswerId" },
                values: new object[] { false, null, null, -1, 150, 3 });
        }
    }
}
