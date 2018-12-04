using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerItemLanguage_AnswerList_AnswerItemId",
                table: "AnswerItemLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerItemLanguage_LanguageList_LanguageItemId",
                table: "AnswerItemLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswerItemLanguage",
                table: "AnswerItemLanguage");

            migrationBuilder.RenameTable(
                name: "AnswerItemLanguage",
                newName: "AnswerLanguageList");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerItemLanguage_LanguageItemId",
                table: "AnswerLanguageList",
                newName: "IX_AnswerLanguageList_LanguageItemId");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerItemLanguage_AnswerItemId",
                table: "AnswerLanguageList",
                newName: "IX_AnswerLanguageList_AnswerItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswerLanguageList",
                table: "AnswerLanguageList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerLanguageList_AnswerList_AnswerItemId",
                table: "AnswerLanguageList",
                column: "AnswerItemId",
                principalTable: "AnswerList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerLanguageList_LanguageList_LanguageItemId",
                table: "AnswerLanguageList",
                column: "LanguageItemId",
                principalTable: "LanguageList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerLanguageList_AnswerList_AnswerItemId",
                table: "AnswerLanguageList");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerLanguageList_LanguageList_LanguageItemId",
                table: "AnswerLanguageList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswerLanguageList",
                table: "AnswerLanguageList");

            migrationBuilder.RenameTable(
                name: "AnswerLanguageList",
                newName: "AnswerItemLanguage");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerLanguageList_LanguageItemId",
                table: "AnswerItemLanguage",
                newName: "IX_AnswerItemLanguage_LanguageItemId");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerLanguageList_AnswerItemId",
                table: "AnswerItemLanguage",
                newName: "IX_AnswerItemLanguage_AnswerItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswerItemLanguage",
                table: "AnswerItemLanguage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerItemLanguage_AnswerList_AnswerItemId",
                table: "AnswerItemLanguage",
                column: "AnswerItemId",
                principalTable: "AnswerList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerItemLanguage_LanguageList_LanguageItemId",
                table: "AnswerItemLanguage",
                column: "LanguageItemId",
                principalTable: "LanguageList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
