using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeData_VlTypeOfResult_ResultId",
                table: "OutcomeData");

            migrationBuilder.DropForeignKey(
                name: "FK_RuleData_VlTypeOfResult_ResultId",
                table: "RuleData");

            migrationBuilder.AlterColumn<int>(
                name: "ResultId",
                table: "RuleData",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ResultId",
                table: "OutcomeData",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResultId",
                table: "AnswerData",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AnswerData_ResultId",
                table: "AnswerData",
                column: "ResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerData_VlTypeOfResult_ResultId",
                table: "AnswerData",
                column: "ResultId",
                principalTable: "VlTypeOfResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeData_VlTypeOfResult_ResultId",
                table: "OutcomeData",
                column: "ResultId",
                principalTable: "VlTypeOfResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RuleData_VlTypeOfResult_ResultId",
                table: "RuleData",
                column: "ResultId",
                principalTable: "VlTypeOfResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerData_VlTypeOfResult_ResultId",
                table: "AnswerData");

            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeData_VlTypeOfResult_ResultId",
                table: "OutcomeData");

            migrationBuilder.DropForeignKey(
                name: "FK_RuleData_VlTypeOfResult_ResultId",
                table: "RuleData");

            migrationBuilder.DropIndex(
                name: "IX_AnswerData_ResultId",
                table: "AnswerData");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "AnswerData");

            migrationBuilder.AlterColumn<int>(
                name: "ResultId",
                table: "RuleData",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ResultId",
                table: "OutcomeData",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeData_VlTypeOfResult_ResultId",
                table: "OutcomeData",
                column: "ResultId",
                principalTable: "VlTypeOfResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RuleData_VlTypeOfResult_ResultId",
                table: "RuleData",
                column: "ResultId",
                principalTable: "VlTypeOfResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
