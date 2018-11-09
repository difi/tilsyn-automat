using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CaseNumber",
                table: "DeclarationTestItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FinishedStatusId",
                table: "DeclarationTestItem",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OutcomeItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DeclarationItemId = table.Column<Guid>(nullable: false),
                    IndicatorId = table.Column<int>(nullable: false),
                    DescriptionOutcome = table.Column<string>(nullable: true),
                    OutcomeType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutcomeItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutcomeItem_DeclarationList_DeclarationItemId",
                        column: x => x.DeclarationItemId,
                        principalTable: "DeclarationList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ValueListFinishedStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValueListFinishedStatus", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ValueListFinishedStatus",
                columns: new[] { "Id", "Text" },
                values: new object[] { 1, "Inget" });

            migrationBuilder.InsertData(
                table: "ValueListFinishedStatus",
                columns: new[] { "Id", "Text" },
                values: new object[] { 2, "Avvik" });

            migrationBuilder.InsertData(
                table: "ValueListFinishedStatus",
                columns: new[] { "Id", "Text" },
                values: new object[] { 3, "Merknad" });

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationTestItem_FinishedStatusId",
                table: "DeclarationTestItem",
                column: "FinishedStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeItem_DeclarationItemId",
                table: "OutcomeItem",
                column: "DeclarationItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationTestItem_ValueListFinishedStatus_FinishedStatusId",
                table: "DeclarationTestItem",
                column: "FinishedStatusId",
                principalTable: "ValueListFinishedStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationTestItem_ValueListFinishedStatus_FinishedStatusId",
                table: "DeclarationTestItem");

            migrationBuilder.DropTable(
                name: "OutcomeItem");

            migrationBuilder.DropTable(
                name: "ValueListFinishedStatus");

            migrationBuilder.DropIndex(
                name: "IX_DeclarationTestItem_FinishedStatusId",
                table: "DeclarationTestItem");

            migrationBuilder.DropColumn(
                name: "CaseNumber",
                table: "DeclarationTestItem");

            migrationBuilder.DropColumn(
                name: "FinishedStatusId",
                table: "DeclarationTestItem");
        }
    }
}
