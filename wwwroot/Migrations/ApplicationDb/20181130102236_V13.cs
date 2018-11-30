using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("02d2db89-3717-48e1-883e-8e526bf6c727"),
                columns: new[] { "BoolFalseText", "BoolTrueText" },
                values: new object[] { "Nej", "Ja" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("02d2db89-3717-48e1-883e-8e526bf6c727"),
                columns: new[] { "BoolFalseText", "BoolTrueText" },
                values: new object[] { null, null });
        }
    }
}