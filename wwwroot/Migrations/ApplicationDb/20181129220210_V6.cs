using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurposeOfTestId",
                table: "DeclarationTestItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationTestItem_PurposeOfTestId",
                table: "DeclarationTestItem",
                column: "PurposeOfTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationTestItem_VlPurposeOfTest_PurposeOfTestId",
                table: "DeclarationTestItem",
                column: "PurposeOfTestId",
                principalTable: "VlPurposeOfTest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationTestItem_VlPurposeOfTest_PurposeOfTestId",
                table: "DeclarationTestItem");

            migrationBuilder.DropIndex(
                name: "IX_DeclarationTestItem_PurposeOfTestId",
                table: "DeclarationTestItem");

            migrationBuilder.DropColumn(
                name: "PurposeOfTestId",
                table: "DeclarationTestItem");
        }
    }
}
