using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ViewIfOtherFailed",
                table: "AnswerList",
                newName: "ViewIfParentFailed");

            migrationBuilder.RenameColumn(
                name: "ViewIfOtherFaildId",
                table: "AnswerList",
                newName: "ViewIfParentFailedId");

            migrationBuilder.AddColumn<bool>(
                name: "ViewIfParentCorrect",
                table: "AnswerList",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ViewIfParentCorrectId",
                table: "AnswerList",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("9a51cc68-857e-4822-ac81-0ec3ebe7bf43"),
                columns: new[] { "ViewIfParentCorrect", "ViewIfParentCorrectId", "ViewIfParentFailed", "ViewIfParentFailedId" },
                values: new object[] { true, new Guid("d8611e84-0f00-4d75-bcab-cbf127fb68b5"), false, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("f69c1e45-99d8-4293-a242-c5ed9e126e99"),
                columns: new[] { "ViewIfParentCorrect", "ViewIfParentCorrectId", "ViewIfParentFailed", "ViewIfParentFailedId" },
                values: new object[] { true, new Guid("d8611e84-0f00-4d75-bcab-cbf127fb68b5"), false, new Guid("00000000-0000-0000-0000-000000000000") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewIfParentCorrect",
                table: "AnswerList");

            migrationBuilder.DropColumn(
                name: "ViewIfParentCorrectId",
                table: "AnswerList");

            migrationBuilder.RenameColumn(
                name: "ViewIfParentFailedId",
                table: "AnswerList",
                newName: "ViewIfOtherFaildId");

            migrationBuilder.RenameColumn(
                name: "ViewIfParentFailed",
                table: "AnswerList",
                newName: "ViewIfOtherFailed");

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("9a51cc68-857e-4822-ac81-0ec3ebe7bf43"),
                columns: new[] { "ViewIfOtherFaildId", "ViewIfOtherFailed" },
                values: new object[] { new Guid("d8611e84-0f00-4d75-bcab-cbf127fb68b5"), true });

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("f69c1e45-99d8-4293-a242-c5ed9e126e99"),
                columns: new[] { "ViewIfOtherFaildId", "ViewIfOtherFailed" },
                values: new object[] { new Guid("d8611e84-0f00-4d75-bcab-cbf127fb68b5"), true });
        }
    }
}
