using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("55294d7b-6af0-4399-8a5c-776aa13e3a29"),
                column: "HelpText",
                value: "<img src='/images/illustrations/31.png' width='400' alt='Illustrasjon' /><h3>Krav:</h3><p>Skiltet skal plasseres over betalingsterminalen. Skiltet skal være synlig på avstand, utenfor kundens betjeningsområde.</p><h3>Hensikt: </h3><p>Formålet er at kunden lett skal finne fram til betalingsterminalen.<br />Skiltet skal være plassert over området der kunden skal betale varene sine. Det kan for eksempel være over kassen eller disken der betalingsterminalen står.<br />Eksempler på tekst på skilt er<br /><ul><li>Kasse</li><li>Betal her</li><li>Kort og kontanter</li><li>Nummer på kassen</li></ul></p>");

            migrationBuilder.UpdateData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("6ae15ad1-51c2-4d8f-817d-7acf925c5de9"),
                column: "HelpText",
                value: "<img src='/images/illustrations/11.png' width='400' alt='Illustrasjon' /><h3>Krav:</h3><p>Kundens betjeningsområde foran betalingsterminalen skal være minst 150 x 150 centimeter. Det skal være uten hindringer.</p><h3>Hensikt:</h3><p>Formålet er at rullestolbrukere kan komme frem til betalingsterminalen og snu rullestolen om det trengs. Hindringer gjør det vanskelig for kunden å komme frem til og bruke betalingsterminalen. En hindring er for eksempel varehyller, stolper, vegger, søppelbøtter, skilt eller benker.</p><p>Om der er mulig, skal du ta bort hindringer i kundens betjeningsområde før du svarer på spørsmålet.</p>");

            migrationBuilder.UpdateData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("804438bd-ac67-40ff-9168-6814ea843242"),
                column: "HelpText",
                value: "<img src='/images/illustrations/12.png' width='400' alt='Illustrasjon' /><h3>Krav:</h3><p>Det skal ikke henge gjenstander lavere enn 220 cm ned i kundens betjeningsområde.</p><h3>Hensikt:</h3><p>Hindringer kan også henge ned fra taket, som for eksempel skilt, plakater og lamper. Det gjør det vanskelig for høye kunder å komme frem til og bruke betalingsterminalen.</p>");

            migrationBuilder.UpdateData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("d8c7e031-b2eb-4906-8c4d-c1d5f3266bbc"),
                column: "HelpText",
                value: "<img src='/images/illustrations/41.png' width='400' alt='Illustrasjon' /><h3>Krav: </h3><p>Høyden på betjeningskomponenter som skjerm og tastatur skal være mellom 75 centimeter og 130 centimeter over gulvet.</p><h3>Hensikt:</h3><p>Formålet er at betalingsterminalen skal være enkel å nå og bruke, både for kunder som står og kunder som sitter, f.eks. rullestolbrukere.<br />Dersom du kan justere høyden på betalingsterminalen, skal du flytte den til mellom 75 og 130 cm over gulvet før du måler.<br />Utgangspunktet for målingen er midt på betalingsterminalen.</p>");

            migrationBuilder.UpdateData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("e369820b-ebcd-488e-9216-477d363f18ed"),
                column: "HelpText",
                value: "<img src='/images/illustrations/21.png' width='400' alt='Illustrasjon' /><h3>Krav: </h3><p>Dersom to eller flere betalingsterminaler står ved siden av hverandre på rett linje, skal det være minst 150 centimeter fra midten av betalingsterminalen til midten av neste betalingsterminal. NB Kravet gjelder ikke der betalingsterminalene står overfor hverandre.</p><h3>Hensikt: </h3><p>Formålet er at betalingsterminaler som står ved siden av hverandre, kan brukes samtidig, og at kundene som skal betale varene sine, kan komme seg bort uten å forstyrre hverandre.<br />Dersom det er flere betalingsterminaler som står ved siden av hverandre på rett linje, mål avstanden til den nærmeste.<br />Utgangspunktet for målingen er midt foran på betalingsterminalen.<br /></p>");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("55294d7b-6af0-4399-8a5c-776aa13e3a29"),
                column: "HelpText",
                value: "Krav: Skilt skal plasseres over betalingsterminalen.<br /><br />Det skal være et skilt som er synlig på avstand utenfor kundens betjeningsområde. Formålet er at brukeren kan finne fram til betalingsterminalen.<br /><br />Skiltet skal være plassert over området der kunden skal betale varene sine. Det kan for eksempel være over kassen eller disken der betalingsterminalen er plassert.<br /><br />Eksempler på tekst på skilt er<br />- Kasse<br />- Betal her<br />- Kort og kontant<br />- Nummer på kasse<br />");

            migrationBuilder.UpdateData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("6ae15ad1-51c2-4d8f-817d-7acf925c5de9"),
                column: "HelpText",
                value: "");

            migrationBuilder.UpdateData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("804438bd-ac67-40ff-9168-6814ea843242"),
                column: "HelpText",
                value: "");

            migrationBuilder.UpdateData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("d8c7e031-b2eb-4906-8c4d-c1d5f3266bbc"),
                column: "HelpText",
                value: "");

            migrationBuilder.UpdateData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("e369820b-ebcd-488e-9216-477d363f18ed"),
                column: "HelpText",
                value: "");
        }
    }
}
