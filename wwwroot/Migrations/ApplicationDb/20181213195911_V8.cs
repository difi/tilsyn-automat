using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResultString",
                table: "IndicatorOutcomeList",
                newName: "ResultString2");

            migrationBuilder.AddColumn<Guid>(
                name: "IndicatorOutcomeItemId",
                table: "OutcomeData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResultString1",
                table: "IndicatorOutcomeList",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("0025bb09-6dfe-4069-ae6b-27cb28ba8300"),
                columns: new[] { "ResultString1", "ResultString2" },
                values: new object[] { "1,1", null });

            migrationBuilder.UpdateData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("4edceffe-eb77-4ca0-a498-24be5372d333"),
                columns: new[] { "ResultString1", "ResultString2" },
                values: new object[] { "2,2,1", "2,2,2,1" });

            migrationBuilder.UpdateData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("6cd1b621-12e6-4a03-bd6e-a7c8b39de251"),
                columns: new[] { "ResultString1", "ResultString2" },
                values: new object[] { "2,2,2,2", null });

            migrationBuilder.UpdateData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("a9b2bb20-7240-4a93-ba1a-ae270e8679f1"),
                columns: new[] { "ResultString1", "ResultString2" },
                values: new object[] { "2,1", null });

            migrationBuilder.UpdateData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("d18a7bce-556c-45cc-87d7-c765261166d5"),
                columns: new[] { "ResultString1", "ResultString2" },
                values: new object[] { "1,2,2,2", null });

            migrationBuilder.UpdateData(
                table: "IndicatorOutcomeList",
                keyColumn: "Id",
                keyValue: new Guid("d438e931-f57c-4a5c-bb5c-3e3a66824827"),
                columns: new[] { "ResultString1", "ResultString2" },
                values: new object[] { "1,2,1", "1,2,2,1" });

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeData_IndicatorOutcomeItemId",
                table: "OutcomeData",
                column: "IndicatorOutcomeItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeData_IndicatorOutcomeList_IndicatorOutcomeItemId",
                table: "OutcomeData",
                column: "IndicatorOutcomeItemId",
                principalTable: "IndicatorOutcomeList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeData_IndicatorOutcomeList_IndicatorOutcomeItemId",
                table: "OutcomeData");

            migrationBuilder.DropIndex(
                name: "IX_OutcomeData_IndicatorOutcomeItemId",
                table: "OutcomeData");

            migrationBuilder.DropColumn(
                name: "IndicatorOutcomeItemId",
                table: "OutcomeData");

            migrationBuilder.DropColumn(
                name: "ResultString1",
                table: "IndicatorOutcomeList");

            migrationBuilder.RenameColumn(
                name: "ResultString2",
                table: "IndicatorOutcomeList",
                newName: "ResultString");

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
        }
    }
}
