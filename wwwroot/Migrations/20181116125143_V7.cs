using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("c4870935-ee11-4557-a9c3-aca678c17565"),
                column: "Bool",
                value: false);

            migrationBuilder.UpdateData(
                table: "ChapterList",
                keyColumn: "Id",
                keyValue: new Guid("75468cd0-478b-45e9-8a8e-51b0e574fb3b"),
                column: "ChapterHeading",
                value: "Location signs and visual indications");

            migrationBuilder.InsertData(
                table: "ChapterList",
                columns: new[] { "Id", "ChapterHeading", "ChapterNumber", "RequirementsInSupervisor", "StandardItemId" },
                values: new object[,]
                {
                    { new Guid("731a0f5c-f586-471f-b32c-ceb8027f735a"), "User operating space", "15291:2006 D.6.2", "Krav 3.1 Betjeningsområdet foran betalingsterminalen skal være minst 150 x 150 centimeter. Betjeningsområdet skal være uten hindringer", new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2") },
                    { new Guid("b80b9b15-8f0e-4702-b7d9-95cafa68f9fb"), "Overhead obstructions", "15291:2006 D.5.5", "Krav 3.1 Betjeningsområdet foran betalingsterminalen skal være minst 150 x 150 centimeter. Betjeningsområdet skal være uten hindringer", new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2") },
                    { new Guid("5f5abe28-1a74-4242-acc8-4b881ee4973a"), "Access from user operating area", "15291:2006 D.6.6", "Krav 3.5 Dersom to eller flere automater står ved siden av hverandre, skal det være minst 150 centimeter fra midten av automaten til midten av neste automat.", new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2") }
                });

            migrationBuilder.InsertData(
                table: "RuleList",
                columns: new[] { "Id", "ChapterItemId", "HelpText", "Illustration", "Instruction", "Order", "RequirementItemId", "StandardItemId", "ToolsNeed" },
                values: new object[,]
                {
                    { new Guid("eb160c6c-3a9e-4dff-93df-577d9eab4e09"), new Guid("731a0f5c-f586-471f-b32c-ceb8027f735a"), "", null, "Finnes det hindringer i kundens betjeningsområde?", 4, new Guid("875e76b5-c926-43a0-8738-c4f41c7a0b8b"), new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2"), "Ingen" },
                    { new Guid("b64cac7e-6525-49e8-9112-0238e1588ed8"), new Guid("731a0f5c-f586-471f-b32c-ceb8027f735a"), "", null, "Beskriv hindringene i kundens betjeningsområde.", 5, new Guid("875e76b5-c926-43a0-8738-c4f41c7a0b8b"), new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2"), "Ingen" },
                    { new Guid("a1a1b0f2-441a-4726-ab6c-85e8d08ffed0"), new Guid("b80b9b15-8f0e-4702-b7d9-95cafa68f9fb"), "", null, "Henger det gjenstander over kundens betjeningsområde?", 6, new Guid("875e76b5-c926-43a0-8738-c4f41c7a0b8b"), new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2"), "Ingen" },
                    { new Guid("b504bde7-1394-4e5c-84d3-a3ac53fc7dd6"), new Guid("b80b9b15-8f0e-4702-b7d9-95cafa68f9fb"), "", null, "Hvor mange cm over gulvet henger den laveste gjenstanden i kundens betjeningsområde?", 7, new Guid("875e76b5-c926-43a0-8738-c4f41c7a0b8b"), new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2"), "Ingen" },
                    { new Guid("0d6c763e-e0f6-4049-adeb-ae9429262b57"), new Guid("5f5abe28-1a74-4242-acc8-4b881ee4973a"), "", null, "Står betalingsterminalen ved siden av en annen betalingsterminal, på rett linje?", 1, new Guid("c65786bb-1b93-4153-b88c-935cc2a7ab60"), new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2"), "Ingen" },
                    { new Guid("b9498453-f173-499a-b01d-91cb469cc5ec"), new Guid("5f5abe28-1a74-4242-acc8-4b881ee4973a"), "", null, "Hvor mange cm er det mellom betalingsterminalene?", 2, new Guid("c65786bb-1b93-4153-b88c-935cc2a7ab60"), new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2"), "Ingen" }
                });

            migrationBuilder.InsertData(
                table: "AnswerList",
                columns: new[] { "Id", "Bool", "MaxInt", "MinInt", "Order", "RuleItemId", "String", "TypeOfAnswerId" },
                values: new object[,]
                {
                    { new Guid("02d2db89-3717-48e1-883e-8e526bf6c727"), true, 0, 0, 1, new Guid("eb160c6c-3a9e-4dff-93df-577d9eab4e09"), null, 2 },
                    { new Guid("6912d4a0-b73b-4ecc-9fa8-49e1fd356635"), false, 0, 0, 2, new Guid("eb160c6c-3a9e-4dff-93df-577d9eab4e09"), null, 4 },
                    { new Guid("d7b40e3c-e7fa-44e5-b44f-750759c971cc"), false, 0, 0, 1, new Guid("b64cac7e-6525-49e8-9112-0238e1588ed8"), null, 1 },
                    { new Guid("a1964762-5c8f-40bb-a22d-c907149079d4"), true, 0, 0, 1, new Guid("a1a1b0f2-441a-4726-ab6c-85e8d08ffed0"), null, 2 },
                    { new Guid("8a12d92b-8a6a-44e7-9517-74331a4c2483"), false, 0, 0, 2, new Guid("a1a1b0f2-441a-4726-ab6c-85e8d08ffed0"), null, 4 },
                    { new Guid("bf459d05-702d-47d7-a5b7-19f8b3fb67c9"), false, 0, 0, 1, new Guid("b504bde7-1394-4e5c-84d3-a3ac53fc7dd6"), null, 3 },
                    { new Guid("202d20e0-61df-4a7c-8287-104e3b439f64"), true, 0, 0, 1, new Guid("0d6c763e-e0f6-4049-adeb-ae9429262b57"), null, 2 },
                    { new Guid("13d6d530-e533-4510-9a66-8b862899dbdf"), false, 0, 0, 2, new Guid("0d6c763e-e0f6-4049-adeb-ae9429262b57"), null, 4 },
                    { new Guid("89fd2205-1047-403d-a5bd-f70a1de2f247"), false, 0, 0, 1, new Guid("b9498453-f173-499a-b01d-91cb469cc5ec"), null, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("02d2db89-3717-48e1-883e-8e526bf6c727"));

            migrationBuilder.DeleteData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("13d6d530-e533-4510-9a66-8b862899dbdf"));

            migrationBuilder.DeleteData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("202d20e0-61df-4a7c-8287-104e3b439f64"));

            migrationBuilder.DeleteData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("6912d4a0-b73b-4ecc-9fa8-49e1fd356635"));

            migrationBuilder.DeleteData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("89fd2205-1047-403d-a5bd-f70a1de2f247"));

            migrationBuilder.DeleteData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("8a12d92b-8a6a-44e7-9517-74331a4c2483"));

            migrationBuilder.DeleteData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("a1964762-5c8f-40bb-a22d-c907149079d4"));

            migrationBuilder.DeleteData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("bf459d05-702d-47d7-a5b7-19f8b3fb67c9"));

            migrationBuilder.DeleteData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("d7b40e3c-e7fa-44e5-b44f-750759c971cc"));

            migrationBuilder.DeleteData(
                table: "RuleList",
                keyColumn: "Id",
                keyValue: new Guid("0d6c763e-e0f6-4049-adeb-ae9429262b57"));

            migrationBuilder.DeleteData(
                table: "RuleList",
                keyColumn: "Id",
                keyValue: new Guid("a1a1b0f2-441a-4726-ab6c-85e8d08ffed0"));

            migrationBuilder.DeleteData(
                table: "RuleList",
                keyColumn: "Id",
                keyValue: new Guid("b504bde7-1394-4e5c-84d3-a3ac53fc7dd6"));

            migrationBuilder.DeleteData(
                table: "RuleList",
                keyColumn: "Id",
                keyValue: new Guid("b64cac7e-6525-49e8-9112-0238e1588ed8"));

            migrationBuilder.DeleteData(
                table: "RuleList",
                keyColumn: "Id",
                keyValue: new Guid("b9498453-f173-499a-b01d-91cb469cc5ec"));

            migrationBuilder.DeleteData(
                table: "RuleList",
                keyColumn: "Id",
                keyValue: new Guid("eb160c6c-3a9e-4dff-93df-577d9eab4e09"));

            migrationBuilder.DeleteData(
                table: "ChapterList",
                keyColumn: "Id",
                keyValue: new Guid("5f5abe28-1a74-4242-acc8-4b881ee4973a"));

            migrationBuilder.DeleteData(
                table: "ChapterList",
                keyColumn: "Id",
                keyValue: new Guid("731a0f5c-f586-471f-b32c-ceb8027f735a"));

            migrationBuilder.DeleteData(
                table: "ChapterList",
                keyColumn: "Id",
                keyValue: new Guid("b80b9b15-8f0e-4702-b7d9-95cafa68f9fb"));

            migrationBuilder.UpdateData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("c4870935-ee11-4557-a9c3-aca678c17565"),
                column: "Bool",
                value: true);

            migrationBuilder.UpdateData(
                table: "ChapterList",
                keyColumn: "Id",
                keyValue: new Guid("75468cd0-478b-45e9-8a8e-51b0e574fb3b"),
                column: "ChapterHeading",
                value: "Location signs and visual indications ");
        }
    }
}
