using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChapterHeading",
                table: "RequirementItem");

            migrationBuilder.DropColumn(
                name: "ChapterNumber",
                table: "RequirementItem");

            migrationBuilder.DropColumn(
                name: "Standard",
                table: "RequirementItem");

            migrationBuilder.CreateTable(
                name: "VlTypeOfAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlTypeOfAnswer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RuleItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Instruction = table.Column<string>(nullable: true),
                    Illustration = table.Column<string>(nullable: true),
                    HelpText = table.Column<string>(nullable: true),
                    ToolsNeed = table.Column<string>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    ChapterNumber = table.Column<string>(nullable: true),
                    ChapterHeading = table.Column<string>(nullable: true),
                    TypeOfAnswerId = table.Column<int>(nullable: true),
                    RequirementItemId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RuleItem_RequirementItem_RequirementItemId",
                        column: x => x.RequirementItemId,
                        principalTable: "RequirementItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RuleItem_VlTypeOfAnswer_TypeOfAnswerId",
                        column: x => x.TypeOfAnswerId,
                        principalTable: "VlTypeOfAnswer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "VlTypeOfAnswer",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 1, "string" },
                    { 2, "bool" },
                    { 3, "image" },
                    { 4, "int" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RuleItem_RequirementItemId",
                table: "RuleItem",
                column: "RequirementItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleItem_TypeOfAnswerId",
                table: "RuleItem",
                column: "TypeOfAnswerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RuleItem");

            migrationBuilder.DropTable(
                name: "VlTypeOfAnswer");

            migrationBuilder.AddColumn<string>(
                name: "ChapterHeading",
                table: "RequirementItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChapterNumber",
                table: "RequirementItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Standard",
                table: "RequirementItem",
                nullable: true);
        }
    }
}
