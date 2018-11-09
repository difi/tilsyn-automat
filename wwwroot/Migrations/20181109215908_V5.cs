using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequirementUserPrerequisite",
                columns: table => new
                {
                    RequirementItemId = table.Column<Guid>(nullable: false),
                    ValueListUserPrerequisiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementUserPrerequisite", x => new { x.RequirementItemId, x.ValueListUserPrerequisiteId });
                    table.ForeignKey(
                        name: "FK_RequirementUserPrerequisite_RequirementItem_RequirementItemId",
                        column: x => x.RequirementItemId,
                        principalTable: "RequirementItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequirementUserPrerequisite_VlUserPrerequisiteList_ValueListUserPrerequisiteId",
                        column: x => x.ValueListUserPrerequisiteId,
                        principalTable: "VlUserPrerequisiteList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequirementUserPrerequisite_ValueListUserPrerequisiteId",
                table: "RequirementUserPrerequisite",
                column: "ValueListUserPrerequisiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequirementUserPrerequisite");
        }
    }
}
