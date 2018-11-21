using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeclarationTestGroupList");

            migrationBuilder.CreateTable(
                name: "DeclarationIndicatorGroupList",
                columns: table => new
                {
                    DeclarationItemId = table.Column<Guid>(nullable: false),
                    IndicatorItemId = table.Column<Guid>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclarationIndicatorGroupList", x => new { x.DeclarationItemId, x.IndicatorItemId });
                    table.ForeignKey(
                        name: "FK_DeclarationIndicatorGroupList_DeclarationList_DeclarationItemId",
                        column: x => x.DeclarationItemId,
                        principalTable: "DeclarationList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeclarationIndicatorGroupList_IndicatorList_IndicatorItemId",
                        column: x => x.IndicatorItemId,
                        principalTable: "IndicatorList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationIndicatorGroupList_IndicatorItemId",
                table: "DeclarationIndicatorGroupList",
                column: "IndicatorItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeclarationIndicatorGroupList");

            migrationBuilder.CreateTable(
                name: "DeclarationTestGroupList",
                columns: table => new
                {
                    TestGroupItemId = table.Column<Guid>(nullable: false),
                    DeclarationItemId = table.Column<Guid>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclarationTestGroupList", x => new { x.TestGroupItemId, x.DeclarationItemId });
                    table.ForeignKey(
                        name: "FK_DeclarationTestGroupList_DeclarationList_DeclarationItemId",
                        column: x => x.DeclarationItemId,
                        principalTable: "DeclarationList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeclarationTestGroupList_TestGroupList_TestGroupItemId",
                        column: x => x.TestGroupItemId,
                        principalTable: "TestGroupList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationTestGroupList_DeclarationItemId",
                table: "DeclarationTestGroupList",
                column: "DeclarationItemId");
        }
    }
}
