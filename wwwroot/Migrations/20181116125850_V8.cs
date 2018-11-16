using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("02d2db89-3717-48e1-883e-8e526bf6c727"),
                column: "Bool",
                value: false);

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("202d20e0-61df-4a7c-8287-104e3b439f64"),
                column: "Bool",
                value: false);

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("a1964762-5c8f-40bb-a22d-c907149079d4"),
                column: "Bool",
                value: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("02d2db89-3717-48e1-883e-8e526bf6c727"),
                column: "Bool",
                value: true);

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("202d20e0-61df-4a7c-8287-104e3b439f64"),
                column: "Bool",
                value: true);

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("a1964762-5c8f-40bb-a22d-c907149079d4"),
                column: "Bool",
                value: true);
        }
    }
}
