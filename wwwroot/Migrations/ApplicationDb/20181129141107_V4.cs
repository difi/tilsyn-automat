using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TestGroupItemId",
                table: "DeclarationIndicatorGroupList",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationIndicatorGroupList_TestGroupItemId",
                table: "DeclarationIndicatorGroupList",
                column: "TestGroupItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationIndicatorGroupList_TestGroupList_TestGroupItemId",
                table: "DeclarationIndicatorGroupList",
                column: "TestGroupItemId",
                principalTable: "TestGroupList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationIndicatorGroupList_TestGroupList_TestGroupItemId",
                table: "DeclarationIndicatorGroupList");

            migrationBuilder.DropIndex(
                name: "IX_DeclarationIndicatorGroupList_TestGroupItemId",
                table: "DeclarationIndicatorGroupList");

            migrationBuilder.DropColumn(
                name: "TestGroupItemId",
                table: "DeclarationIndicatorGroupList");
        }
    }
}
