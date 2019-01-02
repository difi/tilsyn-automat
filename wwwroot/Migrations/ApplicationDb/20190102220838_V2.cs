using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations.ApplicationDb
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AnswerLanguageList",
                columns: new[] { "Id", "AnswerItemId", "BoolFalseText", "BoolTrueText", "LanguageItemId", "Question" },
                values: new object[,]
                {
                    { new Guid("b552415f-6d7a-4900-b177-2628b234cce2"), new Guid("02d2db89-3717-48e1-883e-8e526bf6c727"), "Nei", "Ja", new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Finst det hindringar i beteningsområdet til kunden?" },
                    { new Guid("dbf5bc8b-de37-4c68-8219-f2785d832eb3"), new Guid("438787f3-b33b-489c-b5a8-2f046a634dea"), null, null, new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Bekreft med bilde" },
                    { new Guid("e08eadf6-9f65-4af4-a202-12e24eba3a13"), new Guid("9aea071e-7263-4b2e-8cd7-5193fbbe5b77"), null, null, new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Mål i cm" },
                    { new Guid("fd3d3290-b415-495d-8c38-bf6c6fb2a679"), new Guid("f98f67e5-cf6a-4afe-8998-3132640f9d70"), "Annet, ", "Mellom 75cm og 130cm over gulvet", new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Kor mange cm er det frå golvet og opp til betalingsterminalen?" },
                    { new Guid("9241ebd9-5d9d-4646-9531-f52e047ef3f1"), new Guid("f69c1e45-99d8-4293-a242-c5ed9e126e99"), "Nei", "Ja", new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Er skiltet synleg på avstand utanfor beteningsområdet til kunden?" },
                    { new Guid("5bf1b010-1ad3-4b16-899d-d71463e5b3b7"), new Guid("9a51cc68-857e-4822-ac81-0ec3ebe7bf43"), "Nei", "Ja", new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Er skiltet plassert over området der kunden skal betale varene sine?" },
                    { new Guid("ed52107e-359a-4c71-b44e-1ea9a0052917"), new Guid("d8611e84-0f00-4d75-bcab-cbf127fb68b5"), "Nei", "Ja", new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Finst det eit skilt som viser kvar kunden skal betale varene sine?" },
                    { new Guid("dde428e6-e13b-4140-860b-b185661d8dc6"), new Guid("13d6d530-e533-4510-9a66-8b862899dbdf"), null, null, new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Bekreft med bilde" },
                    { new Guid("21aebbf3-e13d-4fff-a2e2-23e2ac613c29"), new Guid("78b8d910-c0bb-4467-acbe-1320f51fe658"), null, null, new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Mål i cm" },
                    { new Guid("8db67b5c-e3b1-4053-a66a-3499c54a545d"), new Guid("c4870935-ee11-4557-a9c3-aca678c17565"), null, null, new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Bekreft med bilde" },
                    { new Guid("d28ac0ea-244d-478a-9ba2-efb51deb9b90"), new Guid("202d20e0-61df-4a7c-8287-104e3b439f64"), "Nei", "Ja", new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Står betalingsterminalen ved sidan av ein annan betalingsterminal, på rett linje?" },
                    { new Guid("2a0296f1-7ed5-4e38-97b4-defba4439b69"), new Guid("5544b740-0b5f-400c-b7b2-7e6472d4160b"), null, null, new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Mål i cm" },
                    { new Guid("d7d086fb-99a8-42b6-8200-338a85d886a1"), new Guid("bf459d05-702d-47d7-a5b7-19f8b3fb67c9"), "0-219 cm, ", "220 cm eller mer", new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Kor mange cm over golvet heng den lågaste gjenstanden i beteningsområdet til kunden?" },
                    { new Guid("28550bd9-fcba-4a39-be91-d2a6331a26e9"), new Guid("a1964762-5c8f-40bb-a22d-c907149079d4"), "Nei", "Ja", new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Heng det gjenstandar over beteningsområdet til kunden?" },
                    { new Guid("93a705e1-5c90-4a6f-a03d-c2e3c449e4a6"), new Guid("8a12d92b-8a6a-44e7-9517-74331a4c2483"), null, null, new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Bekreft med bilde" },
                    { new Guid("eef618a0-e5bf-483a-8c10-fac1c04aa6be"), new Guid("d7b40e3c-e7fa-44e5-b44f-750759c971cc"), null, null, new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Beskriv hindringane i beteningsområdet til kunden." },
                    { new Guid("d61c82e8-a3a1-444f-bb63-ef34ba4b720e"), new Guid("6912d4a0-b73b-4ecc-9fa8-49e1fd356635"), null, null, new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Bekreft med bilde" },
                    { new Guid("844733d7-44b6-4813-b8a6-8ed36012e1a4"), new Guid("89fd2205-1047-403d-a5bd-f70a1de2f247"), "0-149 cm, ", "150 cm eller mer", new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Kor mange cm er det mellom betalingsterminalane?" }
                });

            migrationBuilder.InsertData(
                table: "IndicatorOutcomeLanguageList",
                columns: new[] { "Id", "IndicatorOutcomeItemId", "LanguageItemId", "OutcomeText" },
                values: new object[,]
                {
                    { new Guid("8361fd23-d73a-489a-89b7-212d87377b5a"), new Guid("e5a123b7-f2d4-4d25-b6d7-544c3b7c63b8"), new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Det finst eit skilt som viser kvar kunden skal betale varene sine. Skiltet er synleg på avstand utanfor beteningsområde til kunden og plassert over området der kunden skal betale varene sine." },
                    { new Guid("5d415407-52e3-410b-8b88-aa999dae169c"), new Guid("8d69236d-8940-417e-aab6-d41d74539ef2"), new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Betalingsterminalen er ikkje mellom 75 og 130 cm over golvet." },
                    { new Guid("a9665f46-40d8-42b9-b2cf-317e929a9122"), new Guid("043ccfc1-ff23-43f3-a130-3d399638f24f"), new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Betalingsterminalen er mellom 75 og 130 cm over golvet." },
                    { new Guid("77a7707b-293d-41b9-b657-886acfe53275"), new Guid("54d4cb13-a006-4a8b-9fdb-89a01a9b9040"), new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Det finst ikkje eit skilt som viser kvar kunden skal betale." },
                    { new Guid("53328236-d9ed-4194-9520-9278dafe0f01"), new Guid("402f1644-36d0-4ad5-853b-aee2f4bfbf75"), new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Skilt til området der kunden skal betale varene sine, er ikkje synleg på avstand utanfor beteningsområde til kunden." },
                    { new Guid("4c1c8046-ad7e-4c0d-920f-a3d52e8fedb6"), new Guid("d0ab6b63-c6c9-4a4f-81b0-5be0a4497278"), new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Skilt er ikkje plassert over området der kunden skal betale varene sine." },
                    { new Guid("6859b4be-dd97-4c59-8c69-618fd03fd528"), new Guid("85d5b052-1f22-449d-b0a3-2883593ace54"), new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Skilt til området der kunden skal betale varene sine, er ikkje synleg på avstand utanfor beteningsområde til kunden." },
                    { new Guid("dd35032d-653e-4117-8146-3e19a478f573"), new Guid("c11dcd56-0aaa-4253-8565-34132b640f15"), new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Betalingsterminalen står ikkje på rett linje ved sida av ein annan betalingsterminal." },
                    { new Guid("e365b040-2025-4ca0-a91b-957857b00717"), new Guid("30f07a36-ff0b-4692-b7bf-0f2d8dee923a"), new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Det er minst 150 cm mellom betalingsterminalane." },
                    { new Guid("cf89bc22-6e6d-4877-b82b-2c77eedc02ca"), new Guid("6cd1b621-12e6-4a03-bd6e-a7c8b39de251"), new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Det finst hindringar i beteningsområde til kunden framføre betalingsterminalen og gjenstandar som heng over beteningsområde til kunden, er lågare enn 220 cm over golvet." },
                    { new Guid("7d583641-4a2d-465c-ac49-98f67198be7f"), new Guid("4edceffe-eb77-4ca0-a498-24be5372d333"), new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Det finst hindringar i beteningsområde til kunden framføre betalingsterminalen. Gjenstandar som heng over beteningsområde til kunden, er minst 220 cm over golvet." },
                    { new Guid("db731f0f-830c-48d9-ae42-2583d3c1583e"), new Guid("a9b2bb20-7240-4a93-ba1a-ae270e8679f1"), new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Det finst hindringar i beteningsområde til kunden framføre betalingsterminalen. Det heng ikkje gjenstandar over beteningsområde til kunden." },
                    { new Guid("1d35bc8d-0e41-4532-83ec-c0e7f66406f8"), new Guid("d18a7bce-556c-45cc-87d7-c765261166d5"), new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Beteningsområde til kunden framføre betalingsterminalen er utan hindringar. Gjenstandar som heng over beteningsområde til kunden, er lågare enn 220 cm over golvet." },
                    { new Guid("6a198dba-d09e-43b3-bd79-8b1733b93912"), new Guid("d438e931-f57c-4a5c-bb5c-3e3a66824827"), new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Beteningsområde til kunden framføre betalingsterminalen er utan hindringar. Gjenstandar som heng over beteningsområde til kunden, er minst 220 cm over golvet." },
                    { new Guid("880a21aa-fb0f-41e6-b627-f40db33a4b71"), new Guid("0025bb09-6dfe-4069-ae6b-27cb28ba8300"), new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Beteningsområde til kunden framføre betalingsterminalen er utan hindringar. Det heng ikkje gjenstandar over beteningsområde til kunden." },
                    { new Guid("f98ea509-68e5-4a18-92c0-ce0b3ce58073"), new Guid("ae869b09-090d-459b-827c-4d61a1578478"), new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Betalingsterminalane står for tett." }
                });

            migrationBuilder.InsertData(
                table: "RequirementLanguageList",
                columns: new[] { "Id", "Description", "LanguageItemId", "RequirementItemId" },
                values: new object[,]
                {
                    { new Guid("6ac22f59-843c-4b3b-a1c6-aa4bd95bc779"), "Krav 1.3 Skilt skal plasserast over betalingsterminalen.", new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), new Guid("aebd662d-9dd5-4a27-88d5-19d6c5e12e5a") },
                    { new Guid("49cd54b9-d1d5-4f06-9186-20e3de25a7af"), "Krav 3.1 Beteningsområde framføre betalingsterminalen skal vere minst 150 x 150 centimeter. Beteningsområde skal vere utan hindringar.", new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), new Guid("875e76b5-c926-43a0-8738-c4f41c7a0b8b") },
                    { new Guid("d283278d-a276-4001-99fd-faab0a7dbb5d"), "Krav 3.5 Dersom to eller fleire automatar står ved sida av kvarandre, skal det vere minst 150 centimeter frå midten av automaten til midten av neste automat.", new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), new Guid("c65786bb-1b93-4153-b88c-935cc2a7ab60") },
                    { new Guid("74555409-91a1-4b81-97ec-76e005909a5e"), "Krav 4.2: Høgda på beteningskomponentar som skjerm og tastatur skal vere mellom 75 centimeter og 130 centimeter over golvet. ", new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), new Guid("e503322b-ed77-4b69-adc4-eca19b6eb97d") }
                });

            migrationBuilder.UpdateData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("55294d7b-6af0-4399-8a5c-776aa13e3a29"),
                column: "HelpText",
                value: "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/31.png' alt='Skilt over betalingsområdet. Illustrasjon' /><h3>Krav:</h3><p>Skiltet skal plasseres over betalingsterminalen. Skiltet skal være synlig på avstand, utenfor kundens betjeningsområde.</p><h3>Hensikt: </h3><p>Formålet er at kunden lett skal finne fram til betalingsterminalen.<br />Skiltet skal være plassert over området der kunden skal betale varene sine. Det kan for eksempel være over kassen eller disken der betalingsterminalen står.<br />Eksempler på tekst på skilt er</p><ul><li>Kasse</li><li>Betal her</li><li>Kort og kontanter</li><li>Nummer på kassen</li></ul></div>");

            migrationBuilder.UpdateData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("6ae15ad1-51c2-4d8f-817d-7acf925c5de9"),
                column: "HelpText",
                value: "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/01.png' alt='Avstander i kundens betjeningsområde. Illustrasjon.' /><p>Kundens betjeningsområde er plassen foran betalingsterminalen, der kundene står når de bruker betalingsterminalen for å betale varene sine, som vist i illustrasjonen over.</p><p>Du skal nå måle opp kundens betjeningsområde i form av et kvadrat. Hensikten med å måle opp området er at du skal få en bedre forståelse av hva du skal sjekke i egenkontrollen.</p><ul><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 75 cm mot venstre</li><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 75 cm mot høyre</li><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 150 cm ut i lokalet</li></ul></div><div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/11.png' alt='Kundens betjeningsområde foran betalingsautomaten. Illustrasjon.' /><h3>Krav:</h3><p>Kundens betjeningsområde foran betalingsterminalen skal være minst 150 x 150 centimeter. Det skal være uten hindringer.</p><h3>Hensikt:</h3><p>Formålet er at rullestolbrukere kan komme frem til betalingsterminalen og snu rullestolen om det trengs. Hindringer gjør det vanskelig for kunden å komme frem til og bruke betalingsterminalen. En hindring er for eksempel varehyller, stolper, vegger, søppelbøtter, skilt eller benker.</p><p>Om der er mulig, skal du ta bort hindringer i kundens betjeningsområde før du svarer på spørsmålet.</p></div>");

            migrationBuilder.UpdateData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("804438bd-ac67-40ff-9168-6814ea843242"),
                column: "HelpText",
                value: "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/12.png' alt='Gjenstander over betjeningsområdet. Illustrasjon.' /><h3>Krav:</h3><p>Det skal ikke henge gjenstander lavere enn 220 cm ned i kundens betjeningsområde.</p><h3>Hensikt:</h3><p>Formålet er at høye kunder lett skal komme frem til og bruke betalingsterminalen. En hindring er for eksempel l skilt, plakater og lamper som henger ned fra taket.</p></div>");

            migrationBuilder.UpdateData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("e369820b-ebcd-488e-9216-477d363f18ed"),
                column: "HelpText",
                value: "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/21.png' alt='Krav på avstand mellom betalingsautomater. Illustrasjon' /><h3>Krav: </h3><p>Dersom to eller flere betalingsterminaler står ved siden av hverandre på rett linje, skal det være minst 150 centimeter fra midten av betalingsterminalen til midten av neste betalingsterminal. NB Kravet gjelder ikke der betalingsterminalene står overfor hverandre.</p><h3>Hensikt: </h3><p>Formålet er at betalingsterminaler som står ved siden av hverandre, kan brukes samtidig, og at kundene som skal betale varene sine, kan komme seg bort uten å forstyrre hverandre.<br />Dersom det er flere betalingsterminaler som står ved siden av hverandre på rett linje, skal du måle avstanden til den nærmeste.<br />Utgangspunktet for målingen er midt foran på betalingsterminalen.</p></div>");

            migrationBuilder.InsertData(
                table: "RuleLanguageList",
                columns: new[] { "Id", "HelpText", "LanguageItemId", "RuleItemId" },
                values: new object[,]
                {
                    { new Guid("3217ae5f-047d-44c9-8615-be563b296639"), "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/31.png' alt='Skilt over betalingsområdet. Illustrasjon' /><h3>Krav:</h3><p>Skiltet skal plasserast over betalingsterminalen. Skiltet skal vere synleg på avstand, utanfor beteningsområdet til kunden.</p><h3>Formål:</h3><p>Formålet er at kunden lett skal finne fram til betalingsterminalen.<br />Skiltet skal vere plassert over området der kunden skal betale varene sine. Det kan for eksempel vere over kassa eller disken der betalingsterminalen står.<br />Eksempel på tekst på skilt er</p><ul><li>Kasse</li><li>Betal her</li><li>Kort og kontantar</li><li>Nummer på kassa</li></ul></div>", new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), new Guid("832e0843-cab3-4dbc-9799-974e283fcc0b") },
                    { new Guid("578dad2b-fa8c-4091-bcf3-336bf9fc5999"), "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/01.png' alt='Avstander i kundens betjeningsområde. Illustrasjon.' /><p>Beteningsområdet til kunden er plassen framføre betalingsterminalen, der kundane står når dei brukar betalingsterminalen for å betale varene sine, som vist i illustrasjonen over.</p><p>Du skal no måle opp beteningsområdet til kunden i form av eit kvadrat. Formålet med å måle opp området er at du skal få ei betre forståing av kva du skal sjekke i eigenkontrollen.</p><ul><li>Mål frå kassen/disken. Start på punktet midt framføre betalingsterminalen og mål 75 cm mot venstre</li><li>Mål frå kassen/disken. Start på punktet midt framføre betalingsterminalen og mål 75 cm mot høgre</li><li>Mål frå kassen/disken. Start på punktet midt framføre betalingsterminalen og mål 150 cm ut i lokalet</li></ul></div><div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/11.png' alt='Kundens betjeningsområde foran betalingsautomaten. Illustrasjon.' /><h3>Krav:</h3><p><p>Beteningsområdet til kunden framføre betalingsterminalen skal vere minst 150 x 150 centimeter. Det skal vere utan hindringar.</p><h3>Formål:</h3><p>Formålet er at rullestolbrukarar kan kome fram til betalingsterminalen og snu rullestolen om det trengst. Hindringar gjer det vanskeleg for kunden å kome fram til og bruke betalingsterminalen. Ei hindring er for eksempel varehyller, stolpar, veggar, søppelbøtter, skilt eller benkar.</p><p>Dersom det er mogleg, skal du ta bort hindringar i beteningsområdet til kunden før du svarar på spørsmålet.</p></div>", new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), new Guid("eb160c6c-3a9e-4dff-93df-577d9eab4e09") },
                    { new Guid("74eb4727-2bd8-4031-aa84-6d2f31411ea7"), "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/12.png' alt='Gjenstander over betjeningsområdet. Illustrasjon.' /><h3>Krav:</h3><p>Det skal ikkje henge gjenstandar lågare enn 220 cm ned i beteningsområdet til kunden.</p><h3>Formål:</h3><p>Formålet er at høge kundar lett skal kome fram til og bruke betalingsterminalen. Ei hindring er for eksempel skilt, plakatar og lamper som heng ned frå taket.</p></div>", new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), new Guid("b64cac7e-6525-49e8-9112-0238e1588ed8") },
                    { new Guid("63b58e58-cf92-4f17-b5e4-99a799d5d979"), "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/21.png' alt='Krav på avstand mellom betalingsautomater. Illustrasjon' /><h3>Krav: </h3><p>Dersom to eller fleire betalingsterminalar står ved sidan av kvarandre på rett linje, skal det vere minst 150 centimeter frå midten av betalingsterminalen til midten av neste betalingsterminal. NB: Kravet gjeld ikkje der betalingsterminalane står overfor kvarandre.</p><h3>Formål:</h3><p>Formålet er at betalingsterminalar som står ved sida av kvarandre, kan brukast samtidig, og at kundane som skal betale varene sine, kan kome seg bort utan å forstyrre kvarandre.<br />Dersom det er fleire betalingsterminalar som står ved sidan av kvarandre på rett linje, skal du måle avstanden til den nærmaste.<br />Utgangspunktet for målinga er midt framme på betalingsterminalen.</p></div>", new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), new Guid("0d6c763e-e0f6-4049-adeb-ae9429262b57") },
                    { new Guid("9f7dff24-12db-40b9-9803-9f9af82058d1"), "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/41.png' alt='Høyden på betjeningskomponenter. Illustrasjon' /><h3>Krav: </h3><p>Høgda på beteningskomponentar som skjerm og tastatur skal vere mellom 75 centimeter og 130 centimeter over golvet.</p><h3>Formål:</h3><p>Formålet er at betalingsterminalen skal vere enkel å nå og bruke, både for kundar som står og kundar som sit, f.eks. rullestolbrukarar.<br />Dersom du kan justere høgda på betalingsterminalen, skal du flytte han til mellom 75 og 130 cm over golvet før du måler.<br />Utgangspunktet for målinga er midt på betalingsterminalen.</p></div>", new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), new Guid("5b3af04b-f6c6-4425-a22f-c2e7479839a5") }
                });

            migrationBuilder.InsertData(
                table: "TestGroupLanguageList",
                columns: new[] { "Id", "LanguageItemId", "Name", "TestGroupItemId" },
                values: new object[,]
                {
                    { new Guid("98fff1d6-1b62-4de8-9b0c-7c107bd04dfb"), new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Skilt", new Guid("b6c22ac9-d775-4dfd-ac8e-b4ca565ea3fb") },
                    { new Guid("a6287d57-476c-4676-9d93-435a4e2f4195"), new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Beteningsområde", new Guid("aec1869a-30f8-403c-b909-df115173f009") },
                    { new Guid("18b44c34-20b1-4999-8170-8814493f8fc0"), new Guid("96d43981-d564-48e0-b416-975fe2b46dbe"), "Beteningshøgde", new Guid("9aae6bc9-4b60-405c-81a7-ec142d8c1ca6") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("21aebbf3-e13d-4fff-a2e2-23e2ac613c29"));

            migrationBuilder.DeleteData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("28550bd9-fcba-4a39-be91-d2a6331a26e9"));

            migrationBuilder.DeleteData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("2a0296f1-7ed5-4e38-97b4-defba4439b69"));

            migrationBuilder.DeleteData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("5bf1b010-1ad3-4b16-899d-d71463e5b3b7"));

            migrationBuilder.DeleteData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("844733d7-44b6-4813-b8a6-8ed36012e1a4"));

            migrationBuilder.DeleteData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("8db67b5c-e3b1-4053-a66a-3499c54a545d"));

            migrationBuilder.DeleteData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("9241ebd9-5d9d-4646-9531-f52e047ef3f1"));

            migrationBuilder.DeleteData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("93a705e1-5c90-4a6f-a03d-c2e3c449e4a6"));

            migrationBuilder.DeleteData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("b552415f-6d7a-4900-b177-2628b234cce2"));

            migrationBuilder.DeleteData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("d28ac0ea-244d-478a-9ba2-efb51deb9b90"));

            migrationBuilder.DeleteData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("d61c82e8-a3a1-444f-bb63-ef34ba4b720e"));

            migrationBuilder.DeleteData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("d7d086fb-99a8-42b6-8200-338a85d886a1"));

            migrationBuilder.DeleteData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("dbf5bc8b-de37-4c68-8219-f2785d832eb3"));

            migrationBuilder.DeleteData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("dde428e6-e13b-4140-860b-b185661d8dc6"));

            migrationBuilder.DeleteData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("e08eadf6-9f65-4af4-a202-12e24eba3a13"));

            migrationBuilder.DeleteData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("ed52107e-359a-4c71-b44e-1ea9a0052917"));

            migrationBuilder.DeleteData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("eef618a0-e5bf-483a-8c10-fac1c04aa6be"));

            migrationBuilder.DeleteData(
                table: "AnswerLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("fd3d3290-b415-495d-8c38-bf6c6fb2a679"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("1d35bc8d-0e41-4532-83ec-c0e7f66406f8"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("4c1c8046-ad7e-4c0d-920f-a3d52e8fedb6"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("53328236-d9ed-4194-9520-9278dafe0f01"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("5d415407-52e3-410b-8b88-aa999dae169c"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("6859b4be-dd97-4c59-8c69-618fd03fd528"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("6a198dba-d09e-43b3-bd79-8b1733b93912"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("77a7707b-293d-41b9-b657-886acfe53275"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("7d583641-4a2d-465c-ac49-98f67198be7f"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("8361fd23-d73a-489a-89b7-212d87377b5a"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("880a21aa-fb0f-41e6-b627-f40db33a4b71"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("a9665f46-40d8-42b9-b2cf-317e929a9122"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("cf89bc22-6e6d-4877-b82b-2c77eedc02ca"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("db731f0f-830c-48d9-ae42-2583d3c1583e"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("dd35032d-653e-4117-8146-3e19a478f573"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("e365b040-2025-4ca0-a91b-957857b00717"));

            migrationBuilder.DeleteData(
                table: "IndicatorOutcomeLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("f98ea509-68e5-4a18-92c0-ce0b3ce58073"));

            migrationBuilder.DeleteData(
                table: "RequirementLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("49cd54b9-d1d5-4f06-9186-20e3de25a7af"));

            migrationBuilder.DeleteData(
                table: "RequirementLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("6ac22f59-843c-4b3b-a1c6-aa4bd95bc779"));

            migrationBuilder.DeleteData(
                table: "RequirementLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("74555409-91a1-4b81-97ec-76e005909a5e"));

            migrationBuilder.DeleteData(
                table: "RequirementLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("d283278d-a276-4001-99fd-faab0a7dbb5d"));

            migrationBuilder.DeleteData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("3217ae5f-047d-44c9-8615-be563b296639"));

            migrationBuilder.DeleteData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("578dad2b-fa8c-4091-bcf3-336bf9fc5999"));

            migrationBuilder.DeleteData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("63b58e58-cf92-4f17-b5e4-99a799d5d979"));

            migrationBuilder.DeleteData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("74eb4727-2bd8-4031-aa84-6d2f31411ea7"));

            migrationBuilder.DeleteData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("9f7dff24-12db-40b9-9803-9f9af82058d1"));

            migrationBuilder.DeleteData(
                table: "TestGroupLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("18b44c34-20b1-4999-8170-8814493f8fc0"));

            migrationBuilder.DeleteData(
                table: "TestGroupLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("98fff1d6-1b62-4de8-9b0c-7c107bd04dfb"));

            migrationBuilder.DeleteData(
                table: "TestGroupLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("a6287d57-476c-4676-9d93-435a4e2f4195"));

            migrationBuilder.UpdateData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("55294d7b-6af0-4399-8a5c-776aa13e3a29"),
                column: "HelpText",
                value: "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/31.png' alt='Skilt over betalingsområdet. Illustrasjon' /><h3>Krav:</h3><p>Skiltet skal plasseres over betalingsterminalen. Skiltet skal være synlig på avstand, utenfor kundens betjeningsområde.</p><h3>Hensikt: </h3><p>Formålet er at kunden lett skal finne fram til betalingsterminalen.<br />Skiltet skal være plassert over området der kunden skal betale varene sine. Det kan for eksempel være over kassen eller disken der betalingsterminalen står.<br />Eksempler på tekst på skilt er<br /></p><ul><li>Kasse</li><li>Betal her</li><li>Kort og kontanter</li><li>Nummer på kassen</li></ul></div>");

            migrationBuilder.UpdateData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("6ae15ad1-51c2-4d8f-817d-7acf925c5de9"),
                column: "HelpText",
                value: "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/01.png' alt='Avstander i kundens betjeningsområde. Illustrasjon.' /><p>Kundens betjeningsområde er plassen foran betalingsterminalen, der kundene står når de bruker betalingsterminalen for å betale varene sine.<br />Illustrasjonen viser kundens betjeningsområde for betalingsterminalen. Det er et krav at dette området skal være minst 150 x 150 cm og uten hindringer.<br />Du skal nå måle opp kundens betjeningsområde i form av et kvadrat. Hensikten med å måle opp området er at du skal få en bedre forståelse av hva du skal sjekke i egenkontrollen.<br /></p><ul><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 75 cm mot venstre</li><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 75 cm mot høyre</li><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 150 cm ut i lokalet</li></ul></div><div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/11.png' alt='Kundens betjeningsområde foran betalingsautomaten. Illustrasjon.' /><h3>Krav:</h3><p>Kundens betjeningsområde foran betalingsterminalen skal være minst 150 x 150 centimeter. Det skal være uten hindringer.</p><h3>Hensikt:</h3><p>Formålet er at rullestolbrukere kan komme frem til betalingsterminalen og snu rullestolen om det trengs. Hindringer gjør det vanskelig for kunden å komme frem til og bruke betalingsterminalen. En hindring er for eksempel varehyller, stolper, vegger, søppelbøtter, skilt eller benker.</p><p>Om der er mulig, skal du ta bort hindringer i kundens betjeningsområde før du svarer på spørsmålet.</p></div>");

            migrationBuilder.UpdateData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("804438bd-ac67-40ff-9168-6814ea843242"),
                column: "HelpText",
                value: "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/12.png' alt='Gjenstander over betjeningsområdet. Illustrasjon.' /><h3>Krav:</h3><p>Det skal ikke henge gjenstander lavere enn 220 cm ned i kundens betjeningsområde.</p><h3>Hensikt:</h3><p>Hindringer kan også henge ned fra taket, som for eksempel skilt, plakater og lamper. Det gjør det vanskelig for høye kunder å komme frem til og bruke betalingsterminalen.</p></div>");

            migrationBuilder.UpdateData(
                table: "RuleLanguageList",
                keyColumn: "Id",
                keyValue: new Guid("e369820b-ebcd-488e-9216-477d363f18ed"),
                column: "HelpText",
                value: "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/21.png' alt='Krav på avstand mellom betalingsautomater. Illustrasjon' /><h3>Krav: </h3><p>Dersom to eller flere betalingsterminaler står ved siden av hverandre på rett linje, skal det være minst 150 centimeter fra midten av betalingsterminalen til midten av neste betalingsterminal. NB Kravet gjelder ikke der betalingsterminalene står overfor hverandre.</p><h3>Hensikt: </h3><p>Formålet er at betalingsterminaler som står ved siden av hverandre, kan brukes samtidig, og at kundene som skal betale varene sine, kan komme seg bort uten å forstyrre hverandre.<br />Dersom det er flere betalingsterminaler som står ved siden av hverandre på rett linje, mål avstanden til den nærmeste.<br />Utgangspunktet for målingen er midt foran på betalingsterminalen.<br /></p></div>");
        }
    }
}
