using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationTestItem_ValueListFinishedStatus_FinishedStatusId",
                table: "DeclarationTestItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ValueListFinishedStatus",
                table: "ValueListFinishedStatus");

            migrationBuilder.RenameTable(
                name: "ValueListFinishedStatus",
                newName: "FinishedStatusList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinishedStatusList",
                table: "FinishedStatusList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationTestItem_FinishedStatusList_FinishedStatusId",
                table: "DeclarationTestItem",
                column: "FinishedStatusId",
                principalTable: "FinishedStatusList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationTestItem_FinishedStatusList_FinishedStatusId",
                table: "DeclarationTestItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinishedStatusList",
                table: "FinishedStatusList");

            migrationBuilder.RenameTable(
                name: "FinishedStatusList",
                newName: "ValueListFinishedStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ValueListFinishedStatus",
                table: "ValueListFinishedStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationTestItem_ValueListFinishedStatus_FinishedStatusId",
                table: "DeclarationTestItem",
                column: "FinishedStatusId",
                principalTable: "ValueListFinishedStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
