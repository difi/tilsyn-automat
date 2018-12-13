using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndicatorOutcomeAnswerList_AnswerList_AnswerItemId",
                table: "IndicatorOutcomeAnswerList");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicatorOutcomeAnswerList_IndicatorOutcomeList_IndicatorOutcomeItemId",
                table: "IndicatorOutcomeAnswerList");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicatorOutcomeAnswerList_VlTypeOfResult_ResultId",
                table: "IndicatorOutcomeAnswerList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IndicatorOutcomeAnswerList",
                table: "IndicatorOutcomeAnswerList");

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeAnswerList",
                keyColumn: "Id",
                keyValue: new Guid("708cc5c8-d433-4bf4-b179-8d8c81b6bd6e"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeAnswerList",
                keyColumn: "Id",
                keyValue: new Guid("d48f8630-230a-4285-8b78-6bb9049054b1"));

            migrationBuilder.RenameTable(
                name: "IndicatorOutcomeAnswerList",
                newName: "IndicatorOutcomeAnswerItem");

            migrationBuilder.RenameIndex(
                name: "IX_IndicatorOutcomeAnswerList_ResultId",
                table: "IndicatorOutcomeAnswerItem",
                newName: "IX_IndicatorOutcomeAnswerItem_ResultId");

            migrationBuilder.RenameIndex(
                name: "IX_IndicatorOutcomeAnswerList_IndicatorOutcomeItemId",
                table: "IndicatorOutcomeAnswerItem",
                newName: "IX_IndicatorOutcomeAnswerItem_IndicatorOutcomeItemId");

            migrationBuilder.RenameIndex(
                name: "IX_IndicatorOutcomeAnswerList_AnswerItemId",
                table: "IndicatorOutcomeAnswerItem",
                newName: "IX_IndicatorOutcomeAnswerItem_AnswerItemId");

            migrationBuilder.AddColumn<string>(
                name: "ResultString",
                table: "IndicatorOutcomeList",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndicatorOutcomeAnswerItem",
                table: "IndicatorOutcomeAnswerItem",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("0025bb09-6dfe-4069-ae6b-27cb28ba8300"),
                column: "ResultString",
                value: "1,1");

            migrationBuilder.UpdateData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("4edceffe-eb77-4ca0-a498-24be5372d333"),
                column: "ResultString",
                value: "2,2,1|2,2,2,1");

            migrationBuilder.UpdateData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("6cd1b621-12e6-4a03-bd6e-a7c8b39de251"),
                column: "ResultString",
                value: "2,2,2,2");

            migrationBuilder.UpdateData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("a9b2bb20-7240-4a93-ba1a-ae270e8679f1"),
                column: "ResultString",
                value: "2,1");

            migrationBuilder.UpdateData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("d18a7bce-556c-45cc-87d7-c765261166d5"),
                column: "ResultString",
                value: "1,2,2,2");

            migrationBuilder.UpdateData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("d438e931-f57c-4a5c-bb5c-3e3a66824827"),
                column: "ResultString",
                value: "1,2,1|1,2,2,1");

            migrationBuilder.AddForeignKey(
                name: "FK_IndicatorOutcomeAnswerItem_AnswerList_AnswerItemId",
                table: "IndicatorOutcomeAnswerItem",
                column: "AnswerItemId",
                principalTable: "AnswerList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IndicatorOutcomeAnswerItem_IndicatorOutcomeList_IndicatorOutcomeItemId",
                table: "IndicatorOutcomeAnswerItem",
                column: "IndicatorOutcomeItemId",
                principalTable: "IndicatorOutcomeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IndicatorOutcomeAnswerItem_VlTypeOfResult_ResultId",
                table: "IndicatorOutcomeAnswerItem",
                column: "ResultId",
                principalTable: "VlTypeOfResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndicatorOutcomeAnswerItem_AnswerList_AnswerItemId",
                table: "IndicatorOutcomeAnswerItem");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicatorOutcomeAnswerItem_IndicatorOutcomeList_IndicatorOutcomeItemId",
                table: "IndicatorOutcomeAnswerItem");

            migrationBuilder.DropForeignKey(
                name: "FK_IndicatorOutcomeAnswerItem_VlTypeOfResult_ResultId",
                table: "IndicatorOutcomeAnswerItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IndicatorOutcomeAnswerItem",
                table: "IndicatorOutcomeAnswerItem");

            migrationBuilder.DropColumn(
                name: "ResultString",
                table: "IndicatorOutcomeList");

            migrationBuilder.RenameTable(
                name: "IndicatorOutcomeAnswerItem",
                newName: "IndicatorOutcomeAnswerList");

            migrationBuilder.RenameIndex(
                name: "IX_IndicatorOutcomeAnswerItem_ResultId",
                table: "IndicatorOutcomeAnswerList",
                newName: "IX_IndicatorOutcomeAnswerList_ResultId");

            migrationBuilder.RenameIndex(
                name: "IX_IndicatorOutcomeAnswerItem_IndicatorOutcomeItemId",
                table: "IndicatorOutcomeAnswerList",
                newName: "IX_IndicatorOutcomeAnswerList_IndicatorOutcomeItemId");

            migrationBuilder.RenameIndex(
                name: "IX_IndicatorOutcomeAnswerItem_AnswerItemId",
                table: "IndicatorOutcomeAnswerList",
                newName: "IX_IndicatorOutcomeAnswerList_AnswerItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndicatorOutcomeAnswerList",
                table: "IndicatorOutcomeAnswerList",
                column: "Id");

            migrationBuilder.InsertData(
                table: "IndicatorOutcomeAnswerList",
                columns: new[] { "Id", "AnswerItemId", "IndicatorOutcomeItemId", "ResultId" },
                values: new object[] { new Guid("d48f8630-230a-4285-8b78-6bb9049054b1"), new Guid("02d2db89-3717-48e1-883e-8e526bf6c727"), new Guid("0025bb09-6dfe-4069-ae6b-27cb28ba8300"), 1 });

            migrationBuilder.InsertData(
                table: "IndicatorOutcomeAnswerList",
                columns: new[] { "Id", "AnswerItemId", "IndicatorOutcomeItemId", "ResultId" },
                values: new object[] { new Guid("708cc5c8-d433-4bf4-b179-8d8c81b6bd6e"), new Guid("a1964762-5c8f-40bb-a22d-c907149079d4"), new Guid("0025bb09-6dfe-4069-ae6b-27cb28ba8300"), 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_IndicatorOutcomeAnswerList_AnswerList_AnswerItemId",
                table: "IndicatorOutcomeAnswerList",
                column: "AnswerItemId",
                principalTable: "AnswerList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IndicatorOutcomeAnswerList_IndicatorOutcomeList_IndicatorOutcomeItemId",
                table: "IndicatorOutcomeAnswerList",
                column: "IndicatorOutcomeItemId",
                principalTable: "IndicatorOutcomeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IndicatorOutcomeAnswerList_VlTypeOfResult_ResultId",
                table: "IndicatorOutcomeAnswerList",
                column: "ResultId",
                principalTable: "VlTypeOfResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
