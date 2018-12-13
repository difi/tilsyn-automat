using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "RequirementList");

            migrationBuilder.CreateTable(
                name: "RequirementLanguageList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RequirementItemId = table.Column<Guid>(nullable: false),
                    LanguageItemId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementLanguageList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequirementLanguageList_LanguageList_LanguageItemId",
                        column: x => x.LanguageItemId,
                        principalTable: "LanguageList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequirementLanguageList_RequirementList_RequirementItemId",
                        column: x => x.RequirementItemId,
                        principalTable: "RequirementList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RequirementLanguageList",
                columns: new[] { "Id", "Description", "LanguageItemId", "RequirementItemId" },
                values: new object[,]
                {
                    { new Guid("0290478b-5818-437b-9097-7fbeaf3433a2"), "Krav 3.1 Betjeningsområdet foran betalingsterminalen skal være minst 150 x 150 centimeter. Det skal ikke være hindringer i betjeningsområdet.", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), new Guid("875e76b5-c926-43a0-8738-c4f41c7a0b8b") },
                    { new Guid("b9247a56-97d9-4aeb-ad1d-224c1d410eaf"), "Krav 3.5 Dersom to eller flere automater står ved siden av hverandre, skal det være minst 150 centimeter fra midten av automaten til midten av neste automat.", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), new Guid("c65786bb-1b93-4153-b88c-935cc2a7ab60") },
                    { new Guid("5c873d77-9c1e-4c6f-82b6-83fdd77e892a"), "Krav 1.3 Skilt skal plasseres over betalingsterminalen.", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), new Guid("aebd662d-9dd5-4a27-88d5-19d6c5e12e5a") },
                    { new Guid("5ec84619-9cd3-4ee8-adad-9e55d04482d7"), "Krav 4.2: Høyden på betjeningskomponenter som skjerm og tastatur skal være mellom 75 centimeter og 130 centimeter over gulvet.", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), new Guid("e503322b-ed77-4b69-adc4-eca19b6eb97d") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequirementLanguageList_LanguageItemId",
                table: "RequirementLanguageList",
                column: "LanguageItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RequirementLanguageList_RequirementItemId",
                table: "RequirementLanguageList",
                column: "RequirementItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequirementLanguageList");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RequirementList",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "RequirementList",
                keyColumn: "Id",
                keyValue: new Guid("875e76b5-c926-43a0-8738-c4f41c7a0b8b"),
                column: "Description",
                value: "Krav 3.1 Betjeningsområdet foran betalingsterminalen skal være minst 150 x 150 centimeter. Det skal ikke være hindringer i betjeningsområdet.");

            migrationBuilder.UpdateData(
                table: "RequirementList",
                keyColumn: "Id",
                keyValue: new Guid("aebd662d-9dd5-4a27-88d5-19d6c5e12e5a"),
                column: "Description",
                value: "Krav 1.3 Skilt skal plasseres over betalingsterminalen.");

            migrationBuilder.UpdateData(
                table: "RequirementList",
                keyColumn: "Id",
                keyValue: new Guid("c65786bb-1b93-4153-b88c-935cc2a7ab60"),
                column: "Description",
                value: "Krav 3.5 Dersom to eller flere automater står ved siden av hverandre, skal det være minst 150 centimeter fra midten av automaten til midten av neste automat.");

            migrationBuilder.UpdateData(
                table: "RequirementList",
                keyColumn: "Id",
                keyValue: new Guid("e503322b-ed77-4b69-adc4-eca19b6eb97d"),
                column: "Description",
                value: "Krav 4.2: Høyden på betjeningskomponenter som skjerm og tastatur skal være mellom 75 centimeter og 130 centimeter over gulvet.");
        }
    }
}
