using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeData_RequirementList_RequirementId",
                table: "OutcomeData");

            migrationBuilder.DropTable(
                name: "LogList");

            migrationBuilder.DropIndex(
                name: "IX_OutcomeData_RequirementId",
                table: "OutcomeData");

            migrationBuilder.DropColumn(
                name: "RequirementId",
                table: "OutcomeData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RequirementId",
                table: "OutcomeData",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LogList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CallParameter1 = table.Column<string>(nullable: true),
                    CallParameter2 = table.Column<string>(nullable: true),
                    Class = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Function = table.Column<string>(nullable: true),
                    ResultException = table.Column<string>(nullable: true),
                    ResultId = table.Column<Guid>(nullable: false),
                    ResultString = table.Column<string>(nullable: true),
                    ResultSucceeded = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogList", x => x.Id);
                });

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
    }
}
