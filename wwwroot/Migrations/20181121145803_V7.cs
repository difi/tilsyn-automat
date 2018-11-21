using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeData_RequirementList_RequirementItemId",
                table: "OutcomeData");

            migrationBuilder.DropIndex(
                name: "IX_OutcomeData_RequirementItemId",
                table: "OutcomeData");

            migrationBuilder.DropColumn(
                name: "RequirementItemId",
                table: "OutcomeData");

            migrationBuilder.AddColumn<Guid>(
                name: "RequirementId",
                table: "OutcomeData",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeData_RequirementId",
                table: "OutcomeData",
                column: "RequirementId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeData_RequirementList_RequirementId",
                table: "OutcomeData",
                column: "RequirementId",
                principalTable: "RequirementList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeData_RequirementList_RequirementId",
                table: "OutcomeData");

            migrationBuilder.DropIndex(
                name: "IX_OutcomeData_RequirementId",
                table: "OutcomeData");

            migrationBuilder.DropColumn(
                name: "RequirementId",
                table: "OutcomeData");

            migrationBuilder.AddColumn<Guid>(
                name: "RequirementItemId",
                table: "OutcomeData",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeData_RequirementItemId",
                table: "OutcomeData",
                column: "RequirementItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeData_RequirementList_RequirementItemId",
                table: "OutcomeData",
                column: "RequirementItemId",
                principalTable: "RequirementList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
