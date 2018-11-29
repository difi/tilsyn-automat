using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("9e184394-81bb-45cf-a157-dba79a3286d7"),
                column: "Name",
                value: "Saksbehandler");

            migrationBuilder.UpdateData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("e7a78cdc-49f9-4e6c-8abd-afcfc08ca5eb"),
                column: "Name",
                value: "Administrator");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("9e184394-81bb-45cf-a157-dba79a3286d7"),
                column: "Name",
                value: "Saksbehandlare");

            migrationBuilder.UpdateData(
                table: "RoleList",
                keyColumn: "Id",
                keyValue: new Guid("e7a78cdc-49f9-4e6c-8abd-afcfc08ca5eb"),
                column: "Name",
                value: "Admin");
        }
    }
}
