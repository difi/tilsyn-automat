using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndicatorOutcomeAnswerItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndicatorOutcomeAnswerItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AnswerItemId = table.Column<Guid>(nullable: false),
                    IndicatorOutcomeItemId = table.Column<Guid>(nullable: false),
                    ResultId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicatorOutcomeAnswerItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicatorOutcomeAnswerItem_AnswerList_AnswerItemId",
                        column: x => x.AnswerItemId,
                        principalTable: "AnswerList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicatorOutcomeAnswerItem_IndicatorOutcomeList_IndicatorOutcomeItemId",
                        column: x => x.IndicatorOutcomeItemId,
                        principalTable: "IndicatorOutcomeList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndicatorOutcomeAnswerItem_VlTypeOfResult_ResultId",
                        column: x => x.ResultId,
                        principalTable: "VlTypeOfResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorOutcomeAnswerItem_AnswerItemId",
                table: "IndicatorOutcomeAnswerItem",
                column: "AnswerItemId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorOutcomeAnswerItem_IndicatorOutcomeItemId",
                table: "IndicatorOutcomeAnswerItem",
                column: "IndicatorOutcomeItemId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorOutcomeAnswerItem_ResultId",
                table: "IndicatorOutcomeAnswerItem",
                column: "ResultId");
        }
    }
}
