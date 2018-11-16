using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeDataList_DeclarationTestItem_DeclarationTestItemId",
                table: "OutcomeDataList");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeclarationTestItemId",
                table: "OutcomeDataList",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeDataList_DeclarationTestItem_DeclarationTestItemId",
                table: "OutcomeDataList",
                column: "DeclarationTestItemId",
                principalTable: "DeclarationTestItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeDataList_DeclarationTestItem_DeclarationTestItemId",
                table: "OutcomeDataList");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeclarationTestItemId",
                table: "OutcomeDataList",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeDataList_DeclarationTestItem_DeclarationTestItemId",
                table: "OutcomeDataList",
                column: "DeclarationTestItemId",
                principalTable: "DeclarationTestItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
