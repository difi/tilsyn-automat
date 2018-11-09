using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationTestItem_FinishedStatusList_FinishedStatusId",
                table: "DeclarationTestItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationTestItem_TypeOfSupplierAndVersionList_SupplierAndVersionId",
                table: "DeclarationTestItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationTestItem_TypeOfMachineList_TypeOfMachineId",
                table: "DeclarationTestItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationTestItem_TypeOfTestList_TypeOfTestId",
                table: "DeclarationTestItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeOfTestList",
                table: "TypeOfTestList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeOfSupplierAndVersionList",
                table: "TypeOfSupplierAndVersionList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeOfMachineList",
                table: "TypeOfMachineList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinishedStatusList",
                table: "FinishedStatusList");

            migrationBuilder.RenameTable(
                name: "TypeOfTestList",
                newName: "VlTypeOfTestList");

            migrationBuilder.RenameTable(
                name: "TypeOfSupplierAndVersionList",
                newName: "VlTypeOfSupplierAndVersionList");

            migrationBuilder.RenameTable(
                name: "TypeOfMachineList",
                newName: "VlTypeOfMachineList");

            migrationBuilder.RenameTable(
                name: "FinishedStatusList",
                newName: "VlFinishedStatusList");

            migrationBuilder.RenameColumn(
                name: "OutcomeType",
                table: "OutcomeItem",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "DescriptionOutcome",
                table: "OutcomeItem",
                newName: "Description");

            migrationBuilder.AddColumn<Guid>(
                name: "RequirementId",
                table: "OutcomeItem",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VlTypeOfTestList",
                table: "VlTypeOfTestList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VlTypeOfSupplierAndVersionList",
                table: "VlTypeOfSupplierAndVersionList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VlTypeOfMachineList",
                table: "VlTypeOfMachineList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VlFinishedStatusList",
                table: "VlFinishedStatusList",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RequirementItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    ChapterNumber = table.Column<string>(nullable: true),
                    ChapterHeading = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VlUserPrerequisiteList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlUserPrerequisiteList", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "VlUserPrerequisiteList",
                columns: new[] { "Id", "Text" },
                values: new object[,]
                {
                    { 1, "Blinde" },
                    { 2, "Svaksynte" },
                    { 3, "Fargeblinde" },
                    { 4, "Døvblinde" },
                    { 5, "Døve" },
                    { 6, "Nedsett høyrsel/tunghøyrde" },
                    { 7, "Nedsett kognisjon" },
                    { 8, "Nedsett motorikk" },
                    { 9, "Fotosensitivitet/anfall" },
                    { 10, "Fysisk størrelse" },
                    { 11, "Redusert taktil sensibilitet" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OutcomeItem_RequirementId",
                table: "OutcomeItem",
                column: "RequirementId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationTestItem_VlFinishedStatusList_FinishedStatusId",
                table: "DeclarationTestItem",
                column: "FinishedStatusId",
                principalTable: "VlFinishedStatusList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationTestItem_VlTypeOfSupplierAndVersionList_SupplierAndVersionId",
                table: "DeclarationTestItem",
                column: "SupplierAndVersionId",
                principalTable: "VlTypeOfSupplierAndVersionList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationTestItem_VlTypeOfMachineList_TypeOfMachineId",
                table: "DeclarationTestItem",
                column: "TypeOfMachineId",
                principalTable: "VlTypeOfMachineList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationTestItem_VlTypeOfTestList_TypeOfTestId",
                table: "DeclarationTestItem",
                column: "TypeOfTestId",
                principalTable: "VlTypeOfTestList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OutcomeItem_RequirementItem_RequirementId",
                table: "OutcomeItem",
                column: "RequirementId",
                principalTable: "RequirementItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationTestItem_VlFinishedStatusList_FinishedStatusId",
                table: "DeclarationTestItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationTestItem_VlTypeOfSupplierAndVersionList_SupplierAndVersionId",
                table: "DeclarationTestItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationTestItem_VlTypeOfMachineList_TypeOfMachineId",
                table: "DeclarationTestItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationTestItem_VlTypeOfTestList_TypeOfTestId",
                table: "DeclarationTestItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OutcomeItem_RequirementItem_RequirementId",
                table: "OutcomeItem");

            migrationBuilder.DropTable(
                name: "RequirementItem");

            migrationBuilder.DropTable(
                name: "VlUserPrerequisiteList");

            migrationBuilder.DropIndex(
                name: "IX_OutcomeItem_RequirementId",
                table: "OutcomeItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VlTypeOfTestList",
                table: "VlTypeOfTestList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VlTypeOfSupplierAndVersionList",
                table: "VlTypeOfSupplierAndVersionList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VlTypeOfMachineList",
                table: "VlTypeOfMachineList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VlFinishedStatusList",
                table: "VlFinishedStatusList");

            migrationBuilder.DropColumn(
                name: "RequirementId",
                table: "OutcomeItem");

            migrationBuilder.RenameTable(
                name: "VlTypeOfTestList",
                newName: "TypeOfTestList");

            migrationBuilder.RenameTable(
                name: "VlTypeOfSupplierAndVersionList",
                newName: "TypeOfSupplierAndVersionList");

            migrationBuilder.RenameTable(
                name: "VlTypeOfMachineList",
                newName: "TypeOfMachineList");

            migrationBuilder.RenameTable(
                name: "VlFinishedStatusList",
                newName: "FinishedStatusList");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "OutcomeItem",
                newName: "OutcomeType");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "OutcomeItem",
                newName: "DescriptionOutcome");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeOfTestList",
                table: "TypeOfTestList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeOfSupplierAndVersionList",
                table: "TypeOfSupplierAndVersionList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeOfMachineList",
                table: "TypeOfMachineList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinishedStatusList",
                table: "FinishedStatusList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationTestItem_FinishedStatusList_FinishedStatusId",
                table: "DeclarationTestItem",
                column: "FinishedStatusId",
                principalTable: "FinishedStatusList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationTestItem_TypeOfSupplierAndVersionList_SupplierAndVersionId",
                table: "DeclarationTestItem",
                column: "SupplierAndVersionId",
                principalTable: "TypeOfSupplierAndVersionList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationTestItem_TypeOfMachineList_TypeOfMachineId",
                table: "DeclarationTestItem",
                column: "TypeOfMachineId",
                principalTable: "TypeOfMachineList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationTestItem_TypeOfTestList_TypeOfTestId",
                table: "DeclarationTestItem",
                column: "TypeOfTestId",
                principalTable: "TypeOfTestList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
