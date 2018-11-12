using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeItem_DeclarationList_DeclarationItemId",
                table: "OutcomeItem");

            migrationBuilder.DropIndex(
                name: "IX_OutcomeItem_DeclarationItemId",
                table: "OutcomeItem");

            migrationBuilder.AddColumn<Guid>(
                name: "DeclarationTestItemId",
                table: "OutcomeItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeItem_DeclarationTestItemId",
                table: "OutcomeItem",
                column: "DeclarationTestItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeItem_DeclarationTestItem_DeclarationTestItemId",
                table: "OutcomeItem",
                column: "DeclarationTestItemId",
                principalTable: "DeclarationTestItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeItem_DeclarationTestItem_DeclarationTestItemId",
                table: "OutcomeItem");

            migrationBuilder.DropIndex(
                name: "IX_OutcomeItem_DeclarationTestItemId",
                table: "OutcomeItem");

            migrationBuilder.DropColumn(
                name: "DeclarationTestItemId",
                table: "OutcomeItem");

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeItem_DeclarationItemId",
                table: "OutcomeItem",
                column: "DeclarationItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeItem_DeclarationList_DeclarationItemId",
                table: "OutcomeItem",
                column: "DeclarationItemId",
                principalTable: "DeclarationList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
