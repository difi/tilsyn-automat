using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("0ed22f35-94ec-46d1-9aad-615f91bbb1b0"),
                column: "BoolFalseText",
                value: "Nei");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("14b18d90-1b1f-4628-b15e-edc9afe5a0a1"),
                column: "BoolFalseText",
                value: "Nei");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("2583fbbf-12a3-475d-b610-41b5ad0327c1"),
                column: "BoolFalseText",
                value: "Nei");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("3ec18f01-3e59-4cb1-b4b3-75e0af67ac2f"),
                column: "BoolFalseText",
                value: "Nei");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("463efa96-5c19-4945-8bac-100a2b4c6916"),
                column: "BoolFalseText",
                value: "Nei");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("7c632541-119a-4dd5-b501-e0ba7e2caff2"),
                column: "BoolFalseText",
                value: "Nei");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("0ed22f35-94ec-46d1-9aad-615f91bbb1b0"),
                column: "BoolFalseText",
                value: "Nej");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("14b18d90-1b1f-4628-b15e-edc9afe5a0a1"),
                column: "BoolFalseText",
                value: "Nej");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("2583fbbf-12a3-475d-b610-41b5ad0327c1"),
                column: "BoolFalseText",
                value: "Nej");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("3ec18f01-3e59-4cb1-b4b3-75e0af67ac2f"),
                column: "BoolFalseText",
                value: "Nej");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("463efa96-5c19-4945-8bac-100a2b4c6916"),
                column: "BoolFalseText",
                value: "Nej");

            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("7c632541-119a-4dd5-b501-e0ba7e2caff2"),
                column: "BoolFalseText",
                value: "Nej");
        }
    }
}
