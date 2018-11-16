using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_OutcomeDataList",
                table: "OutcomeDataList");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_OutcomeData",
                table: "OutcomeData",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeData_DeclarationTestItem_DeclarationTestItemId",
                table: "OutcomeData",
                column: "DeclarationTestItemId",
                principalTable: "DeclarationTestItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_OutcomeData",
                table: "OutcomeData");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_OutcomeDataList",
                table: "OutcomeDataList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeDataList_DeclarationTestItem_DeclarationTestItemId",
                table: "OutcomeDataList",
                column: "DeclarationTestItemId",
                principalTable: "DeclarationTestItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
        }
    }
}
