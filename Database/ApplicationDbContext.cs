using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.Standard;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using Microsoft.EntityFrameworkCore;

namespace Difi.Sjalvdeklaration.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserRole> UserRoleList { get; set; }

        public DbSet<UserCompany> UserCompanyList { get; set; }

        public DbSet<RoleItem> RoleList { get; set; }

        public DbSet<UserItem> UserList { get; set; }

        public DbSet<CompanyItem> CompanyList { get; set; }

        public DbSet<ContactPersonItem> ContactPersonList { get; set; }

        public DbSet<DeclarationItem> DeclarationList { get; set; }

        public DbSet<ImageItem> ImageList { get; set; }

        public DbSet<ValueListTypeOfMachine> VlTypeOfMachineList { get; set; }

        public DbSet<ValueListTypeOfTest> VlTypeOfTestList { get; set; }

        public DbSet<ValueListTypeOfSupplierAndVersion> VlTypeOfSupplierAndVersionList { get; set; }

        public DbSet<ValueListFinishedStatus> VlFinishedStatusList { get; set; }

        public DbSet<ValueListUserPrerequisite> VlUserPrerequisiteList { get; set; }

        public DbSet<ValueListTypeOfAnswer> VlTypeOfAnswer { get; set; }

        public DbSet<ValueListTypeOfResult> VlTypeOfResult { get; set; }

        public DbSet<ValueListTypeOfStatus> VlTypeOfStatus { get; set; }

        public DbSet<ValueListPurposeOfTest> VlPurposeOfTest { get; set; }

        public DbSet<RequirementUserPrerequisite> RequirementUserPrerequisiteList { get; set; }

        public DbSet<RuleItem> RuleList { get; set; }

        public DbSet<RuleItemLanguage> RuleLanguageList { get; set; }

        public DbSet<AnswerItem> AnswerList { get; set; }

        public DbSet<AnswerItemLanguage> AnswerLanguageList { get; set; }

        public DbSet<RequirementItem> RequirementList { get; set; }

        public DbSet<IndicatorItem> IndicatorList { get; set; }

        public DbSet<ChapterItem> ChapterList { get; set; }

        public DbSet<StandardItem> StandardList { get; set; }

        public DbSet<TestGroupItem> TestGroupList { get; set; }

        public DbSet<TestGroupItemLanguage> TestGroupLanguageList { get; set; }

        public DbSet<LanguageItem> LanguageList { get; set; }

        public DbSet<DeclarationIndicatorGroup> DeclarationIndicatorGroupList { get; set; }

        public DbSet<IndicatorTestGroup> IndicatorTestGroupList { get; set; }

        public DbSet<OutcomeData> OutcomeData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(x => new { x.UserItemId, x.RoleItemId });

            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.UserItem)
                .WithMany(x => x.RoleList)
                .HasForeignKey(x => x.UserItemId);

            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.RoleItem)
                .WithMany(x => x.UserList)
                .HasForeignKey(x => x.RoleItemId);

            modelBuilder.Entity<UserCompany>().HasKey(x => new { x.UserItemId, x.CompanyItemId });

            modelBuilder.Entity<UserCompany>()
                .HasOne(x => x.UserItem)
                .WithMany(x => x.CompanyList)
                .HasForeignKey(x => x.UserItemId);

            modelBuilder.Entity<UserCompany>()
                .HasOne(x => x.CompanyItem)
                .WithMany(x => x.UserList)
                .HasForeignKey(x => x.CompanyItemId);

            modelBuilder.Entity<IndicatorTestGroup>().HasKey(x => new { x.TestGroupItemId, x.IndicatorItemId });

            modelBuilder.Entity<IndicatorTestGroup>()
                .HasOne(x => x.IndicatorItem)
                .WithMany(x => x.TestGroupList)
                .HasForeignKey(x => x.IndicatorItemId);

            modelBuilder.Entity<IndicatorTestGroup>()
                .HasOne(x => x.TestGroupItem)
                .WithMany(x => x.IndicatorList)
                .HasForeignKey(x => x.TestGroupItemId);

            modelBuilder.Entity<DeclarationIndicatorGroup>().HasKey(x => new { x.DeclarationItemId, x.IndicatorItemId });

            modelBuilder.Entity<DeclarationIndicatorGroup>()
                .HasOne(x => x.IndicatorItem)
                .WithMany(x => x.DeclarationList)
                .HasForeignKey(x => x.IndicatorItemId);

            modelBuilder.Entity<DeclarationIndicatorGroup>()
                .HasOne(x => x.DeclarationItem)
                .WithMany(x => x.IndicatorList)
                .HasForeignKey(x => x.DeclarationItemId);

            modelBuilder.Entity<RequirementUserPrerequisite>().HasKey(x => new { x.RequirementItemId, x.ValueListUserPrerequisiteId });
            modelBuilder.Entity<IndicatorUserPrerequisite>().HasKey(x => new { x.IndicatorItemId, x.ValueListUserPrerequisiteId });
            modelBuilder.Entity<RequirementItem>().HasMany(x => x.RequirementUserPrerequisiteList);

            modelBuilder.Entity<AnswerData>().HasOne(x => x.AnswerItem).WithMany(x => x.AnswerDataList).Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<OutcomeData>().HasOne(x => x.Indicator).WithMany(x => x.OutcomeDataList).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            modelBuilder.Entity<OutcomeData>().HasMany(x => x.RuleDataList).WithOne(x => x.OutcomeData).Metadata.DeleteBehavior = DeleteBehavior.Cascade;

            modelBuilder.Entity<RuleItem>().HasOne(x => x.Chapter).WithMany(x => x.RuleList).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            modelBuilder.Entity<RuleItem>().HasOne(x => x.Standard).WithMany(x => x.RuleList).Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<RuleData>().HasOne(x => x.Rule).WithMany(x => x.RuleDataList).Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<RuleData>().HasOne(x => x.Result).WithMany(x=>x.RuleDataList).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            modelBuilder.Entity<OutcomeData>().HasOne(x => x.Result).WithMany(x => x.OutcomeDataList).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            modelBuilder.Entity<AnswerData>().HasOne(x => x.Result).WithMany(x => x.AnswerDataList).Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            var language1 = new LanguageItem
            {
                Id = Guid.Parse("8e25e2bf-e135-49b0-8c25-2c46d489d5e9"),
                Name = "nb-NO"
            };

            var language2 = new LanguageItem
            {
                Id = Guid.Parse("96d43981-d564-48e0-b416-975fe2b46dbe"),
                Name = "nn-NO"
            };

            var role1 = new RoleItem
            {
                Id = Guid.Parse("e7a78cdc-49f9-4e6c-8abd-afcfc08ca5eb"),
                Name = "Administrator",
                IsAdminRole = true
            };

            var role2 = new RoleItem
            {
                Id = Guid.Parse("9e184394-81bb-45cf-a157-dba79a3286d7"),
                Name = "Saksbehandler",
                IsAdminRole = true
            };

            var role3 = new RoleItem
            {
                Id = Guid.Parse("5ae2ea91-e0a2-48e7-a77b-c1ede6b973e1"),
                Name = "Virksomhet"
            };

            var user1 = new UserItem
            {
                Id = Guid.Parse("27e6f983-d5c8-4a18-a7f9-977c410e17f0"),
                SocialSecurityNumber = "12089400420",
                Token = "fqgADdXVzSgBdjIGl1KloQWjN-qGPN66S1h8EiBtg3g=",
                Name = "Martin Swartling",
                Email = "martin@difi.no",
                PhoneCountryCode = "0047",
                Phone = "912345678",
                Title = "Avdelingssjef",
                Created = new DateTime(2018, 12, 01, 12, 00, 00)
            };

            var user2 = new UserItem
            {
                Id = Guid.Parse("3812f52e-55a0-48d0-9a9c-54147c2fe90c"),
                SocialSecurityNumber = "12089400269",
                Token = "72og6NuGTB95NqnWN4Mj2IF_pVgodGv_qZ1F8c8u77c=",
                Name = "Thea Sneve",
                Email = "thea@difi.no",
                PhoneCountryCode = "0047",
                Phone = "712345678",
                Title = "Handläggare",
                Created = new DateTime(2018, 12, 01, 12, 00, 00)
            };

            modelBuilder.Entity<UserItem>().HasData(user1, user2);
            modelBuilder.Entity<RoleItem>().HasData(role1, role2, role3);

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    UserItemId = user1.Id,
                    RoleItemId = role1.Id
                },
                new UserRole
                {
                    UserItemId = user1.Id,
                    RoleItemId = role2.Id
                },
                new UserRole
                {
                    UserItemId = user2.Id,
                    RoleItemId = role2.Id
                });

            modelBuilder.Entity<ValueListTypeOfMachine>().HasData(new List<ValueListTypeOfMachine>
            {
                new ValueListTypeOfMachine {Id = 1, Text = "Betalingsterminal"},
                new ValueListTypeOfMachine {Id = 2, Text = "Billettautomat"},
                new ValueListTypeOfMachine {Id = 3, Text = "Selvbetjent kasse"},
                new ValueListTypeOfMachine {Id = 4, Text = "Minibank"},
                new ValueListTypeOfMachine {Id = 5, Text = "Vareautomat"},
            }.ToArray());

            modelBuilder.Entity<ValueListTypeOfTest>().HasData(new List<ValueListTypeOfTest>
            {
                new ValueListTypeOfTest {Id = 1, Text = "Automat"},
                new ValueListTypeOfTest {Id = 2, Text = "Webside"},
                new ValueListTypeOfTest {Id = 3, Text = "Applikasjon"}
            }.ToArray());

            modelBuilder.Entity<ValueListTypeOfSupplierAndVersion>().HasData(new List<ValueListTypeOfSupplierAndVersion>
            {
                new ValueListTypeOfSupplierAndVersion {Id = 1, Text = "Vet ikke"},
                new ValueListTypeOfSupplierAndVersion {Id = 200, Text = "Ingenico iCT250"},
                new ValueListTypeOfSupplierAndVersion {Id = 300, Text = "Ingenico iCT250E"},
                new ValueListTypeOfSupplierAndVersion {Id = 400, Text = "Ingenico iCT250r"},
                new ValueListTypeOfSupplierAndVersion {Id = 500, Text = "Ingenico iPP350"},
                new ValueListTypeOfSupplierAndVersion {Id = 600, Text = "Ingenico iSelf"},
                new ValueListTypeOfSupplierAndVersion {Id = 700, Text = "Ingenico iSMP"},
                new ValueListTypeOfSupplierAndVersion {Id = 800, Text = "Ingenico isMP4"},
                new ValueListTypeOfSupplierAndVersion {Id = 900, Text = "Ingenico iUP"},
                new ValueListTypeOfSupplierAndVersion {Id = 1000, Text = "Ingenico iWL250"},
                new ValueListTypeOfSupplierAndVersion {Id = 1100, Text = "Ingenico iWL250B "},
                new ValueListTypeOfSupplierAndVersion {Id = 1200, Text = "Ingenico iWL250G"},
                new ValueListTypeOfSupplierAndVersion {Id = 1300, Text = "Ingenico iWL251"},
                new ValueListTypeOfSupplierAndVersion {Id = 1400, Text = "Ingenico iWL252"},
                new ValueListTypeOfSupplierAndVersion {Id = 1500, Text = "iZettle Reader"},
                new ValueListTypeOfSupplierAndVersion {Id = 1600, Text = "SumUp Air"},
                new ValueListTypeOfSupplierAndVersion {Id = 1700, Text = "Verifone VX 520 C"},
                new ValueListTypeOfSupplierAndVersion {Id = 1800, Text = "Verifone VX 680"},
                new ValueListTypeOfSupplierAndVersion {Id = 1900, Text = "Verifone VX 690"},
                new ValueListTypeOfSupplierAndVersion {Id = 2000, Text = "Verifone VX 820"},
                new ValueListTypeOfSupplierAndVersion {Id = 2100, Text = "Verifone VX 820 Duet"},
                new ValueListTypeOfSupplierAndVersion {Id = 2200, Text = "Verifone Xenteo ECO"},
                new ValueListTypeOfSupplierAndVersion {Id = 2300, Text = "Verifone Yomani XR"},
                new ValueListTypeOfSupplierAndVersion {Id = 99999, Text = "Annet"},
            }.ToArray());

            modelBuilder.Entity<ValueListFinishedStatus>().HasData(new List<ValueListFinishedStatus>
            {
                new ValueListFinishedStatus {Id = 1, Text = "Inget"},
                new ValueListFinishedStatus {Id = 2, Text = "Avvik"},
                new ValueListFinishedStatus {Id = 3, Text = "Merknad"}
            }.ToArray());

            modelBuilder.Entity<ValueListUserPrerequisite>().HasData(new List<ValueListUserPrerequisite>
            {
                new ValueListUserPrerequisite {Id = 1, Text = "Blinde"},
                new ValueListUserPrerequisite {Id = 2, Text = "Svaksynte"},
                new ValueListUserPrerequisite {Id = 3, Text = "Fargeblinde"},
                new ValueListUserPrerequisite {Id = 4, Text = "Døvblinde"},
                new ValueListUserPrerequisite {Id = 5, Text = "Døve"},
                new ValueListUserPrerequisite {Id = 6, Text = "Nedsett høyrsel/tunghøyrde"},
                new ValueListUserPrerequisite {Id = 7, Text = "Nedsett kognisjon"},
                new ValueListUserPrerequisite {Id = 8, Text = "Nedsett motorikk"},
                new ValueListUserPrerequisite {Id = 9, Text = "Fotosensitivitet/anfall"},
                new ValueListUserPrerequisite {Id = 10, Text = "Fysisk størrelse"},
                new ValueListUserPrerequisite {Id = 11, Text = "Redusert taktil sensibilitet"},
            }.ToArray());

            var typeOfAnswer1 = new ValueListTypeOfAnswer { Id = 1, Text = "string" };
            var typeOfAnswer2 = new ValueListTypeOfAnswer { Id = 2, Text = "bool" };
            var typeOfAnswer3 = new ValueListTypeOfAnswer { Id = 3, Text = "int" };
            var typeOfAnswer4 = new ValueListTypeOfAnswer { Id = 4, Text = "image" };

            modelBuilder.Entity<ValueListTypeOfAnswer>().HasData(typeOfAnswer1, typeOfAnswer2, typeOfAnswer3, typeOfAnswer4);

            modelBuilder.Entity<ValueListTypeOfResult>().HasData(new List<ValueListTypeOfResult>
            {
                new ValueListTypeOfResult {Id = 1, Text = "Samsvar"},
                new ValueListTypeOfResult {Id = 2, Text = "Brudd"},
                new ValueListTypeOfResult {Id = 3, Text = "Ikke-forekomst"},
                new ValueListTypeOfResult {Id = 4, Text = "Ikke testbar"},
                new ValueListTypeOfResult {Id = 5, Text = "Ikke testa"}
            }.ToArray());

            modelBuilder.Entity<ValueListTypeOfStatus>().HasData(new List<ValueListTypeOfStatus>
            {
                new ValueListTypeOfStatus {Id = 1, Text = "Opprettet", TextAdmin = "Opprettet", TextCompany = "Ikke påbegynt"},
                new ValueListTypeOfStatus {Id = 2, Text = "Varslet", TextAdmin = "Pågår", TextCompany = "Ikke påbegynt"},
                new ValueListTypeOfStatus {Id = 3, Text = "Påbegynt", TextAdmin = "Pågår", TextCompany = "Påbegynt"},
                new ValueListTypeOfStatus {Id = 4, Text = "Fullført", TextAdmin = "Pågår", TextCompany = "Fullført"},
                new ValueListTypeOfStatus {Id = 5, Text = "Sendt tilbake", TextAdmin = "Pågår", TextCompany = "Sendt tilbake for korreksjon"},
                new ValueListTypeOfStatus {Id = 6, Text = "Avsluttet", TextAdmin = "Avsluttet", TextCompany = "Fullført"},
                new ValueListTypeOfStatus {Id = 7, Text = "Avlyst", TextAdmin = "Avlyst", TextCompany = "Avlyst"}
            }.ToArray());

            modelBuilder.Entity<ValueListPurposeOfTest>().HasData(new List<ValueListPurposeOfTest>
            {
                new ValueListPurposeOfTest {Id = 1, Text = "Pilotmåling"},
                new ValueListPurposeOfTest {Id = 2, Text = "Tilsyn"},
                new ValueListPurposeOfTest {Id = 3, Text = "Statysmåling"},
            }.ToArray());

            var standardItem1 = new StandardItem
            {
                Id = Guid.Parse("7851b33f-4cec-405c-8533-53cf7a6832e2"),
                Standard = "CEN/TS 15291:2006",
                Name = "Identification Card Systems - Guidance on design for accessible card-activated devices"
            };

            var chapterItem11 = new ChapterItem
            {
                Id = Guid.Parse("731a0f5c-f586-471f-b32c-ceb8027f735a"),
                ChapterHeading = "User operating space",
                ChapterNumber = "D.6.2",
                StandardItemId = standardItem1.Id
            };

            var chapterItem12 = new ChapterItem
            {
                Id = Guid.Parse("b80b9b15-8f0e-4702-b7d9-95cafa68f9fb"),
                ChapterHeading = "Overhead obstructions",
                ChapterNumber = "D.5.5",
                StandardItemId = standardItem1.Id
            };

            var chapterItem21 = new ChapterItem
            {
                Id = Guid.Parse("5f5abe28-1a74-4242-acc8-4b881ee4973a"),
                ChapterHeading = "Access from user operating area",
                ChapterNumber = "D.6.6",
                StandardItemId = standardItem1.Id
            };

            var chapterItem31 = new ChapterItem
            {
                Id = Guid.Parse("75468cd0-478b-45e9-8a8e-51b0e574fb3b"),
                ChapterHeading = "Location signs and visual indications",
                ChapterNumber = "5.2",
                StandardItemId = standardItem1.Id
            };

            var chapterItem41 = new ChapterItem
            {
                Id = Guid.Parse("6c0f12f8-0a91-4849-b18f-2af735017fcd"),
                ChapterHeading = "Layout of operating features",
                ChapterNumber = "6.3.1",
                StandardItemId = standardItem1.Id
            };

            var testGroup1 = new TestGroupItem
            {
                Id = Guid.Parse("aec1869a-30f8-403c-b909-df115173f009"),
                Order =  1,
            };

            var testGroupItemLanguage1 = new TestGroupItemLanguage
            {
                Id = Guid.Parse("d7f6c8de-9435-4c39-bd19-9642eca25e65"),
                Name = "Betjeningsområde",
                LanguageItemId = language1.Id,
                TestGroupItemId = testGroup1.Id
            };

            var testGroup2 = new TestGroupItem
            {
                Id = Guid.Parse("b6c22ac9-d775-4dfd-ac8e-b4ca565ea3fb"),
                Order = 2,
            };

            var testGroupItemLanguage2 = new TestGroupItemLanguage
            {
                Id = Guid.Parse("2b1d1f9a-1c00-43f5-b8f1-f598d146bc77"),
                Name = "Skilt",
                LanguageItemId = language1.Id,
                TestGroupItemId = testGroup2.Id
            };

            var testGroup3 = new TestGroupItem
            {
                Id = Guid.Parse("9aae6bc9-4b60-405c-81a7-ec142d8c1ca6"),
                Order = 3,
            };

            var testGroupItemLanguage3 = new TestGroupItemLanguage
            {
                Id = Guid.Parse("3b00207c-83a8-49a8-a65e-503b63cc73b1"),
                Name = "Betjeningshøyde",
                LanguageItemId = language1.Id,
                TestGroupItemId = testGroup3.Id
            };

            var indicatorItem1 = new IndicatorItem
            {
                Id = Guid.Parse("692627b2-53bc-43f2-900d-44a40a21e7e9"),
                Name = "Kundens betjeningsområde",
                LastChanged = new DateTime(2018,11,21)
            };

            var indicatorItem2 = new IndicatorItem
            {
                Id = Guid.Parse("6b4bf385-9174-4634-bc9e-bfbdab98586e"),
                Name = "Avstand mellom automater",
                LastChanged = new DateTime(2018, 11, 21)
            };

            var indicatorItem3 = new IndicatorItem
            {
                Id = Guid.Parse("c52eb3bc-6464-4dc9-b9f3-eb975e2a012c"),
                Name = "Plassering av skilt",
                LastChanged = new DateTime(2018, 11, 21)
            };

            var indicatorItem4 = new IndicatorItem
            {
                Id = Guid.Parse("5b2a0a78-039f-4173-bf9e-1ca0060d1c53"),
                Name = "Høyde på betalingsterm",
                LastChanged = new DateTime(2018, 11, 21)
            };

            var requirementItem1 = new RequirementItem
            {
                Id = Guid.Parse("875e76b5-c926-43a0-8738-c4f41c7a0b8b"),
                Description = "Krav 3.1 Betjeningsområdet foran betalingsterminalen skal være minst 150 x 150 centimeter. Det skal ikke være hindringer i betjeningsområdet.",
                IndicatorItemId = indicatorItem1.Id
            };

            var requirementItem2 = new RequirementItem
            {
                Id = Guid.Parse("c65786bb-1b93-4153-b88c-935cc2a7ab60"),
                Description = "Krav 3.5 Dersom to eller flere automater står ved siden av hverandre, skal det være minst 150 centimeter fra midten av automaten til midten av neste automat.",
                IndicatorItemId = indicatorItem2.Id
            };

            var requirementItem3 = new RequirementItem
            {
                Id = Guid.Parse("aebd662d-9dd5-4a27-88d5-19d6c5e12e5a"),
                Description = "Krav 1.3 Skilt skal plasseres over betalingsterminalen.",
                IndicatorItemId = indicatorItem3.Id
            };

            var requirementItem4 = new RequirementItem
            {
                Id = Guid.Parse("e503322b-ed77-4b69-adc4-eca19b6eb97d"),
                Description = "Krav 4.2: Høyden på betjeningskomponenter som skjerm og tastatur skal være mellom 75 centimeter og 130 centimeter over gulvet.",
                IndicatorItemId = indicatorItem4.Id
            };

            var indicatorTestGroup1 = new IndicatorTestGroup
            {
                IndicatorItemId = indicatorItem1.Id,
                TestGroupItemId = testGroup1.Id,
                Order = 1
            };

            var indicatorTestGroup2 = new IndicatorTestGroup
            {
                IndicatorItemId = indicatorItem2.Id,
                TestGroupItemId = testGroup1.Id,
                Order = 2
            };

            var indicatorTestGroup3 = new IndicatorTestGroup
            {
                IndicatorItemId = indicatorItem3.Id,
                TestGroupItemId = testGroup2.Id,
                Order = 1
            };

            var indicatorTestGroup4 = new IndicatorTestGroup
            {
                IndicatorItemId = indicatorItem4.Id,
                TestGroupItemId = testGroup3.Id,
                Order = 1
            };

            var ruleItem11 = new RuleItem
            {
                Order = 1,
                RequirementItemId = requirementItem1.Id,
                IndicatorItemId = indicatorItem1.Id,
                Id = Guid.Parse("eb160c6c-3a9e-4dff-93df-577d9eab4e09"),
                ChapterItemId = chapterItem11.Id,
                StandardItemId = standardItem1.Id,
            };

            var ruleItemLanguage11 = new RuleItemLanguage
            {
                Id = Guid.Parse("6ae15ad1-51c2-4d8f-817d-7acf925c5de9"),
                HelpText = "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/01.png' width='400' alt='Illustrasjon' /><p>Kundens betjeningsområde er plassen foran betalingsterminalen, der kundene står når de bruker betalingsterminalen for å betale varene sine.<br />Illustrasjonen viser kundens betjeningsområde for betalingsterminalen. Det er et krav at dette området skal være minst 150 x 150 cm og uten hindringer.<br />Du skal nå måle opp kundens betjeningsområde i form av et kvadrat. Hensikten med å måle opp området er at du skal få en bedre forståelse av hva du skal sjekke i egenkontrollen.<br /><ul><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 75 cm mot venstre</li><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 75 cm mot høyre</li><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 150 cm ut i lokalet</li></ul></p></div><div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/11.png' width='400' alt='Illustrasjon' /><h3>Krav:</h3><p>Kundens betjeningsområde foran betalingsterminalen skal være minst 150 x 150 centimeter. Det skal være uten hindringer.</p><h3>Hensikt:</h3><p>Formålet er at rullestolbrukere kan komme frem til betalingsterminalen og snu rullestolen om det trengs. Hindringer gjør det vanskelig for kunden å komme frem til og bruke betalingsterminalen. En hindring er for eksempel varehyller, stolper, vegger, søppelbøtter, skilt eller benker.</p><p>Om der er mulig, skal du ta bort hindringer i kundens betjeningsområde før du svarer på spørsmålet.</p></div>",
                LanguageItemId = language1.Id,
                RuleItemId = ruleItem11.Id
            };

            var ruleItem12 = new RuleItem
            {
                Order = 2,
                RequirementItemId = requirementItem1.Id,
                IndicatorItemId = indicatorItem1.Id,
                Id = Guid.Parse("b64cac7e-6525-49e8-9112-0238e1588ed8"),
                ChapterItemId = chapterItem12.Id,
                StandardItemId = standardItem1.Id
            };

            var ruleItemLanguage12 = new RuleItemLanguage
            {
                Id = Guid.Parse("804438bd-ac67-40ff-9168-6814ea843242"),
                HelpText = "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/12.png' width='400' alt='Illustrasjon' /><h3>Krav:</h3><p>Det skal ikke henge gjenstander lavere enn 220 cm ned i kundens betjeningsområde.</p><h3>Hensikt:</h3><p>Hindringer kan også henge ned fra taket, som for eksempel skilt, plakater og lamper. Det gjør det vanskelig for høye kunder å komme frem til og bruke betalingsterminalen.</p></div>",
                LanguageItemId = language1.Id,
                RuleItemId = ruleItem12.Id
            };

            var ruleItem21 = new RuleItem
            {
                Order = 1,
                RequirementItemId = requirementItem2.Id,
                IndicatorItemId = indicatorItem2.Id,
                Id = Guid.Parse("0d6c763e-e0f6-4049-adeb-ae9429262b57"),
                ChapterItemId = chapterItem21.Id,
                StandardItemId = standardItem1.Id
            };

            var ruleItemLanguage21 = new RuleItemLanguage
            {
                Id = Guid.Parse("e369820b-ebcd-488e-9216-477d363f18ed"),
                HelpText = "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/21.png' width='400' alt='Illustrasjon' /><h3>Krav: </h3><p>Dersom to eller flere betalingsterminaler står ved siden av hverandre på rett linje, skal det være minst 150 centimeter fra midten av betalingsterminalen til midten av neste betalingsterminal. NB Kravet gjelder ikke der betalingsterminalene står overfor hverandre.</p><h3>Hensikt: </h3><p>Formålet er at betalingsterminaler som står ved siden av hverandre, kan brukes samtidig, og at kundene som skal betale varene sine, kan komme seg bort uten å forstyrre hverandre.<br />Dersom det er flere betalingsterminaler som står ved siden av hverandre på rett linje, mål avstanden til den nærmeste.<br />Utgangspunktet for målingen er midt foran på betalingsterminalen.<br /></p></div>",
                LanguageItemId = language1.Id,
                RuleItemId = ruleItem21.Id
            };

            var ruleItem31 = new RuleItem
            {
                Order = 1,
                RequirementItemId = requirementItem3.Id,
                IndicatorItemId = indicatorItem3.Id,
                Id = Guid.Parse("832e0843-cab3-4dbc-9799-974e283fcc0b"),
                ChapterItemId = chapterItem31.Id,
                StandardItemId = standardItem1.Id
            };

            var ruleItemLanguage31 = new RuleItemLanguage
            {
                Id = Guid.Parse("55294d7b-6af0-4399-8a5c-776aa13e3a29"),
                HelpText = "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/31.png' width='400' alt='Illustrasjon' /><h3>Krav:</h3><p>Skiltet skal plasseres over betalingsterminalen. Skiltet skal være synlig på avstand, utenfor kundens betjeningsområde.</p><h3>Hensikt: </h3><p>Formålet er at kunden lett skal finne fram til betalingsterminalen.<br />Skiltet skal være plassert over området der kunden skal betale varene sine. Det kan for eksempel være over kassen eller disken der betalingsterminalen står.<br />Eksempler på tekst på skilt er<br /><ul><li>Kasse</li><li>Betal her</li><li>Kort og kontanter</li><li>Nummer på kassen</li></ul></p></div>",
                LanguageItemId = language1.Id,
                RuleItemId = ruleItem31.Id
            };

            var ruleItem41 = new RuleItem
            {
                Order = 1,
                RequirementItemId = requirementItem4.Id,
                IndicatorItemId = indicatorItem4.Id,
                Id = Guid.Parse("5b3af04b-f6c6-4425-a22f-c2e7479839a5"),
                ChapterItemId = chapterItem41.Id,
                StandardItemId = standardItem1.Id
            };

            var ruleItemLanguage41 = new RuleItemLanguage
            {
                Id = Guid.Parse("d8c7e031-b2eb-4906-8c4d-c1d5f3266bbc"),
                HelpText = "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/41.png' width='400' alt='Illustrasjon' /><h3>Krav: </h3><p>Høyden på betjeningskomponenter som skjerm og tastatur skal være mellom 75 centimeter og 130 centimeter over gulvet.</p><h3>Hensikt:</h3><p>Formålet er at betalingsterminalen skal være enkel å nå og bruke, både for kunder som står og kunder som sitter, f.eks. rullestolbrukere.<br />Dersom du kan justere høyden på betalingsterminalen, skal du flytte den til mellom 75 og 130 cm over gulvet før du måler.<br />Utgangspunktet for målingen er midt på betalingsterminalen.</p></div>",
                LanguageItemId = language1.Id,
                RuleItemId = ruleItem41.Id
            };

            var answerItem111 = new AnswerItem
            {
                Order = 1,
                Id = Guid.Parse("02d2db89-3717-48e1-883e-8e526bf6c727"),
                TypeOfAnswerId = typeOfAnswer2.Id,
                Bool = false,
                RuleItemId = ruleItem11.Id
            };

            var answerItemLanguage111 = new AnswerItemLanguage
            {
                Id = Guid.Parse("2583fbbf-12a3-475d-b610-41b5ad0327c1"),
                LanguageItemId = language1.Id,
                AnswerItemId = answerItem111.Id,
                Question = "Finnes det hindringer i kundens betjeningsområde?",
                BoolTrueText = "Ja",
                BoolFalseText = "Nei",
            };

            var answerItem112 = new AnswerItem
            {
                Order = 3,
                Id = Guid.Parse("6912d4a0-b73b-4ecc-9fa8-49e1fd356635"),
                TypeOfAnswerId = typeOfAnswer4.Id,
                RuleItemId = ruleItem11.Id,
            };

            var answerItemLanguage112 = new AnswerItemLanguage
            {
                Id = Guid.Parse("db55a19e-7f42-4176-921d-4a09698f727a"),
                LanguageItemId = language1.Id,
                AnswerItemId = answerItem112.Id,
                Question = "Ta bilde",
            };

            var answerItem113 = new AnswerItem
            {
                Order = 2,
                Id = Guid.Parse("d7b40e3c-e7fa-44e5-b44f-750759c971cc"),
                TypeOfAnswerId = typeOfAnswer1.Id,
                RuleItemId = ruleItem11.Id,
                LinkedParentFailedId = answerItem111.Id,
            };

            var answerItemLanguage113 = new AnswerItemLanguage
            {
                Id = Guid.Parse("6876174d-2e2c-484b-a9a7-14cb63359a30"),
                LanguageItemId = language1.Id,
                AnswerItemId = answerItem113.Id,
                Question = "Beskriv hindringene i kundens betjeningsområde.",
            };

            var answerItem121 = new AnswerItem
            {
                Order = 1,
                Id = Guid.Parse("a1964762-5c8f-40bb-a22d-c907149079d4"),
                TypeOfAnswerId = typeOfAnswer2.Id,
                Bool = false,
                RuleItemId = ruleItem12.Id,
            };

            var answerItemLanguage121 = new AnswerItemLanguage
            {
                Id = Guid.Parse("3ec18f01-3e59-4cb1-b4b3-75e0af67ac2f"),
                LanguageItemId = language1.Id,
                AnswerItemId = answerItem121.Id,
                Question = "Henger det gjenstander over kundens betjeningsområde?",
                BoolTrueText = "Ja",
                BoolFalseText = "Nei",
            };

            var answerItem122 = new AnswerItem
            {
                Order = 2,
                Id = Guid.Parse("bf459d05-702d-47d7-a5b7-19f8b3fb67c9"),
                TypeOfAnswerId = typeOfAnswer2.Id,
                Bool = true,
                RuleItemId = ruleItem12.Id,
                LinkedParentFailedId = answerItem121.Id,
            };

            var answerItemLanguage122 = new AnswerItemLanguage
            {
                Id = Guid.Parse("1670250d-7f81-4fd0-90a2-d9a8df97df8a"),
                LanguageItemId = language1.Id,
                AnswerItemId = answerItem122.Id,
                Question = "Hvor mange cm over gulvet henger den laveste gjenstanden i kundens betjeningsområde?",
                BoolTrueText = "220 cm eller mer",
                BoolFalseText = "0-219 cm, ",
            };

            var answerItem123 = new AnswerItem
            {
                Order = 3,
                Id = Guid.Parse("5544b740-0b5f-400c-b7b2-7e6472d4160b"),
                TypeOfAnswerId = typeOfAnswer3.Id,
                MinInt = 220,
                MaxInt = -1,
                RuleItemId = ruleItem12.Id,
                LinkedParentFailedId = answerItem122.Id,
                AlwaysVisible = true
            };

            var answerItemLanguage123 = new AnswerItemLanguage
            {
                Id = Guid.Parse("4b1e6cba-160c-4adb-a6cf-0736f1d585c2"),
                LanguageItemId = language1.Id,
                AnswerItemId = answerItem123.Id,
                Question = "Mål i cm",
            };

            var answerItem124 = new AnswerItem
            {
                Order = 4,
                Id = Guid.Parse("8a12d92b-8a6a-44e7-9517-74331a4c2483"),
                TypeOfAnswerId = typeOfAnswer4.Id,
                RuleItemId = ruleItem12.Id,
            };

            var answerItemLanguage124 = new AnswerItemLanguage
            {
                Id = Guid.Parse("6c73f84c-a2d5-43ac-a5fe-793d0c5672cc"),
                LanguageItemId = language1.Id,
                AnswerItemId = answerItem124.Id,
                Question = "Ta bilde",
            };

            var answerItem211 = new AnswerItem
            {
                Order = 1,
                Id = Guid.Parse("202d20e0-61df-4a7c-8287-104e3b439f64"),
                TypeOfAnswerId = typeOfAnswer2.Id,
                Bool = false,
                RuleItemId = ruleItem21.Id
            };

            var answerItemLanguage211 = new AnswerItemLanguage
            {
                Id = Guid.Parse("7c632541-119a-4dd5-b501-e0ba7e2caff2"),
                LanguageItemId = language1.Id,
                AnswerItemId = answerItem211.Id,
                Question = "Står betalingsterminalen ved siden av en annen betalingsterminal, på rett linje?",
                BoolTrueText = "Ja",
                BoolFalseText = "Nei",
            };

            var answerItem212 = new AnswerItem
            {
                Order = 2,
                Id = Guid.Parse("89fd2205-1047-403d-a5bd-f70a1de2f247"),
                TypeOfAnswerId = typeOfAnswer2.Id,
                RuleItemId = ruleItem21.Id,
                Bool = true,
                LinkedParentFailedId = answerItem211.Id
            };

            var answerItemLanguage212 = new AnswerItemLanguage
            {
                Id = Guid.Parse("b760e91c-81f5-4de9-82c2-3747c23dbf9d"),
                LanguageItemId = language1.Id,
                AnswerItemId = answerItem212.Id,
                Question = "Hvor mange cm er det mellom betalingsterminalene?",
                BoolTrueText = "150 cm eller mer",
                BoolFalseText = "0-149 cm, ",
            };

            var answerItem213 = new AnswerItem
            {
                Order = 3,
                Id = Guid.Parse("78b8d910-c0bb-4467-acbe-1320f51fe658"),
                TypeOfAnswerId = typeOfAnswer3.Id,
                MinInt = 150,
                MaxInt = -1,
                RuleItemId = ruleItem21.Id,
                LinkedParentFailedId = answerItem212.Id,
                AlwaysVisible = true
            };

            var answerItemLanguage213 = new AnswerItemLanguage
            {
                Id = Guid.Parse("cb3bfb9a-b373-4264-9add-3f4ec562c402"),
                LanguageItemId = language1.Id,
                AnswerItemId = answerItem213.Id,
                Question = "Mål i cm",
            };

            var answerItem214 = new AnswerItem
            {
                Order = 4,
                Id = Guid.Parse("13d6d530-e533-4510-9a66-8b862899dbdf"),
                TypeOfAnswerId = typeOfAnswer4.Id,
                RuleItemId = ruleItem21.Id
            };

            var answerItemLanguage214 = new AnswerItemLanguage
            {
                Id = Guid.Parse("6e68729a-50e9-4844-a791-43e2eb21fad0"),
                LanguageItemId = language1.Id,
                AnswerItemId = answerItem214.Id,
                Question = "Ta bilde",
            };


            var answerItem311 = new AnswerItem
            {
                Order = 1,
                Id = Guid.Parse("d8611e84-0f00-4d75-bcab-cbf127fb68b5"),
                TypeOfAnswerId = typeOfAnswer2.Id,
                Bool = true,
                RuleItemId = ruleItem31.Id
            };

            var answerItemLanguage311 = new AnswerItemLanguage
            {
                Id = Guid.Parse("463efa96-5c19-4945-8bac-100a2b4c6916"),
                LanguageItemId = language1.Id,
                AnswerItemId = answerItem311.Id,
                Question = "Finnes det et skilt som viser hvor kunden skal betale varene sine?",
                BoolTrueText = "Ja",
                BoolFalseText = "Nei",
            };

            var answerItem312 = new AnswerItem
            {
                Order = 4,
                Id = Guid.Parse("c4870935-ee11-4557-a9c3-aca678c17565"),
                TypeOfAnswerId = typeOfAnswer4.Id,
                RuleItemId = ruleItem31.Id
            };

            var answerItemLanguage312 = new AnswerItemLanguage
            {
                Id = Guid.Parse("ec0e3dd2-bd43-4e44-a118-51b86b80d77f"),
                LanguageItemId = language1.Id,
                AnswerItemId = answerItem312.Id,
                Question = "Ta bilde",
            };

            var answerItem313 = new AnswerItem
            {
                Order = 2,
                Id = Guid.Parse("9a51cc68-857e-4822-ac81-0ec3ebe7bf43"),
                TypeOfAnswerId = typeOfAnswer2.Id,
                Bool = true,
                RuleItemId = ruleItem31.Id,
                LinkedParentCorrectId = answerItem311.Id
            };

            var answerItemLanguage313 = new AnswerItemLanguage
            {
                Id = Guid.Parse("14b18d90-1b1f-4628-b15e-edc9afe5a0a1"),
                LanguageItemId = language1.Id,
                AnswerItemId = answerItem313.Id,
                Question = "Er skiltet plassert over området der kunden skal betale varene sine?",
                BoolTrueText = "Ja",
                BoolFalseText = "Nei",
            };

            var answerItem314 = new AnswerItem
            {
                Order = 3,
                Id = Guid.Parse("f69c1e45-99d8-4293-a242-c5ed9e126e99"),
                TypeOfAnswerId = typeOfAnswer2.Id,
                Bool = true,
                RuleItemId = ruleItem31.Id,
                LinkedParentCorrectId = answerItem311.Id
            };

            var answerItemLanguage314 = new AnswerItemLanguage
            {
                Id = Guid.Parse("0ed22f35-94ec-46d1-9aad-615f91bbb1b0"),
                LanguageItemId = language1.Id,
                AnswerItemId = answerItem314.Id,
                Question = "Er skiltet synlig på avstand utenfor kundens betjeningsområde?",
                BoolTrueText = "Ja",
                BoolFalseText = "Nei",
            };

            var answerItem411 = new AnswerItem
            {
                Order = 1,
                Id = Guid.Parse("f98f67e5-cf6a-4afe-8998-3132640f9d70"),
                TypeOfAnswerId = typeOfAnswer2.Id,
                Bool = true,
                RuleItemId = ruleItem41.Id
            };

            var answerItemLanguage411 = new AnswerItemLanguage
            {
                Id = Guid.Parse("8da3f1e2-4ed3-4957-b94d-797ed932ec73"),
                LanguageItemId = language1.Id,
                AnswerItemId = answerItem411.Id,
                Question = "Hvor mange cm er det fra gulvet og opp til betalingsterminalen?",
                BoolTrueText = "Mellom 75cm og 130cm over gulvet",
                BoolFalseText = "Annat, ",
            };

            var answerItem412 = new AnswerItem
            {
                Order = 2,
                Id = Guid.Parse("9aea071e-7263-4b2e-8cd7-5193fbbe5b77"),
                TypeOfAnswerId = typeOfAnswer3.Id,
                MinInt = 75,
                MaxInt = 130,
                RuleItemId = ruleItem41.Id,
                LinkedParentFailedId = answerItem411.Id,
                AlwaysVisible = true
            };

            var answerItemLanguage412 = new AnswerItemLanguage
            {
                Id = Guid.Parse("f94c4896-806c-4ce1-b6a3-ebf090ee9789"),
                LanguageItemId = language1.Id,
                AnswerItemId = answerItem412.Id,
                Question = "Mål i cm",
            };

            var answerItem413 = new AnswerItem
            {
                Order = 3,
                Id = Guid.Parse("438787f3-b33b-489c-b5a8-2f046a634dea"),
                TypeOfAnswerId = typeOfAnswer4.Id,
                RuleItemId = ruleItem41.Id
            };

            var answerItemLanguage413 = new AnswerItemLanguage
            {
                Id = Guid.Parse("2e2e8b32-c7c4-4ffa-b6b7-275a82e5b6af"),
                LanguageItemId = language1.Id,
                AnswerItemId = answerItem413.Id,
                Question = "Ta bilde",
            };

            modelBuilder.Entity<LanguageItem>().HasData(language1, language2);
            modelBuilder.Entity<TestGroupItem>().HasData(testGroup1, testGroup2, testGroup3);
            modelBuilder.Entity<TestGroupItemLanguage>().HasData(testGroupItemLanguage1, testGroupItemLanguage2, testGroupItemLanguage3);
            modelBuilder.Entity<StandardItem>().HasData(standardItem1);
            modelBuilder.Entity<ChapterItem>().HasData(chapterItem11, chapterItem12, chapterItem21, chapterItem31, chapterItem41);
            modelBuilder.Entity<IndicatorItem>().HasData(indicatorItem1, indicatorItem2, indicatorItem3, indicatorItem4);
            modelBuilder.Entity<IndicatorTestGroup>().HasData(indicatorTestGroup1, indicatorTestGroup2, indicatorTestGroup3, indicatorTestGroup4);
            modelBuilder.Entity<RequirementItem>().HasData(requirementItem1, requirementItem2, requirementItem3, requirementItem4);
            modelBuilder.Entity<RuleItem>().HasData(ruleItem11, ruleItem12, ruleItem21, ruleItem31, ruleItem41);
            modelBuilder.Entity<RuleItemLanguage>().HasData(ruleItemLanguage11, ruleItemLanguage12, ruleItemLanguage21, ruleItemLanguage31, ruleItemLanguage41);
            modelBuilder.Entity<AnswerItem>().HasData(answerItem111, answerItem112, answerItem113, answerItem124, answerItem121, answerItem122, answerItem123, answerItem211, answerItem212, answerItem213, answerItem214, answerItem311, answerItem312, answerItem313, answerItem314, answerItem411, answerItem412, answerItem413);
            modelBuilder.Entity<AnswerItemLanguage>().HasData(answerItemLanguage111, answerItemLanguage112, answerItemLanguage113, answerItemLanguage124, answerItemLanguage121, answerItemLanguage122, answerItemLanguage123, answerItemLanguage211, answerItemLanguage212, answerItemLanguage213, answerItemLanguage214, answerItemLanguage311, answerItemLanguage312, answerItemLanguage313, answerItemLanguage314, answerItemLanguage411, answerItemLanguage412, answerItemLanguage413);

            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}