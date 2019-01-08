using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("844733d7-44b6-4813-b8a6-8ed36012e1a4"),
                column: "BoolTrueText",
                value: "150 cm eller meir");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("8db67b5c-e3b1-4053-a66a-3499c54a545d"),
                column: "Question",
                value: "Stadfest med bilde");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("93a705e1-5c90-4a6f-a03d-c2e3c449e4a6"),
                column: "Question",
                value: "Stadfest med bilde");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("d61c82e8-a3a1-444f-bb63-ef34ba4b720e"),
                column: "Question",
                value: "Stadfest med bilde");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("d7d086fb-99a8-42b6-8200-338a85d886a1"),
                column: "BoolTrueText",
                value: "220 cm eller meir");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("dbf5bc8b-de37-4c68-8219-f2785d832eb3"),
                column: "Question",
                value: "Stadfest med bilde");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("dde428e6-e13b-4140-860b-b185661d8dc6"),
                column: "Question",
                value: "Stadfest med bilde");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("fd3d3290-b415-495d-8c38-bf6c6fb2a679"),
                columns: new[] { "BoolFalseText", "BoolTrueText" },
                values: new object[] { "Anna, ", "Mellom 75 cm og 130 cm over golvet" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("844733d7-44b6-4813-b8a6-8ed36012e1a4"),
                column: "BoolTrueText",
                value: "150 cm eller mer");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("8db67b5c-e3b1-4053-a66a-3499c54a545d"),
                column: "Question",
                value: "Bekreft med bilde");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("93a705e1-5c90-4a6f-a03d-c2e3c449e4a6"),
                column: "Question",
                value: "Bekreft med bilde");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("d61c82e8-a3a1-444f-bb63-ef34ba4b720e"),
                column: "Question",
                value: "Bekreft med bilde");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("d7d086fb-99a8-42b6-8200-338a85d886a1"),
                column: "BoolTrueText",
                value: "220 cm eller mer");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("dbf5bc8b-de37-4c68-8219-f2785d832eb3"),
                column: "Question",
                value: "Bekreft med bilde");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("dde428e6-e13b-4140-860b-b185661d8dc6"),
                column: "Question",
                value: "Bekreft med bilde");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("fd3d3290-b415-495d-8c38-bf6c6fb2a679"),
                columns: new[] { "BoolFalseText", "BoolTrueText" },
                values: new object[] { "Annet, ", "Mellom 75cm og 130cm over gulvet" });
        }
    }
}
