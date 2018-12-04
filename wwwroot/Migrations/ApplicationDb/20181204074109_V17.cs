using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoolFalseText",
                table: "AnswerList");

            migrationBuilder.DropColumn(
                name: "BoolTrueText",
                table: "AnswerList");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "AnswerList");

            migrationBuilder.CreateTable(
                name: "LanguageList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnswerItemLanguage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AnswerItemId = table.Column<Guid>(nullable: false),
                    LanguageItemId = table.Column<Guid>(nullable: false),
                    Question = table.Column<string>(nullable: true),
                    BoolTrueText = table.Column<string>(nullable: true),
                    BoolFalseText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerItemLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerItemLanguage_AnswerList_AnswerItemId",
                        column: x => x.AnswerItemId,
                        principalTable: "AnswerList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnswerItemLanguage_LanguageList_LanguageItemId",
                        column: x => x.LanguageItemId,
                        principalTable: "LanguageList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LanguageList",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "nb-NO" });

            migrationBuilder.InsertData(
                table: "LanguageList",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "nn-NO" });

            migrationBuilder.InsertData(
                table: "AnswerItemLanguage",
                columns: new[] { "Id", "AnswerItemId", "BoolFalseText", "BoolTrueText", "LanguageItemId", "Question" },
                values: new object[,]
                {
                    { new Guid("2583fbbf-12a3-475d-b610-41b5ad0327c1"), new Guid("02d2db89-3717-48e1-883e-8e526bf6c727"), "Nej", "Ja", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Finnes det hindringer i kundens betjeningsområde?" },
                    { new Guid("8da3f1e2-4ed3-4957-b94d-797ed932ec73"), new Guid("f98f67e5-cf6a-4afe-8998-3132640f9d70"), "Annat, ", "Mellom 75cm og 130cm over gulvet", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Hvor mange cm er det fra gulvet og opp til betalingsterminalen?" },
                    { new Guid("0ed22f35-94ec-46d1-9aad-615f91bbb1b0"), new Guid("f69c1e45-99d8-4293-a242-c5ed9e126e99"), "Nej", "Ja", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Er skiltet synlig på avstand utenfor kundens betjeningsområde?" },
                    { new Guid("14b18d90-1b1f-4628-b15e-edc9afe5a0a1"), new Guid("9a51cc68-857e-4822-ac81-0ec3ebe7bf43"), "Nej", "Ja", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Er skiltet plassert over området der kunden skal betale varene sine?" },
                    { new Guid("ec0e3dd2-bd43-4e44-a118-51b86b80d77f"), new Guid("c4870935-ee11-4557-a9c3-aca678c17565"), null, null, new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Ta bilde" },
                    { new Guid("463efa96-5c19-4945-8bac-100a2b4c6916"), new Guid("d8611e84-0f00-4d75-bcab-cbf127fb68b5"), "Nej", "Ja", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Finnes det et skilt som viser hvor kunden skal betale varene sine?" },
                    { new Guid("6e68729a-50e9-4844-a791-43e2eb21fad0"), new Guid("13d6d530-e533-4510-9a66-8b862899dbdf"), null, null, new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Ta bilde" },
                    { new Guid("cb3bfb9a-b373-4264-9add-3f4ec562c402"), new Guid("78b8d910-c0bb-4467-acbe-1320f51fe658"), null, null, new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Mål i cm" },
                    { new Guid("b760e91c-81f5-4de9-82c2-3747c23dbf9d"), new Guid("89fd2205-1047-403d-a5bd-f70a1de2f247"), "0-149 cm, ", "150 cm eller mer", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Hvor mange cm er det mellom betalingsterminalene?" },
                    { new Guid("7c632541-119a-4dd5-b501-e0ba7e2caff2"), new Guid("202d20e0-61df-4a7c-8287-104e3b439f64"), "Nej", "Ja", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Står betalingsterminalen ved siden av en annen betalingsterminal, på rett linje?" },
                    { new Guid("4b1e6cba-160c-4adb-a6cf-0736f1d585c2"), new Guid("5544b740-0b5f-400c-b7b2-7e6472d4160b"), null, null, new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Mål i cm" },
                    { new Guid("1670250d-7f81-4fd0-90a2-d9a8df97df8a"), new Guid("bf459d05-702d-47d7-a5b7-19f8b3fb67c9"), "0-219 cm, ", "220 cm eller mer", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Hvor mange cm over gulvet henger den laveste gjenstanden i kundens betjeningsområde?" },
                    { new Guid("3ec18f01-3e59-4cb1-b4b3-75e0af67ac2f"), new Guid("a1964762-5c8f-40bb-a22d-c907149079d4"), "Nej", "Ja", new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Henger det gjenstander over kundens betjeningsområde?" },
                    { new Guid("6c73f84c-a2d5-43ac-a5fe-793d0c5672cc"), new Guid("8a12d92b-8a6a-44e7-9517-74331a4c2483"), null, null, new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Ta bilde" },
                    { new Guid("6876174d-2e2c-484b-a9a7-14cb63359a30"), new Guid("02d2db89-3717-48e1-883e-8e526bf6c727"), null, null, new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Beskriv hindringene i kundens betjeningsområde." },
                    { new Guid("db55a19e-7f42-4176-921d-4a09698f727a"), new Guid("6912d4a0-b73b-4ecc-9fa8-49e1fd356635"), null, null, new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Ta bilde" },
                    { new Guid("f94c4896-806c-4ce1-b6a3-ebf090ee9789"), new Guid("9aea071e-7263-4b2e-8cd7-5193fbbe5b77"), null, null, new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Mål i cm" },
                    { new Guid("2e2e8b32-c7c4-4ffa-b6b7-275a82e5b6af"), new Guid("438787f3-b33b-489c-b5a8-2f046a634dea"), null, null, new Guid("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"), "Ta bilde" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerItemLanguage_AnswerItemId",
                table: "AnswerItemLanguage",
                column: "AnswerItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerItemLanguage_LanguageItemId",
                table: "AnswerItemLanguage",
                column: "LanguageItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerItemLanguage");

            migrationBuilder.DropTable(
                name: "LanguageList");

            migrationBuilder.AddColumn<string>(
                name: "BoolFalseText",
                table: "AnswerList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BoolTrueText",
                table: "AnswerList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "AnswerList",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("02d2db89-3717-48e1-883e-8e526bf6c727"),
                columns: new[] { "BoolFalseText", "BoolTrueText", "Question" },
                values: new object[] { "Nej", "Ja", "Finnes det hindringer i kundens betjeningsområde?" });

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("13d6d530-e533-4510-9a66-8b862899dbdf"),
                column: "Question",
                value: "Ta bilde");

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("202d20e0-61df-4a7c-8287-104e3b439f64"),
                columns: new[] { "BoolFalseText", "BoolTrueText", "Question" },
                values: new object[] { "Nej", "Ja", "Står betalingsterminalen ved siden av en annen betalingsterminal, på rett linje?" });

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("438787f3-b33b-489c-b5a8-2f046a634dea"),
                column: "Question",
                value: "Ta bilde");

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("5544b740-0b5f-400c-b7b2-7e6472d4160b"),
                column: "Question",
                value: "Mål i cm");

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("6912d4a0-b73b-4ecc-9fa8-49e1fd356635"),
                column: "Question",
                value: "Ta bilde");

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("78b8d910-c0bb-4467-acbe-1320f51fe658"),
                column: "Question",
                value: "Mål i cm");

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("89fd2205-1047-403d-a5bd-f70a1de2f247"),
                columns: new[] { "BoolFalseText", "BoolTrueText", "Question" },
                values: new object[] { "0-149 cm, ", "150 cm eller mer", "Hvor mange cm er det mellom betalingsterminalene?" });

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("8a12d92b-8a6a-44e7-9517-74331a4c2483"),
                column: "Question",
                value: "Ta bilde");

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("9a51cc68-857e-4822-ac81-0ec3ebe7bf43"),
                columns: new[] { "BoolFalseText", "BoolTrueText", "Question" },
                values: new object[] { "Nej", "Ja", "Er skiltet plassert over området der kunden skal betale varene sine?" });

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("9aea071e-7263-4b2e-8cd7-5193fbbe5b77"),
                column: "Question",
                value: "Mål i cm");

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("a1964762-5c8f-40bb-a22d-c907149079d4"),
                columns: new[] { "BoolFalseText", "BoolTrueText", "Question" },
                values: new object[] { "Nej", "Ja", "Henger det gjenstander over kundens betjeningsområde?" });

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("bf459d05-702d-47d7-a5b7-19f8b3fb67c9"),
                columns: new[] { "BoolFalseText", "BoolTrueText", "Question" },
                values: new object[] { "0-219 cm, ", "220 cm eller mer", "Hvor mange cm over gulvet henger den laveste gjenstanden i kundens betjeningsområde?" });

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("c4870935-ee11-4557-a9c3-aca678c17565"),
                column: "Question",
                value: "Ta bilde");

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("d7b40e3c-e7fa-44e5-b44f-750759c971cc"),
                column: "Question",
                value: "Beskriv hindringene i kundens betjeningsområde.");

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("d8611e84-0f00-4d75-bcab-cbf127fb68b5"),
                columns: new[] { "BoolFalseText", "BoolTrueText", "Question" },
                values: new object[] { "Nej", "Ja", "Finnes det et skilt som viser hvor kunden skal betale varene sine?" });

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("f69c1e45-99d8-4293-a242-c5ed9e126e99"),
                columns: new[] { "BoolFalseText", "BoolTrueText", "Question" },
                values: new object[] { "Nej", "Ja", "Er skiltet synlig på avstand utenfor kundens betjeningsområde?" });

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("f98f67e5-cf6a-4afe-8998-3132640f9d70"),
                columns: new[] { "BoolFalseText", "BoolTrueText", "Question" },
                values: new object[] { "Annat, ", "Mellom 75cm og 130cm over gulvet", "Hvor mange cm er det fra gulvet og opp til betalingsterminalen?" });
        }
    }
}
