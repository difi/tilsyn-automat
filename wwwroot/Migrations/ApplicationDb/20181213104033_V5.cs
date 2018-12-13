using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("2e2e8b32-c7c4-4ffa-b6b7-275a82e5b6af"),
                column: "Question",
                value: "Bekreft med bilde");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("6c73f84c-a2d5-43ac-a5fe-793d0c5672cc"),
                column: "Question",
                value: "Bekreft med bilde");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("6e68729a-50e9-4844-a791-43e2eb21fad0"),
                column: "Question",
                value: "Bekreft med bilde");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("db55a19e-7f42-4176-921d-4a09698f727a"),
                column: "Question",
                value: "Bekreft med bilde");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("ec0e3dd2-bd43-4e44-a118-51b86b80d77f"),
                column: "Question",
                value: "Bekreft med bilde");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("2e2e8b32-c7c4-4ffa-b6b7-275a82e5b6af"),
                column: "Question",
                value: "Ta bilde");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("6c73f84c-a2d5-43ac-a5fe-793d0c5672cc"),
                column: "Question",
                value: "Ta bilde");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("6e68729a-50e9-4844-a791-43e2eb21fad0"),
                column: "Question",
                value: "Ta bilde");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("db55a19e-7f42-4176-921d-4a09698f727a"),
                column: "Question",
                value: "Ta bilde");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("ec0e3dd2-bd43-4e44-a118-51b86b80d77f"),
                column: "Question",
                value: "Ta bilde");
        }
    }
}
