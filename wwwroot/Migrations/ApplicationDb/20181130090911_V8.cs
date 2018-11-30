using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ViewIfParentFailedId",
                table: "AnswerList",
                newName: "LinkedIfParentFailedId");

            migrationBuilder.RenameColumn(
                name: "ViewIfParentCorrectId",
                table: "AnswerList",
                newName: "LinkedIfParentCorrectId");

            migrationBuilder.AddColumn<bool>(
                name: "AlwaysVisible",
                table: "AnswerList",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("9aea071e-7263-4b2e-8cd7-5193fbbe5b77"),
                column: "AlwaysVisible",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlwaysVisible",
                table: "AnswerList");

            migrationBuilder.RenameColumn(
                name: "LinkedIfParentFailedId",
                table: "AnswerList",
                newName: "ViewIfParentFailedId");

            migrationBuilder.RenameColumn(
                name: "LinkedIfParentCorrectId",
                table: "AnswerList",
                newName: "ViewIfParentCorrectId");
        }
    }
}
