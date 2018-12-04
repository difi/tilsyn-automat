using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "TestGroupList");

            migrationBuilder.CreateTable(
                name: "TestGroupLanguageList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TestGroupItemId = table.Column<Guid>(nullable: false),
                    LanguageItemId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestGroupLanguageList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestGroupLanguageList_LanguageList_LanguageItemId",
                        column: x => x.LanguageItemId,
                        principalTable: "LanguageList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestGroupLanguageList_TestGroupList_TestGroupItemId",
                        column: x => x.TestGroupItemId,
                        principalTable: "TestGroupList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TestGroupLanguageList",
                columns: new[] { "Id", "LanguageItemId", "Name", "TestGroupItemId" },
                values: new object[] { new Guid("d7f6c8de-9435-4c39-bd19-9642eca25e65"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Betjeningsområde", new Guid("aec1869a-30f8-403c-b909-df115173f009") });

            migrationBuilder.InsertData(
                table: "TestGroupLanguageList",
                columns: new[] { "Id", "LanguageItemId", "Name", "TestGroupItemId" },
                values: new object[] { new Guid("2b1d1f9a-1c00-43f5-b8f1-f598d146bc77"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Skilt", new Guid("b6c22ac9-d775-4dfd-ac8e-b4ca565ea3fb") });

            migrationBuilder.InsertData(
                table: "TestGroupLanguageList",
                columns: new[] { "Id", "LanguageItemId", "Name", "TestGroupItemId" },
                values: new object[] { new Guid("3b00207c-83a8-49a8-a65e-503b63cc73b1"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Betjeningshøyde", new Guid("9aae6bc9-4b60-405c-81a7-ec142d8c1ca6") });

            migrationBuilder.CreateIndex(
                name: "IX_TestGroupLanguageList_LanguageItemId",
                table: "TestGroupLanguageList",
                column: "LanguageItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TestGroupLanguageList_TestGroupItemId",
                table: "TestGroupLanguageList",
                column: "TestGroupItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestGroupLanguageList");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TestGroupList",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TestGroupList",
                keyColumn: "Id",
                keyValue: new Guid("9aae6bc9-4b60-405c-81a7-ec142d8c1ca6"),
                column: "Name",
                value: "Betjeningshøyde");

            migrationBuilder.UpdateData(
                table: "TestGroupList",
                keyColumn: "Id",
                keyValue: new Guid("aec1869a-30f8-403c-b909-df115173f009"),
                column: "Name",
                value: "Betjeningsområde");

            migrationBuilder.UpdateData(
                table: "TestGroupList",
                keyColumn: "Id",
                keyValue: new Guid("b6c22ac9-d775-4dfd-ac8e-b4ca565ea3fb"),
                column: "Name",
                value: "Skilt");
        }
    }
}
