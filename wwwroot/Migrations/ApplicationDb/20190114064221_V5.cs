using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RequirementLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("0290478b-5818-437b-9097-7fbeaf3433a2"),
                column: "Description",
                value: "Krav 3.1 Betjeningsområdet foran betalingsterminalen skal være minst 150 x 150 centimeter. Betjeningsområdet skal være uten hindringer");

            migrationBuilder.UpdateData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("578dad2b-fa8c-4091-bcf3-336bf9fc5999"),
                column: "HelpText",
                value: "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/01.png' alt='Avstander i kundens betjeningsområde. Illustrasjon.' /><p>Beteningsområdet til kunden er plassen framføre betalingsterminalen, der kundane står når dei brukar betalingsterminalen for å betale varene sine, som vist i illustrasjonen over.</p><p>Du skal no måle opp beteningsområdet til kunden i form av eit kvadrat. Formålet med å måle opp området er at du skal få ei betre forståing av kva du skal sjekke i eigenkontrollen.</p><ul><li>Mål frå kassen/disken. Start på punktet midt framføre betalingsterminalen og mål 75 cm mot venstre</li><li>Mål frå kassen/disken. Start på punktet midt framføre betalingsterminalen og mål 75 cm mot høgre</li><li>Mål frå kassen/disken. Start på punktet midt framføre betalingsterminalen og mål 150 cm ut i lokalet</li></ul></div><div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/11.png' alt='Kundens betjeningsområde foran betalingsautomaten. Illustrasjon.' /><h3>Krav:</h3><p><p>Beteningsområdet til kunden framføre betalingsterminalen skal vere minst 150 x 150 centimeter. Beteningsområde skal vere utan hindringar.</p><h3>Formål:</h3><p>Formålet er at rullestolbrukarar kan kome fram til betalingsterminalen og snu rullestolen om det trengst. Hindringar gjer det vanskeleg for kunden å kome fram til og bruke betalingsterminalen. Ei hindring er for eksempel varehyller, stolpar, veggar, søppelbøtter, skilt eller benkar.</p><p>Dersom det er mogleg, skal du ta bort hindringar i beteningsområdet til kunden før du svarar på spørsmålet.</p></div>");

            migrationBuilder.UpdateData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("6ae15ad1-51c2-4d8f-817d-7acf925c5de9"),
                column: "HelpText",
                value: "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/01.png' alt='Avstander i kundens betjeningsområde. Illustrasjon.' /><p>Kundens betjeningsområde er plassen foran betalingsterminalen, der kundene står når de bruker betalingsterminalen for å betale varene sine, som vist i illustrasjonen over.</p><p>Du skal nå måle opp kundens betjeningsområde i form av et kvadrat. Hensikten med å måle opp området er at du skal få en bedre forståelse av hva du skal sjekke i egenkontrollen.</p><ul><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 75 cm mot venstre</li><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 75 cm mot høyre</li><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 150 cm ut i lokalet</li></ul></div><div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/11.png' alt='Kundens betjeningsområde foran betalingsautomaten. Illustrasjon.' /><h3>Krav:</h3><p>Kundens betjeningsområde foran betalingsterminalen skal være minst 150 x 150 centimeter. Betjeningsområdet skal være uten hindringer.</p><h3>Hensikt:</h3><p>Formålet er at rullestolbrukere kan komme frem til betalingsterminalen og snu rullestolen om det trengs. Hindringer gjør det vanskelig for kunden å komme frem til og bruke betalingsterminalen. En hindring er for eksempel varehyller, stolper, vegger, søppelbøtter, skilt eller benker.</p><p>Om det er mulig, skal du ta bort hindringer i kundens betjeningsområde før du svarer på spørsmålet.</p></div>");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RequirementLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("0290478b-5818-437b-9097-7fbeaf3433a2"),
                column: "Description",
                value: "Krav 3.1 Betjeningsområdet foran betalingsterminalen skal være minst 150 x 150 centimeter. Det skal ikke være hindringer i betjeningsområdet.");

            migrationBuilder.UpdateData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("578dad2b-fa8c-4091-bcf3-336bf9fc5999"),
                column: "HelpText",
                value: "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/01.png' alt='Avstander i kundens betjeningsområde. Illustrasjon.' /><p>Beteningsområdet til kunden er plassen framføre betalingsterminalen, der kundane står når dei brukar betalingsterminalen for å betale varene sine, som vist i illustrasjonen over.</p><p>Du skal no måle opp beteningsområdet til kunden i form av eit kvadrat. Formålet med å måle opp området er at du skal få ei betre forståing av kva du skal sjekke i eigenkontrollen.</p><ul><li>Mål frå kassen/disken. Start på punktet midt framføre betalingsterminalen og mål 75 cm mot venstre</li><li>Mål frå kassen/disken. Start på punktet midt framføre betalingsterminalen og mål 75 cm mot høgre</li><li>Mål frå kassen/disken. Start på punktet midt framføre betalingsterminalen og mål 150 cm ut i lokalet</li></ul></div><div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/11.png' alt='Kundens betjeningsområde foran betalingsautomaten. Illustrasjon.' /><h3>Krav:</h3><p><p>Beteningsområdet til kunden framføre betalingsterminalen skal vere minst 150 x 150 centimeter. Det skal vere utan hindringar.</p><h3>Formål:</h3><p>Formålet er at rullestolbrukarar kan kome fram til betalingsterminalen og snu rullestolen om det trengst. Hindringar gjer det vanskeleg for kunden å kome fram til og bruke betalingsterminalen. Ei hindring er for eksempel varehyller, stolpar, veggar, søppelbøtter, skilt eller benkar.</p><p>Dersom det er mogleg, skal du ta bort hindringar i beteningsområdet til kunden før du svarar på spørsmålet.</p></div>");

            migrationBuilder.UpdateData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("6ae15ad1-51c2-4d8f-817d-7acf925c5de9"),
                column: "HelpText",
                value: "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/01.png' alt='Avstander i kundens betjeningsområde. Illustrasjon.' /><p>Kundens betjeningsområde er plassen foran betalingsterminalen, der kundene står når de bruker betalingsterminalen for å betale varene sine, som vist i illustrasjonen over.</p><p>Du skal nå måle opp kundens betjeningsområde i form av et kvadrat. Hensikten med å måle opp området er at du skal få en bedre forståelse av hva du skal sjekke i egenkontrollen.</p><ul><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 75 cm mot venstre</li><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 75 cm mot høyre</li><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 150 cm ut i lokalet</li></ul></div><div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/11.png' alt='Kundens betjeningsområde foran betalingsautomaten. Illustrasjon.' /><h3>Krav:</h3><p>Kundens betjeningsområde foran betalingsterminalen skal være minst 150 x 150 centimeter. Det skal være uten hindringer.</p><h3>Hensikt:</h3><p>Formålet er at rullestolbrukere kan komme frem til betalingsterminalen og snu rullestolen om det trengs. Hindringer gjør det vanskelig for kunden å komme frem til og bruke betalingsterminalen. En hindring er for eksempel varehyller, stolper, vegger, søppelbøtter, skilt eller benker.</p><p>Om det er mulig, skal du ta bort hindringer i kundens betjeningsområde før du svarer på spørsmålet.</p></div>");
        }
    }
}
