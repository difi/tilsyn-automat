using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("6876174d-2e2c-484b-a9a7-14cb63359a30"),
                column: "Question",
                value: "Beskriv hindringene i kundens betjeningsområde:");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("6876174d-2e2c-484b-a9a7-14cb63359a30"),
                column: "Question",
                value: "Beskriv hindringene i kundens betjeningsområde.");
        }
    }
}
