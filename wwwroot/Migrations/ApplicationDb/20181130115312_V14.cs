using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("5544b740-0b5f-400c-b7b2-7e6472d4160b"),
                columns: new[] { "MaxInt", "MinInt" },
                values: new object[] { -1, 220 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("5544b740-0b5f-400c-b7b2-7e6472d4160b"),
                columns: new[] { "MaxInt", "MinInt" },
                values: new object[] { 130, 75 });
        }
    }
}
