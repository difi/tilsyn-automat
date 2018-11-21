using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewIfParentCorrect",
                table: "AnswerList");

            migrationBuilder.DropColumn(
                name: "ViewIfParentFailed",
                table: "AnswerList");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ViewIfParentCorrect",
                table: "AnswerList",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ViewIfParentFailed",
                table: "AnswerList",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("89fd2205-1047-403d-a5bd-f70a1de2f247"),
                column: "ViewIfParentFailed",
                value: true);

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("9a51cc68-857e-4822-ac81-0ec3ebe7bf43"),
                column: "ViewIfParentCorrect",
                value: true);

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("bf459d05-702d-47d7-a5b7-19f8b3fb67c9"),
                column: "ViewIfParentFailed",
                value: true);

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("d7b40e3c-e7fa-44e5-b44f-750759c971cc"),
                column: "ViewIfParentFailed",
                value: true);

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("f69c1e45-99d8-4293-a242-c5ed9e126e99"),
                column: "ViewIfParentCorrect",
                value: true);
        }
    }
}
