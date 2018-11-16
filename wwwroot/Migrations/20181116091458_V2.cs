using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeData_DeclarationTestItem_DeclarationTestItemId",
                table: "OutcomeData");

            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeData_RequirementList_RequirementItemId",
                table: "OutcomeData");

            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeData_VlTypeOfResult_ResultId",
                table: "OutcomeData");

            migrationBuilder.DropForeignKey(
                name: "FK_RuleData_OutcomeData_OutcomeDataId",
                table: "RuleData");

            migrationBuilder.DropForeignKey(
                name: "FK_RuleData_RuleList_RuleId",
                table: "RuleData");

            migrationBuilder.DropIndex(
                name: "IX_RuleData_RuleId",
                table: "RuleData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OutcomeData",
                table: "OutcomeData");

            migrationBuilder.DropColumn(
                name: "RuleId",
                table: "RuleData");

            migrationBuilder.RenameTable(
                name: "OutcomeData",
                newName: "OutcomeDataList");

            migrationBuilder.RenameIndex(
                name: "IX_OutcomeData_ResultId",
                table: "OutcomeDataList",
                newName: "IX_OutcomeDataList_ResultId");

            migrationBuilder.RenameIndex(
                name: "IX_OutcomeData_RequirementItemId",
                table: "OutcomeDataList",
                newName: "IX_OutcomeDataList_RequirementItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OutcomeData_DeclarationTestItemId",
                table: "OutcomeDataList",
                newName: "IX_OutcomeDataList_DeclarationTestItemId");

            migrationBuilder.AddColumn<Guid>(
                name: "RuleItemId",
                table: "RuleData",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_OutcomeDataList",
                table: "OutcomeDataList",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RuleData_RuleItemId",
                table: "RuleData",
                column: "RuleItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeDataList_DeclarationTestItem_DeclarationTestItemId",
                table: "OutcomeDataList",
                column: "DeclarationTestItemId",
                principalTable: "DeclarationTestItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeDataList_RequirementList_RequirementItemId",
                table: "OutcomeDataList",
                column: "RequirementItemId",
                principalTable: "RequirementList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeDataList_VlTypeOfResult_ResultId",
                table: "OutcomeDataList",
                column: "ResultId",
                principalTable: "VlTypeOfResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RuleData_OutcomeDataList_OutcomeDataId",
                table: "RuleData",
                column: "OutcomeDataId",
                principalTable: "OutcomeDataList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RuleData_RuleList_RuleItemId",
                table: "RuleData",
                column: "RuleItemId",
                principalTable: "RuleList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeDataList_DeclarationTestItem_DeclarationTestItemId",
                table: "OutcomeDataList");

            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeDataList_RequirementList_RequirementItemId",
                table: "OutcomeDataList");

            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeDataList_VlTypeOfResult_ResultId",
                table: "OutcomeDataList");

            migrationBuilder.DropForeignKey(
                name: "FK_RuleData_OutcomeDataList_OutcomeDataId",
                table: "RuleData");

            migrationBuilder.DropForeignKey(
                name: "FK_RuleData_RuleList_RuleItemId",
                table: "RuleData");

            migrationBuilder.DropIndex(
                name: "IX_RuleData_RuleItemId",
                table: "RuleData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OutcomeDataList",
                table: "OutcomeDataList");

            migrationBuilder.DropColumn(
                name: "RuleItemId",
                table: "RuleData");

            migrationBuilder.RenameTable(
                name: "OutcomeDataList",
                newName: "OutcomeData");

            migrationBuilder.RenameIndex(
                name: "IX_OutcomeDataList_ResultId",
                table: "OutcomeData",
                newName: "IX_OutcomeData_ResultId");

            migrationBuilder.RenameIndex(
                name: "IX_OutcomeDataList_RequirementItemId",
                table: "OutcomeData",
                newName: "IX_OutcomeData_RequirementItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OutcomeDataList_DeclarationTestItemId",
                table: "OutcomeData",
                newName: "IX_OutcomeData_DeclarationTestItemId");

            migrationBuilder.AddColumn<Guid>(
                name: "RuleId",
                table: "RuleData",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OutcomeData",
                table: "OutcomeData",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RuleData_RuleId",
                table: "RuleData",
                column: "RuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeData_DeclarationTestItem_DeclarationTestItemId",
                table: "OutcomeData",
                column: "DeclarationTestItemId",
                principalTable: "DeclarationTestItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeData_RequirementList_RequirementItemId",
                table: "OutcomeData",
                column: "RequirementItemId",
                principalTable: "RequirementList",
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
                name: "FK_RuleData_OutcomeData_OutcomeDataId",
                table: "RuleData",
                column: "OutcomeDataId",
                principalTable: "OutcomeData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RuleData_RuleList_RuleId",
                table: "RuleData",
                column: "RuleId",
                principalTable: "RuleList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
