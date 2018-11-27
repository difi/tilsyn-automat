using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "DeclarationList",
                newName: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationList_StatusId",
                table: "DeclarationList",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationList_VlTypeOfStatus_StatusId",
                table: "DeclarationList",
                column: "StatusId",
                principalTable: "VlTypeOfStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationList_VlTypeOfStatus_StatusId",
                table: "DeclarationList");

            migrationBuilder.DropIndex(
                name: "IX_DeclarationList_StatusId",
                table: "DeclarationList");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "DeclarationList",
                newName: "Status");
        }
    }
}
