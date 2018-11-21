using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequirementList_IndicatorList_IndicatorItemId",
                table: "RequirementList");

            migrationBuilder.DropIndex(
                name: "IX_RequirementList_IndicatorItemId",
                table: "RequirementList");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RequirementList_IndicatorItemId",
                table: "RequirementList",
                column: "IndicatorItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RequirementList_IndicatorList_IndicatorItemId",
                table: "RequirementList",
                column: "IndicatorItemId",
                principalTable: "IndicatorList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
