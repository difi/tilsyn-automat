using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("438787f3-b33b-489c-b5a8-2f046a634dea"),
                column: "Order",
                value: 3);

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("9aea071e-7263-4b2e-8cd7-5193fbbe5b77"),
                column: "Order",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("438787f3-b33b-489c-b5a8-2f046a634dea"),
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("9aea071e-7263-4b2e-8cd7-5193fbbe5b77"),
                column: "Order",
                value: 1);
        }
    }
}
