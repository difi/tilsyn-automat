using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HelpText",
                table: "RuleList");

            migrationBuilder.DropColumn(
                name: "Illustration",
                table: "RuleList");

            migrationBuilder.DropColumn(
                name: "ToolsNeed",
                table: "RuleList");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HelpText",
                table: "RuleList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Illustration",
                table: "RuleList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToolsNeed",
                table: "RuleList",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "RuleList",
                keyColumn: "Id",
                keyValue: new Guid("0d6c763e-e0f6-4049-adeb-ae9429262b57"),
                columns: new[] { "HelpText", "ToolsNeed" },
                values: new object[] { "", "Ingen" });

            migrationBuilder.UpdateData(
                table: "RuleList",
                keyColumn: "Id",
                keyValue: new Guid("5b3af04b-f6c6-4425-a22f-c2e7479839a5"),
                column: "ToolsNeed",
                value: "Ingen");

            migrationBuilder.UpdateData(
                table: "RuleList",
                keyColumn: "Id",
                keyValue: new Guid("832e0843-cab3-4dbc-9799-974e283fcc0b"),
                columns: new[] { "HelpText", "ToolsNeed" },
                values: new object[] { "Krav: Skilt skal plasseres over betalingsterminalen.<br /><br />Det skal være et skilt som er synlig på avstand utenfor kundens betjeningsområde. Formålet er at brukeren kan finne fram til betalingsterminalen.<br /><br />Skiltet skal være plassert over området der kunden skal betale varene sine. Det kan for eksempel være over kassen eller disken der betalingsterminalen er plassert.<br /><br />Eksempler på tekst på skilt er<br />- Kasse<br />- Betal her<br />- Kort og kontant<br />- Nummer på kasse<br />", "Ingen" });

            migrationBuilder.UpdateData(
                table: "RuleList",
                keyColumn: "Id",
                keyValue: new Guid("b64cac7e-6525-49e8-9112-0238e1588ed8"),
                columns: new[] { "HelpText", "ToolsNeed" },
                values: new object[] { "", "Ingen" });

            migrationBuilder.UpdateData(
                table: "RuleList",
                keyColumn: "Id",
                keyValue: new Guid("eb160c6c-3a9e-4dff-93df-577d9eab4e09"),
                columns: new[] { "HelpText", "ToolsNeed" },
                values: new object[] { "", "Ingen" });
        }
    }
}
