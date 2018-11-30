using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BoolFalseText",
                table: "AnswerList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BoolTrueText",
                table: "AnswerList",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("f98f67e5-cf6a-4afe-8998-3132640f9d70"),
                columns: new[] { "Bool", "BoolFalseText", "BoolTrueText", "MaxInt", "MinInt", "TypeOfAnswerId" },
                values: new object[] { true, "Nej", "Mellom 75cm og 130cm over gulvet", 0, 0, 2 });

            migrationBuilder.InsertData(
                table: "AnswerList",
                columns: new[] { "Id", "Bool", "BoolFalseText", "BoolTrueText", "MaxInt", "MinInt", "Order", "Question", "RuleItemId", "TypeOfAnswerId", "ViewIfParentCorrectId", "ViewIfParentFailedId" },
                values: new object[] { new Guid("9aea071e-7263-4b2e-8cd7-5193fbbe5b77"), false, null, null, 130, 75, 1, "Mål i cm", new Guid("5b3af04b-f6c6-4425-a22f-c2e7479839a5"), 3, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("f98f67e5-cf6a-4afe-8998-3132640f9d70") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("9aea071e-7263-4b2e-8cd7-5193fbbe5b77"));

            migrationBuilder.DropColumn(
                name: "BoolFalseText",
                table: "AnswerList");

            migrationBuilder.DropColumn(
                name: "BoolTrueText",
                table: "AnswerList");

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("f98f67e5-cf6a-4afe-8998-3132640f9d70"),
                columns: new[] { "Bool", "MaxInt", "MinInt", "TypeOfAnswerId" },
                values: new object[] { false, 130, 75, 3 });
        }
    }
}
