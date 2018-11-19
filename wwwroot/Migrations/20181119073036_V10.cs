using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("89fd2205-1047-403d-a5bd-f70a1de2f247"),
                columns: new[] { "MaxInt", "MinInt" },
                values: new object[] { -1, 150 });

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("bf459d05-702d-47d7-a5b7-19f8b3fb67c9"),
                columns: new[] { "MaxInt", "MinInt" },
                values: new object[] { -1, 220 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("89fd2205-1047-403d-a5bd-f70a1de2f247"),
                columns: new[] { "MaxInt", "MinInt" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("bf459d05-702d-47d7-a5b7-19f8b3fb67c9"),
                columns: new[] { "MaxInt", "MinInt" },
                values: new object[] { 0, 0 });
        }
    }
}
