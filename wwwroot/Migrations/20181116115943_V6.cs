using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MiniInt",
                table: "AnswerList",
                newName: "MinInt");

            migrationBuilder.InsertData(
                table: "ChapterList",
                columns: new[] { "Id", "ChapterHeading", "ChapterNumber", "RequirementsInSupervisor", "StandardItemId" },
                values: new object[] { new Guid("6c0f12f8-0a91-4849-b18f-2af735017fcd"), "Layout of operating features", "15291:2006 6.3.1", "Krav 4.2: Høyden på betjeningskomponenter som skjerm og tastatur skal være mellom 75 centimeter og 130 centimeter over gulvet. ", new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2") });

            migrationBuilder.UpdateData(
                table: "RuleList",
                keyColumn: "Id",
                keyValue: new Guid("4c4cd93b-ad4c-49b3-af05-f9e9fc7cb15a"),
                column: "RequirementItemId",
                value: new Guid("aebd662d-9dd5-4a27-88d5-19d6c5e12e5a"));

            migrationBuilder.UpdateData(
                table: "RuleList",
                keyColumn: "Id",
                keyValue: new Guid("5cec30b8-2c28-4f7e-b9d7-6655a745c2ef"),
                column: "RequirementItemId",
                value: new Guid("aebd662d-9dd5-4a27-88d5-19d6c5e12e5a"));

            migrationBuilder.UpdateData(
                table: "RuleList",
                keyColumn: "Id",
                keyValue: new Guid("832e0843-cab3-4dbc-9799-974e283fcc0b"),
                column: "RequirementItemId",
                value: new Guid("aebd662d-9dd5-4a27-88d5-19d6c5e12e5a"));

            migrationBuilder.InsertData(
                table: "RuleList",
                columns: new[] { "Id", "ChapterItemId", "HelpText", "Illustration", "Instruction", "Order", "RequirementItemId", "StandardItemId", "ToolsNeed" },
                values: new object[] { new Guid("5b3af04b-f6c6-4425-a22f-c2e7479839a5"), new Guid("6c0f12f8-0a91-4849-b18f-2af735017fcd"), null, null, "Hvor mange cm er det fra gulvet og opp til betalingsterminalen?", 1, new Guid("e503322b-ed77-4b69-adc4-eca19b6eb97d"), new Guid("7851b33f-4cec-405c-8533-53cf7a6832e2"), "Ingen" });

            migrationBuilder.InsertData(
                table: "AnswerList",
                columns: new[] { "Id", "Bool", "MaxInt", "MinInt", "Order", "RuleItemId", "String", "TypeOfAnswerId" },
                values: new object[] { new Guid("f98f67e5-cf6a-4afe-8998-3132640f9d70"), false, 130, 75, 1, new Guid("5b3af04b-f6c6-4425-a22f-c2e7479839a5"), null, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnswerList",
                keyColumn: "Id",
                keyValue: new Guid("f98f67e5-cf6a-4afe-8998-3132640f9d70"));

            migrationBuilder.DeleteData(
                table: "RuleList",
                keyColumn: "Id",
                keyValue: new Guid("5b3af04b-f6c6-4425-a22f-c2e7479839a5"));

            migrationBuilder.DeleteData(
                table: "ChapterList",
                keyColumn: "Id",
                keyValue: new Guid("6c0f12f8-0a91-4849-b18f-2af735017fcd"));

            migrationBuilder.RenameColumn(
                name: "MinInt",
                table: "AnswerList",
                newName: "MiniInt");

            migrationBuilder.UpdateData(
                table: "RuleList",
                keyColumn: "Id",
                keyValue: new Guid("4c4cd93b-ad4c-49b3-af05-f9e9fc7cb15a"),
                column: "RequirementItemId",
                value: new Guid("e503322b-ed77-4b69-adc4-eca19b6eb97d"));

            migrationBuilder.UpdateData(
                table: "RuleList",
                keyColumn: "Id",
                keyValue: new Guid("5cec30b8-2c28-4f7e-b9d7-6655a745c2ef"),
                column: "RequirementItemId",
                value: new Guid("e503322b-ed77-4b69-adc4-eca19b6eb97d"));

            migrationBuilder.UpdateData(
                table: "RuleList",
                keyColumn: "Id",
                keyValue: new Guid("832e0843-cab3-4dbc-9799-974e283fcc0b"),
                column: "RequirementItemId",
                value: new Guid("e503322b-ed77-4b69-adc4-eca19b6eb97d"));
        }
    }
}
