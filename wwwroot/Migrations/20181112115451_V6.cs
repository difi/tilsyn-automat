using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationList_DeclarationTestItem_DeclarationTestItemId",
                table: "DeclarationList");

            migrationBuilder.DropIndex(
                name: "IX_DeclarationList_DeclarationTestItemId",
                table: "DeclarationList");

            migrationBuilder.DropColumn(
                name: "DeclarationTestItemId",
                table: "DeclarationList");

            migrationBuilder.AddColumn<Guid>(
                name: "DeclarationItemId",
                table: "DeclarationTestItem",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationTestItem_DeclarationItemId",
                table: "DeclarationTestItem",
                column: "DeclarationItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationTestItem_DeclarationList_DeclarationItemId",
                table: "DeclarationTestItem",
                column: "DeclarationItemId",
                principalTable: "DeclarationList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationTestItem_DeclarationList_DeclarationItemId",
                table: "DeclarationTestItem");

            migrationBuilder.DropIndex(
                name: "IX_DeclarationTestItem_DeclarationItemId",
                table: "DeclarationTestItem");

            migrationBuilder.DropColumn(
                name: "DeclarationItemId",
                table: "DeclarationTestItem");

            migrationBuilder.AddColumn<Guid>(
                name: "DeclarationTestItemId",
                table: "DeclarationList",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationList_DeclarationTestItemId",
                table: "DeclarationList",
                column: "DeclarationTestItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationList_DeclarationTestItem_DeclarationTestItemId",
                table: "DeclarationList",
                column: "DeclarationTestItemId",
                principalTable: "DeclarationTestItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
