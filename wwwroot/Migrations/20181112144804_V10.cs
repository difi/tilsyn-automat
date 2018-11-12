using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeItem_DeclarationTestItem_DeclarationTestItemId",
                table: "OutcomeItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeItem_RequirementItem_RequirementId",
                table: "OutcomeItem");

            migrationBuilder.DropForeignKey(
                name: "FK_RuleItem_RequirementItem_RequirementItemId",
                table: "RuleItem");

            migrationBuilder.DropIndex(
                name: "IX_OutcomeItem_DeclarationTestItemId",
                table: "OutcomeItem");

            migrationBuilder.DropIndex(
                name: "IX_OutcomeItem_RequirementId",
                table: "OutcomeItem");

            migrationBuilder.DropColumn(
                name: "DeclarationTestItemId",
                table: "OutcomeItem");

            migrationBuilder.DropColumn(
                name: "RequirementId",
                table: "OutcomeItem");

            migrationBuilder.RenameColumn(
                name: "RequirementItemId",
                table: "RuleItem",
                newName: "RequirementId");

            migrationBuilder.RenameIndex(
                name: "IX_RuleItem_RequirementItemId",
                table: "RuleItem",
                newName: "IX_RuleItem_RequirementId");

            migrationBuilder.AddColumn<Guid>(
                name: "OutcomeItemId",
                table: "RequirementItem",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "RequirementData",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RequirementId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequirementData_RequirementItem_RequirementId",
                        column: x => x.RequirementId,
                        principalTable: "RequirementItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VlTypeOfResult",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlTypeOfResult", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RuleData",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RuleId = table.Column<Guid>(nullable: true),
                    RequirementDataId = table.Column<Guid>(nullable: true),
                    Bool = table.Column<bool>(nullable: false),
                    String = table.Column<string>(nullable: true),
                    Int = table.Column<int>(nullable: false),
                    ImageId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RuleData_ImageList_ImageId",
                        column: x => x.ImageId,
                        principalTable: "ImageList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RuleData_RequirementData_RequirementDataId",
                        column: x => x.RequirementDataId,
                        principalTable: "RequirementData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RuleData_RuleItem_RuleId",
                        column: x => x.RuleId,
                        principalTable: "RuleItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OutcomeData",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RequirementDataId = table.Column<Guid>(nullable: false),
                    OutcomeItemId = table.Column<Guid>(nullable: false),
                    ResultId = table.Column<int>(nullable: true),
                    ResultText = table.Column<string>(nullable: true),
                    DeclarationTestItemId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutcomeData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutcomeData_DeclarationTestItem_DeclarationTestItemId",
                        column: x => x.DeclarationTestItemId,
                        principalTable: "DeclarationTestItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OutcomeData_OutcomeItem_OutcomeItemId",
                        column: x => x.OutcomeItemId,
                        principalTable: "OutcomeItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutcomeData_RequirementData_RequirementDataId",
                        column: x => x.RequirementDataId,
                        principalTable: "RequirementData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutcomeData_VlTypeOfResult_ResultId",
                        column: x => x.ResultId,
                        principalTable: "VlTypeOfResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "VlTypeOfAnswer",
                keyColumn: "Id",
                keyValue: 3,
                column: "Text",
                value: "int");

            migrationBuilder.UpdateData(
                table: "VlTypeOfAnswer",
                keyColumn: "Id",
                keyValue: 4,
                column: "Text",
                value: "image");

            migrationBuilder.InsertData(
                table: "VlTypeOfResult",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 1, "Samsvar" },
                    { 2, "Brudd" },
                    { 3, "Ikke-forekomst" },
                    { 4, "Ikke testbar" },
                    { 5, "Ikke testa" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequirementItem_OutcomeItemId",
                table: "RequirementItem",
                column: "OutcomeItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeData_DeclarationTestItemId",
                table: "OutcomeData",
                column: "DeclarationTestItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeData_OutcomeItemId",
                table: "OutcomeData",
                column: "OutcomeItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeData_RequirementDataId",
                table: "OutcomeData",
                column: "RequirementDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeData_ResultId",
                table: "OutcomeData",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_RequirementData_RequirementId",
                table: "RequirementData",
                column: "RequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleData_ImageId",
                table: "RuleData",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleData_RequirementDataId",
                table: "RuleData",
                column: "RequirementDataId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleData_RuleId",
                table: "RuleData",
                column: "RuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequirementItem_OutcomeItem_OutcomeItemId",
                table: "RequirementItem",
                column: "OutcomeItemId",
                principalTable: "OutcomeItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RuleItem_RequirementItem_RequirementId",
                table: "RuleItem",
                column: "RequirementId",
                principalTable: "RequirementItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequirementItem_OutcomeItem_OutcomeItemId",
                table: "RequirementItem");

            migrationBuilder.DropForeignKey(
                name: "FK_RuleItem_RequirementItem_RequirementId",
                table: "RuleItem");

            migrationBuilder.DropTable(
                name: "OutcomeData");

            migrationBuilder.DropTable(
                name: "RuleData");

            migrationBuilder.DropTable(
                name: "VlTypeOfResult");

            migrationBuilder.DropTable(
                name: "RequirementData");

            migrationBuilder.DropIndex(
                name: "IX_RequirementItem_OutcomeItemId",
                table: "RequirementItem");

            migrationBuilder.DropColumn(
                name: "OutcomeItemId",
                table: "RequirementItem");

            migrationBuilder.RenameColumn(
                name: "RequirementId",
                table: "RuleItem",
                newName: "RequirementItemId");

            migrationBuilder.RenameIndex(
                name: "IX_RuleItem_RequirementId",
                table: "RuleItem",
                newName: "IX_RuleItem_RequirementItemId");

            migrationBuilder.AddColumn<Guid>(
                name: "DeclarationTestItemId",
                table: "OutcomeItem",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RequirementId",
                table: "OutcomeItem",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "VlTypeOfAnswer",
                keyColumn: "Id",
                keyValue: 3,
                column: "Text",
                value: "image");

            migrationBuilder.UpdateData(
                table: "VlTypeOfAnswer",
                keyColumn: "Id",
                keyValue: 4,
                column: "Text",
                value: "int");

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeItem_DeclarationTestItemId",
                table: "OutcomeItem",
                column: "DeclarationTestItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeItem_RequirementId",
                table: "OutcomeItem",
                column: "RequirementId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeItem_DeclarationTestItem_DeclarationTestItemId",
                table: "OutcomeItem",
                column: "DeclarationTestItemId",
                principalTable: "DeclarationTestItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeItem_RequirementItem_RequirementId",
                table: "OutcomeItem",
                column: "RequirementId",
                principalTable: "RequirementItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RuleItem_RequirementItem_RequirementItemId",
                table: "RuleItem",
                column: "RequirementItemId",
                principalTable: "RequirementItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
