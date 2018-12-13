using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndicatorOutcomeList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    IndicatorItemId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicatorOutcomeList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicatorOutcomeList_IndicatorList_IndicatorItemId",
                        column: x => x.IndicatorItemId,
                        principalTable: "IndicatorList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndicatorOutcomeAnswerList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IndicatorOutcomeItemId = table.Column<Guid>(nullable: false),
                    AnswerItemId = table.Column<Guid>(nullable: false),
                    ResultId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicatorOutcomeAnswerList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicatorOutcomeAnswerList_AnswerList_AnswerItemId",
                        column: x => x.AnswerItemId,
                        principalTable: "AnswerList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicatorOutcomeAnswerList_IndicatorOutcomeList_IndicatorOutcomeItemId",
                        column: x => x.IndicatorOutcomeItemId,
                        principalTable: "IndicatorOutcomeList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndicatorOutcomeAnswerList_VlTypeOfResult_ResultId",
                        column: x => x.ResultId,
                        principalTable: "VlTypeOfResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IndicatorOutcomeLanguageList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IndicatorOutcomeItemId = table.Column<Guid>(nullable: false),
                    LanguageItemId = table.Column<Guid>(nullable: false),
                    OutcomeText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicatorOutcomeLanguageList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndicatorOutcomeLanguageList_IndicatorOutcomeList_IndicatorOutcomeItemId",
                        column: x => x.IndicatorOutcomeItemId,
                        principalTable: "IndicatorOutcomeList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndicatorOutcomeLanguageList_LanguageList_LanguageItemId",
                        column: x => x.LanguageItemId,
                        principalTable: "LanguageList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IndicatorOutcomeList",
                columns: new[] { "Id", "IndicatorItemId", "Order" },
                values: new object[,]
                {
                    { new Guid("0025bb09-6dfe-4069-ae6b-27cb28ba8300"), new Guid("692627b2-53bc-43f2-900d-44a40a21e7e9"), 1 },
                    { new Guid("d438e931-f57c-4a5c-bb5c-3e3a66824827"), new Guid("692627b2-53bc-43f2-900d-44a40a21e7e9"), 2 },
                    { new Guid("d18a7bce-556c-45cc-87d7-c765261166d5"), new Guid("692627b2-53bc-43f2-900d-44a40a21e7e9"), 3 },
                    { new Guid("a9b2bb20-7240-4a93-ba1a-ae270e8679f1"), new Guid("692627b2-53bc-43f2-900d-44a40a21e7e9"), 4 },
                    { new Guid("4edceffe-eb77-4ca0-a498-24be5372d333"), new Guid("692627b2-53bc-43f2-900d-44a40a21e7e9"), 5 },
                    { new Guid("6cd1b621-12e6-4a03-bd6e-a7c8b39de251"), new Guid("692627b2-53bc-43f2-900d-44a40a21e7e9"), 6 }
                });

            migrationBuilder.InsertData(
                table: "IndicatorOutcomeAnswerList",
                columns: new[] { "Id", "AnswerItemId", "IndicatorOutcomeItemId", "ResultId" },
                values: new object[,]
                {
                    { new Guid("d48f8630-230a-4285-8b78-6bb9049054b1"), new Guid("02d2db89-3717-48e1-883e-8e526bf6c727"), new Guid("0025bb09-6dfe-4069-ae6b-27cb28ba8300"), 1 },
                    { new Guid("708cc5c8-d433-4bf4-b179-8d8c81b6bd6e"), new Guid("a1964762-5c8f-40bb-a22d-c907149079d4"), new Guid("0025bb09-6dfe-4069-ae6b-27cb28ba8300"), 1 }
                });

            migrationBuilder.InsertData(
                table: "IndicatorOutcomeLanguageList",
                columns: new[] { "Id", "IndicatorOutcomeItemId", "LanguageItemId", "OutcomeText" },
                values: new object[,]
                {
                    { new Guid("2e230687-302b-4da7-ae95-00d615f1fc2a"), new Guid("0025bb09-6dfe-4069-ae6b-27cb28ba8300"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Kundens betjeningsområde foran betalingsterminalen er uten hindringer. Det henger ikke gjenstander over kundens betjeningsområde." },
                    { new Guid("cf2e7b7c-7fdd-45d1-8140-f6c299805358"), new Guid("d438e931-f57c-4a5c-bb5c-3e3a66824827"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Kundens betjeningsområde foran betalingsterminalen er uten hindringer. Gjenstander som henger over kundens betjeningsområde, er minst 220 cm over gulvet." },
                    { new Guid("20dc4731-c388-40f9-8c6a-45b92591f003"), new Guid("d18a7bce-556c-45cc-87d7-c765261166d5"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Kundens betjeningsområde foran betalingsterminalen er uten hindringer. Gjenstander som henger over kundens betjeningsområde, er lavere enn 220 cm over gulvet." },
                    { new Guid("5631c088-146b-4df6-98a6-7a7f4e8d6331"), new Guid("a9b2bb20-7240-4a93-ba1a-ae270e8679f1"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Det finnes hindringer i kundens betjeningsområde foran betalingsterminalen. Det henger ikke gjenstander over kundens betjeningsområde." },
                    { new Guid("bace523f-8d4c-4c2f-80e7-b87e2a4fb330"), new Guid("4edceffe-eb77-4ca0-a498-24be5372d333"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Det finnes hindringer i kundens betjeningsområde foran betalingsterminalen. Gjenstander som henger over kundens betjeningsområde, er minst 220 cm over gulvet." },
                    { new Guid("174f9a3a-a5b9-4e00-8fcb-f3d9b8fd215e"), new Guid("6cd1b621-12e6-4a03-bd6e-a7c8b39de251"), new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Det finnes hindringer i kundens betjeningsområde foran betalingsterminalen og gjenstander som henger over kundens betjeningsområde, er lavere enn 220 cm over gulvet." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorOutcomeAnswerList_AnswerItemId",
                table: "IndicatorOutcomeAnswerList",
                column: "AnswerItemId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorOutcomeAnswerList_IndicatorOutcomeItemId",
                table: "IndicatorOutcomeAnswerList",
                column: "IndicatorOutcomeItemId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorOutcomeAnswerList_ResultId",
                table: "IndicatorOutcomeAnswerList",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorOutcomeLanguageList_IndicatorOutcomeItemId",
                table: "IndicatorOutcomeLanguageList",
                column: "IndicatorOutcomeItemId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorOutcomeLanguageList_LanguageItemId",
                table: "IndicatorOutcomeLanguageList",
                column: "LanguageItemId");

            migrationBuilder.CreateIndex(
                name: "IX_IndicatorOutcomeList_IndicatorItemId",
                table: "IndicatorOutcomeList",
                column: "IndicatorItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndicatorOutcomeAnswerList");

            migrationBuilder.DropTable(
                name: "IndicatorOutcomeLanguageList");

            migrationBuilder.DropTable(
                name: "IndicatorOutcomeList");
        }
    }
}
