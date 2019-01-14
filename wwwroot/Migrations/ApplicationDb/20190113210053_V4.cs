using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nb",
                table: "VlUserPrerequisiteList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nn",
                table: "VlUserPrerequisiteList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nb",
                table: "VlTypeOfTestList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nn",
                table: "VlTypeOfTestList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nb",
                table: "VlTypeOfSupplierAndVersionList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nn",
                table: "VlTypeOfSupplierAndVersionList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nb",
                table: "VlTypeOfStatus",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nn",
                table: "VlTypeOfStatus",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nb",
                table: "VlTypeOfResult",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nn",
                table: "VlTypeOfResult",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nb",
                table: "VlTypeOfMachineList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nn",
                table: "VlTypeOfMachineList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nb",
                table: "VlTypeOfAnswer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nn",
                table: "VlTypeOfAnswer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nb",
                table: "VlPurposeOfTest",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nn",
                table: "VlPurposeOfTest",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nb",
                table: "VlFinishedStatusList",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nn",
                table: "VlFinishedStatusList",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("6ae15ad1-51c2-4d8f-817d-7acf925c5de9"),
                column: "HelpText",
                value: "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/01.png' alt='Avstander i kundens betjeningsområde. Illustrasjon.' /><p>Kundens betjeningsområde er plassen foran betalingsterminalen, der kundene står når de bruker betalingsterminalen for å betale varene sine, som vist i illustrasjonen over.</p><p>Du skal nå måle opp kundens betjeningsområde i form av et kvadrat. Hensikten med å måle opp området er at du skal få en bedre forståelse av hva du skal sjekke i egenkontrollen.</p><ul><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 75 cm mot venstre</li><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 75 cm mot høyre</li><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 150 cm ut i lokalet</li></ul></div><div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/11.png' alt='Kundens betjeningsområde foran betalingsautomaten. Illustrasjon.' /><h3>Krav:</h3><p>Kundens betjeningsområde foran betalingsterminalen skal være minst 150 x 150 centimeter. Det skal være uten hindringer.</p><h3>Hensikt:</h3><p>Formålet er at rullestolbrukere kan komme frem til betalingsterminalen og snu rullestolen om det trengs. Hindringer gjør det vanskelig for kunden å komme frem til og bruke betalingsterminalen. En hindring er for eksempel varehyller, stolper, vegger, søppelbøtter, skilt eller benker.</p><p>Om det er mulig, skal du ta bort hindringer i kundens betjeningsområde før du svarer på spørsmålet.</p></div>");

            migrationBuilder.UpdateData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Nb", "Nn", "Text" },
                values: new object[] { "Velg betalingsterminal", "Vel betalingsterminal", null });

            migrationBuilder.UpdateData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "Nb", "Nn", "Text" },
                values: new object[] { "Vet ikke", "Veit ikkje", null });

            migrationBuilder.UpdateData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "Nb", "Nn", "Text" },
                values: new object[] { "Annet", "Anna", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nb",
                table: "VlUserPrerequisiteList");

            migrationBuilder.DropColumn(
                name: "Nn",
                table: "VlUserPrerequisiteList");

            migrationBuilder.DropColumn(
                name: "Nb",
                table: "VlTypeOfTestList");

            migrationBuilder.DropColumn(
                name: "Nn",
                table: "VlTypeOfTestList");

            migrationBuilder.DropColumn(
                name: "Nb",
                table: "VlTypeOfSupplierAndVersionList");

            migrationBuilder.DropColumn(
                name: "Nn",
                table: "VlTypeOfSupplierAndVersionList");

            migrationBuilder.DropColumn(
                name: "Nb",
                table: "VlTypeOfStatus");

            migrationBuilder.DropColumn(
                name: "Nn",
                table: "VlTypeOfStatus");

            migrationBuilder.DropColumn(
                name: "Nb",
                table: "VlTypeOfResult");

            migrationBuilder.DropColumn(
                name: "Nn",
                table: "VlTypeOfResult");

            migrationBuilder.DropColumn(
                name: "Nb",
                table: "VlTypeOfMachineList");

            migrationBuilder.DropColumn(
                name: "Nn",
                table: "VlTypeOfMachineList");

            migrationBuilder.DropColumn(
                name: "Nb",
                table: "VlTypeOfAnswer");

            migrationBuilder.DropColumn(
                name: "Nn",
                table: "VlTypeOfAnswer");

            migrationBuilder.DropColumn(
                name: "Nb",
                table: "VlPurposeOfTest");

            migrationBuilder.DropColumn(
                name: "Nn",
                table: "VlPurposeOfTest");

            migrationBuilder.DropColumn(
                name: "Nb",
                table: "VlFinishedStatusList");

            migrationBuilder.DropColumn(
                name: "Nn",
                table: "VlFinishedStatusList");

            migrationBuilder.UpdateData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("6ae15ad1-51c2-4d8f-817d-7acf925c5de9"),
                column: "HelpText",
                value: "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/01.png' alt='Avstander i kundens betjeningsområde. Illustrasjon.' /><p>Kundens betjeningsområde er plassen foran betalingsterminalen, der kundene står når de bruker betalingsterminalen for å betale varene sine, som vist i illustrasjonen over.</p><p>Du skal nå måle opp kundens betjeningsområde i form av et kvadrat. Hensikten med å måle opp området er at du skal få en bedre forståelse av hva du skal sjekke i egenkontrollen.</p><ul><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 75 cm mot venstre</li><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 75 cm mot høyre</li><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 150 cm ut i lokalet</li></ul></div><div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/11.png' alt='Kundens betjeningsområde foran betalingsautomaten. Illustrasjon.' /><h3>Krav:</h3><p>Kundens betjeningsområde foran betalingsterminalen skal være minst 150 x 150 centimeter. Det skal være uten hindringer.</p><h3>Hensikt:</h3><p>Formålet er at rullestolbrukere kan komme frem til betalingsterminalen og snu rullestolen om det trengs. Hindringer gjør det vanskelig for kunden å komme frem til og bruke betalingsterminalen. En hindring er for eksempel varehyller, stolper, vegger, søppelbøtter, skilt eller benker.</p><p>Om der er mulig, skal du ta bort hindringer i kundens betjeningsområde før du svarer på spørsmålet.</p></div>");

            migrationBuilder.UpdateData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 1,
                column: "Text",
                value: "Velg betalingsterminal");

            migrationBuilder.UpdateData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 100,
                column: "Text",
                value: "Vet ikke");

            migrationBuilder.UpdateData(
                table: "VlTypeOfSupplierAndVersionList",
                keyColumn: "Id",
                keyValue: 99999,
                column: "Text",
                value: "Annet");
        }
    }
}
