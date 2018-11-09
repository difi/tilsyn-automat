using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ValueListTypeOfTest",
                table: "ValueListTypeOfTest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ValueListTypeOfSupplierAndVersion",
                table: "ValueListTypeOfSupplierAndVersion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ValueListTypeOfMachine",
                table: "ValueListTypeOfMachine");

            migrationBuilder.DropColumn(
                name: "SupplierAndVersion",
                table: "DeclarationTestItem");

            migrationBuilder.DropColumn(
                name: "TypeOfMachine",
                table: "DeclarationTestItem");

            migrationBuilder.DropColumn(
                name: "TypeOfTest",
                table: "DeclarationTestItem");

            migrationBuilder.RenameTable(
                name: "ValueListTypeOfTest",
                newName: "TypeOfTestList");

            migrationBuilder.RenameTable(
                name: "ValueListTypeOfSupplierAndVersion",
                newName: "TypeOfSupplierAndVersionList");

            migrationBuilder.RenameTable(
                name: "ValueListTypeOfMachine",
                newName: "TypeOfMachineList");

            migrationBuilder.AddColumn<int>(
                name: "SupplierAndVersionId",
                table: "DeclarationTestItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfMachineId",
                table: "DeclarationTestItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfTestId",
                table: "DeclarationTestItem",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationTestItem_SupplierAndVersionId",
                table: "DeclarationTestItem",
                column: "SupplierAndVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationTestItem_TypeOfMachineId",
                table: "DeclarationTestItem",
                column: "TypeOfMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationTestItem_TypeOfTestId",
                table: "DeclarationTestItem",
                column: "TypeOfTestId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationTestItem_TypeOfSupplierAndVersionList_SupplierAndVersionId",
                table: "DeclarationTestItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationTestItem_TypeOfMachineList_TypeOfMachineId",
                table: "DeclarationTestItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationTestItem_TypeOfTestList_TypeOfTestId",
                table: "DeclarationTestItem");

            migrationBuilder.DropIndex(
                name: "IX_DeclarationTestItem_SupplierAndVersionId",
                table: "DeclarationTestItem");

            migrationBuilder.DropIndex(
                name: "IX_DeclarationTestItem_TypeOfMachineId",
                table: "DeclarationTestItem");

            migrationBuilder.DropIndex(
                name: "IX_DeclarationTestItem_TypeOfTestId",
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

            migrationBuilder.DropColumn(
                name: "SupplierAndVersionId",
                table: "DeclarationTestItem");

            migrationBuilder.DropColumn(
                name: "TypeOfMachineId",
                table: "DeclarationTestItem");

            migrationBuilder.DropColumn(
                name: "TypeOfTestId",
                table: "DeclarationTestItem");

            migrationBuilder.RenameTable(
                name: "TypeOfTestList",
                newName: "ValueListTypeOfTest");

            migrationBuilder.RenameTable(
                name: "TypeOfSupplierAndVersionList",
                newName: "ValueListTypeOfSupplierAndVersion");

            migrationBuilder.RenameTable(
                name: "TypeOfMachineList",
                newName: "ValueListTypeOfMachine");

            migrationBuilder.AddColumn<int>(
                name: "SupplierAndVersion",
                table: "DeclarationTestItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfMachine",
                table: "DeclarationTestItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeOfTest",
                table: "DeclarationTestItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ValueListTypeOfTest",
                table: "ValueListTypeOfTest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ValueListTypeOfSupplierAndVersion",
                table: "ValueListTypeOfSupplierAndVersion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ValueListTypeOfMachine",
                table: "ValueListTypeOfMachine",
                column: "Id");
        }
    }
}
