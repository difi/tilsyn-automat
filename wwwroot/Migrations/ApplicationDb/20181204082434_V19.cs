using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("6876174d-2e2c-484b-a9a7-14cb63359a30"),
                column: "AnswerItemId",
                value: new Guid("d7b40e3c-e7fa-44e5-b44f-750759c971cc"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("6876174d-2e2c-484b-a9a7-14cb63359a30"),
                column: "AnswerItemId",
                value: new Guid("02d2db89-3717-48e1-883e-8e526bf6c727"));
        }
    }
}
