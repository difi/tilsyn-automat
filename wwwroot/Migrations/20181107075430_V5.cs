using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneCountryCode",
                table: "UserList",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DeclarationList",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneCountryCode",
                table: "ContactPersonList",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("04be8925-63ae-4253-8930-828e624cbea1"),
                column: "PhoneCountryCode",
                value: "0047");

            migrationBuilder.UpdateData(
                table: "UserList",
                keyColumn: "Id",
                keyValue: new Guid("1b21a2a1-36f5-47a3-a27b-49e241faafbe"),
                column: "PhoneCountryCode",
                value: "0047");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneCountryCode",
                table: "UserList");

            migrationBuilder.DropColumn(
                name: "PhoneCountryCode",
                table: "ContactPersonList");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DeclarationList",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
