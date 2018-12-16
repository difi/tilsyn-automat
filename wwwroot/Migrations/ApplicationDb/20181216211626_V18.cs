using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "SocialSecurityNumber",
                table: "UserList",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<long>(
                name: "OwenerCorporateIdentityNumber",
                table: "CompanyList",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CorporateIdentityNumber",
                table: "CompanyList",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("27e6f983-d5c8-4a18-a7f9-977c410e17f0"),
                column: "SocialSecurityNumber",
                value: 12089400420L);

            migrationBuilder.UpdateData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("3812f52e-55a0-48d0-9a9c-54147c2fe90c"),
                column: "SocialSecurityNumber",
                value: 12089400269L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SocialSecurityNumber",
                table: "UserList",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "OwenerCorporateIdentityNumber",
                table: "CompanyList",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CorporateIdentityNumber",
                table: "CompanyList",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("27e6f983-d5c8-4a18-a7f9-977c410e17f0"),
                column: "SocialSecurityNumber",
                value: "12089400420");

            migrationBuilder.UpdateData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("3812f52e-55a0-48d0-9a9c-54147c2fe90c"),
                column: "SocialSecurityNumber",
                value: "12089400269");
        }
    }
}
