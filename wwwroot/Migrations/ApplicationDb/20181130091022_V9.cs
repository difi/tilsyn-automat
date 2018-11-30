using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LinkedIfParentFailedId",
                table: "AnswerList",
                newName: "LinkedParentFailedId");

            migrationBuilder.RenameColumn(
                name: "LinkedIfParentCorrectId",
                table: "AnswerList",
                newName: "LinkedParentCorrectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LinkedParentFailedId",
                table: "AnswerList",
                newName: "LinkedIfParentFailedId");

            migrationBuilder.RenameColumn(
                name: "LinkedParentCorrectId",
                table: "AnswerList",
                newName: "LinkedIfParentCorrectId");
        }
    }
}
