using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RuleLanguageList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RuleItemId = table.Column<Guid>(nullable: false),
                    LanguageItemId = table.Column<Guid>(nullable: false),
                    HelpText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleLanguageList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RuleLanguageList_LanguageList_LanguageItemId",
                        column: x => x.LanguageItemId,
                        principalTable: "LanguageList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RuleLanguageList_RuleList_RuleItemId",
                        column: x => x.RuleItemId,
                        principalTable: "RuleList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RuleLanguageList",
                columns: new[] { "Id", "HelpText", "LanguageItemId", "RuleItemId" },
                values: new object[,]
                {
                    { new Guid("6ae15ad1-51c2-4d8f-817d-7acf925c5de9"), "", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), new Guid("eb160c6c-3a9e-4dff-93df-577d9eab4e09") },
                    { new Guid("804438bd-ac67-40ff-9168-6814ea843242"), "", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), new Guid("b64cac7e-6525-49e8-9112-0238e1588ed8") },
                    { new Guid("e369820b-ebcd-488e-9216-477d363f18ed"), "", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), new Guid("0d6c763e-e0f6-4049-adeb-ae9429262b57") },
                    { new Guid("55294d7b-6af0-4399-8a5c-776aa13e3a29"), "Krav: Skilt skal plasseres over betalingsterminalen.<br /><br />Det skal være et skilt som er synlig på avstand utenfor kundens betjeningsområde. Formålet er at brukeren kan finne fram til betalingsterminalen.<br /><br />Skiltet skal være plassert over området der kunden skal betale varene sine. Det kan for eksempel være over kassen eller disken der betalingsterminalen er plassert.<br /><br />Eksempler på tekst på skilt er<br />- Kasse<br />- Betal her<br />- Kort og kontant<br />- Nummer på kasse<br />", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), new Guid("832e0843-cab3-4dbc-9799-974e283fcc0b") },
                    { new Guid("d8c7e031-b2eb-4906-8c4d-c1d5f3266bbc"), "", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), new Guid("5b3af04b-f6c6-4425-a22f-c2e7479839a5") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RuleLanguageList_LanguageItemId",
                table: "RuleLanguageList",
                column: "LanguageItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleLanguageList_RuleItemId",
                table: "RuleLanguageList",
                column: "RuleItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RuleLanguageList");
        }
    }
}
