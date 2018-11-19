using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ViewIfParentFailed",
                table: "RuleList",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "RuleList",
                keyColumn: "Id",
                keyValue: new Guid("b504bde7-1394-4e5c-84d3-a3ac53fc7dd6"),
                column: "ViewIfParentFailed",
                value: true);

            migrationBuilder.UpdateData(
                table: "RuleList",
                keyColumn: "Id",
                keyValue: new Guid("b64cac7e-6525-49e8-9112-0238e1588ed8"),
                column: "ViewIfParentFailed",
                value: true);

            migrationBuilder.UpdateData(
                table: "RuleList",
                keyColumn: "Id",
                keyValue: new Guid("b9498453-f173-499a-b01d-91cb469cc5ec"),
                column: "ViewIfParentFailed",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewIfParentFailed",
                table: "RuleList");
        }
    }
}
