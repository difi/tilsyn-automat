﻿using System;
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

        public DbSet<AnswerItem> AnswerList { get; set; }

        public DbSet<RequirementItem> RequirementList { get; set; }

        public DbSet<IndicatorItem> IndicatorList { get; set; }

        public DbSet<ChapterItem> ChapterList { get; set; }

        public DbSet<StandardItem> StandardList { get; set; }

        public DbSet<TestGroupItem> TestGroupList { get; set; }

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

            //modelBuilder.Entity<IndicatorTestGroup>().HasOne(x => x.IndicatorItem).WithMany(x => x.TestGroupList).Metadata.DeleteBehavior = DeleteBehavior.Restrict;


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
                Created = new DateTime(2011, 1, 1, 12, 00, 00)
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
                Created = new DateTime(2011, 1, 1, 12, 00, 00)
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
                new ValueListTypeOfSupplierAndVersion {Id = 2, Text = "Ingenico iCT250"},
                new ValueListTypeOfSupplierAndVersion {Id = 3, Text = "Ingenico iCT250E"},
                new ValueListTypeOfSupplierAndVersion {Id = 4, Text = "Ingenico iCT250r"},
                new ValueListTypeOfSupplierAndVersion {Id = 5, Text = "Ingenico iPP350"},
                new ValueListTypeOfSupplierAndVersion {Id = 6, Text = "Ingenico iSelf"},
                new ValueListTypeOfSupplierAndVersion {Id = 7, Text = "Ingenico iSMP"},
                new ValueListTypeOfSupplierAndVersion {Id = 8, Text = "Ingenico isMP4"},
                new ValueListTypeOfSupplierAndVersion {Id = 9, Text = "Ingenico iUP"},
                new ValueListTypeOfSupplierAndVersion {Id = 10, Text = "Ingenico iWL250"},
                new ValueListTypeOfSupplierAndVersion {Id = 11, Text = "Ingenico iWL250B "},
                new ValueListTypeOfSupplierAndVersion {Id = 12, Text = "Ingenico iWL250G"},
                new ValueListTypeOfSupplierAndVersion {Id = 13, Text = "Ingenico iWL251"},
                new ValueListTypeOfSupplierAndVersion {Id = 14, Text = "Ingenico iWL252"},
                new ValueListTypeOfSupplierAndVersion {Id = 15, Text = "iZettle Reader"},
                new ValueListTypeOfSupplierAndVersion {Id = 16, Text = "SumUp Air"},
                new ValueListTypeOfSupplierAndVersion {Id = 17, Text = "Verifone VX 520 C"},
                new ValueListTypeOfSupplierAndVersion {Id = 18, Text = "Verifone VX 680"},
                new ValueListTypeOfSupplierAndVersion {Id = 19, Text = "Verifone VX 690"},
                new ValueListTypeOfSupplierAndVersion {Id = 20, Text = "Verifone VX 820"},
                new ValueListTypeOfSupplierAndVersion {Id = 21, Text = "Verifone VX 820 Duet"},
                new ValueListTypeOfSupplierAndVersion {Id = 22, Text = "Verifone Xenteo ECO"},
                new ValueListTypeOfSupplierAndVersion {Id = 23, Text = "Verifone Yomani XR"},
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
                Name = "Betjeningsområde",
                Order =  1,
            };

            var testGroup2 = new TestGroupItem
            {
                Id = Guid.Parse("b6c22ac9-d775-4dfd-ac8e-b4ca565ea3fb"),
                Name = "Skilt",
                Order = 2,
            };

            var testGroup3 = new TestGroupItem
            {
                Id = Guid.Parse("9aae6bc9-4b60-405c-81a7-ec142d8c1ca6"),
                Name = "Betjeningshøyde",
                Order = 3,
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
                HelpText = "",
                ToolsNeed = "Ingen",
                ChapterItemId = chapterItem11.Id,
                StandardItemId = standardItem1.Id,
            };

            var ruleItem12 = new RuleItem
            {
                Order = 2,
                RequirementItemId = requirementItem1.Id,
                IndicatorItemId = indicatorItem1.Id,
                Id = Guid.Parse("b64cac7e-6525-49e8-9112-0238e1588ed8"),
                HelpText = "",
                ToolsNeed = "Ingen",
                ChapterItemId = chapterItem12.Id,
                StandardItemId = standardItem1.Id
            };

            var ruleItem21 = new RuleItem
            {
                Order = 1,
                RequirementItemId = requirementItem2.Id,
                IndicatorItemId = indicatorItem2.Id,
                Id = Guid.Parse("0d6c763e-e0f6-4049-adeb-ae9429262b57"),
                HelpText = "",
                ToolsNeed = "Ingen",
                ChapterItemId = chapterItem21.Id,
                StandardItemId = standardItem1.Id
            };

            var ruleItem31 = new RuleItem
            {
                Order = 1,
                RequirementItemId = requirementItem3.Id,
                IndicatorItemId = indicatorItem3.Id,
                Id = Guid.Parse("832e0843-cab3-4dbc-9799-974e283fcc0b"),
                HelpText = "Krav: Skilt skal plasseres over betalingsterminalen.<br /><br />Det skal være et skilt som er synlig på avstand utenfor kundens betjeningsområde. Formålet er at brukeren kan finne fram til betalingsterminalen.<br /><br />Skiltet skal være plassert over området der kunden skal betale varene sine. Det kan for eksempel være over kassen eller disken der betalingsterminalen er plassert.<br /><br />Eksempler på tekst på skilt er<br />- Kasse<br />- Betal her<br />- Kort og kontant<br />- Nummer på kasse<br />",
                ToolsNeed = "Ingen",
                ChapterItemId = chapterItem31.Id,
                StandardItemId = standardItem1.Id
            };

            var ruleItem41 = new RuleItem
            {
                Order = 1,
                RequirementItemId = requirementItem4.Id,
                IndicatorItemId = indicatorItem4.Id,
                Id = Guid.Parse("5b3af04b-f6c6-4425-a22f-c2e7479839a5"),
                ToolsNeed = "Ingen",
                ChapterItemId = chapterItem41.Id,
                StandardItemId = standardItem1.Id
            };

            var answerItem111 = new AnswerItem
            {
                Question = "Finnes det hindringer i kundens betjeningsområde?",
                Order = 1,
                Id = Guid.Parse("02d2db89-3717-48e1-883e-8e526bf6c727"),
                TypeOfAnswerId = typeOfAnswer2.Id,
                Bool = false,
                RuleItemId = ruleItem11.Id
            };

            var answerItem112 = new AnswerItem
            {
                Question = "Ta bilde",
                Order = 3,
                Id = Guid.Parse("6912d4a0-b73b-4ecc-9fa8-49e1fd356635"),
                TypeOfAnswerId = typeOfAnswer4.Id,
                RuleItemId = ruleItem11.Id,
            };

            var answerItem113 = new AnswerItem
            {
                Question = "Beskriv hindringene i kundens betjeningsområde.",
                Order = 2,
                Id = Guid.Parse("d7b40e3c-e7fa-44e5-b44f-750759c971cc"),
                TypeOfAnswerId = typeOfAnswer1.Id,
                RuleItemId = ruleItem11.Id,
                ViewIfParentFailedId = answerItem111.Id,
            };

            var answerItem121 = new AnswerItem
            {
                Question = "Henger det gjenstander over kundens betjeningsområde?",
                Order = 1,
                Id = Guid.Parse("a1964762-5c8f-40bb-a22d-c907149079d4"),
                TypeOfAnswerId = typeOfAnswer2.Id,
                Bool = false,
                RuleItemId = ruleItem12.Id,
            };

            var answerItem122 = new AnswerItem
            {
                Question = "Ta bilde",
                Order = 3,
                Id = Guid.Parse("8a12d92b-8a6a-44e7-9517-74331a4c2483"),
                TypeOfAnswerId = typeOfAnswer4.Id,
                RuleItemId = ruleItem12.Id,
            };

            var answerItem123 = new AnswerItem
            {
                Question = "Hvor mange cm over gulvet henger den laveste gjenstanden i kundens betjeningsområde?",
                Order = 2,
                Id = Guid.Parse("bf459d05-702d-47d7-a5b7-19f8b3fb67c9"),
                TypeOfAnswerId = typeOfAnswer3.Id,
                MinInt = 220,
                MaxInt = -1,
                RuleItemId = ruleItem12.Id,
                ViewIfParentFailedId = answerItem121.Id,
            };

            var answerItem211 = new AnswerItem
            {
                Question = "Står betalingsterminalen ved siden av en annen betalingsterminal, på rett linje?",
                Order = 1,
                Id = Guid.Parse("202d20e0-61df-4a7c-8287-104e3b439f64"),
                TypeOfAnswerId = typeOfAnswer2.Id,
                Bool = false,
                RuleItemId = ruleItem21.Id
            };

            var answerItem212 = new AnswerItem
            {
                Question = "Ta bilde",
                Order = 3,
                Id = Guid.Parse("13d6d530-e533-4510-9a66-8b862899dbdf"),
                TypeOfAnswerId = typeOfAnswer4.Id,
                RuleItemId = ruleItem21.Id
            };

            var answerItem213 = new AnswerItem
            {
                Question = "Hvor mange cm er det mellom betalingsterminalene?",
                Order = 2,
                Id = Guid.Parse("89fd2205-1047-403d-a5bd-f70a1de2f247"),
                TypeOfAnswerId = typeOfAnswer3.Id,
                MinInt = 150,
                MaxInt = -1,
                RuleItemId = ruleItem21.Id,
                ViewIfParentFailedId = answerItem211.Id
            };

            var answerItem311 = new AnswerItem
            {
                Question = "Finnes det et skilt som viser hvor kunden skal betale varene sine?",
                Order = 1,
                Id = Guid.Parse("d8611e84-0f00-4d75-bcab-cbf127fb68b5"),
                TypeOfAnswerId = typeOfAnswer2.Id,
                Bool = true,
                RuleItemId = ruleItem31.Id
            };

            var answerItem312 = new AnswerItem
            {
                Question = "Ta bilde",
                Order = 4,
                Id = Guid.Parse("c4870935-ee11-4557-a9c3-aca678c17565"),
                TypeOfAnswerId = typeOfAnswer4.Id,
                RuleItemId = ruleItem31.Id
            };

            var answerItem313 = new AnswerItem
            {
                Question = "Er skiltet plassert over området der kunden skal betale varene sine?",
                Order = 2,
                Id = Guid.Parse("9a51cc68-857e-4822-ac81-0ec3ebe7bf43"),
                TypeOfAnswerId = typeOfAnswer2.Id,
                Bool = true,
                RuleItemId = ruleItem31.Id,
                ViewIfParentCorrectId = answerItem311.Id
            };

            var answerItem314 = new AnswerItem
            {
                Question = "Er skiltet synlig på avstand utenfor kundens betjeningsområde?",
                Order = 3,
                Id = Guid.Parse("f69c1e45-99d8-4293-a242-c5ed9e126e99"),
                TypeOfAnswerId = typeOfAnswer2.Id,
                Bool = true,
                RuleItemId = ruleItem31.Id,
                ViewIfParentCorrectId = answerItem311.Id
            };

            var answerItem141 = new AnswerItem
            {
                Question = "Hvor mange cm er det fra gulvet og opp til betalingsterminalen?",
                Order = 1,
                Id = Guid.Parse("f98f67e5-cf6a-4afe-8998-3132640f9d70"),
                TypeOfAnswerId = typeOfAnswer3.Id,
                MaxInt = 130,
                MinInt = 75,
                RuleItemId = ruleItem41.Id
            };

            var answerItem412 = new AnswerItem
            {
                Question = "Ta bilde",
                Order = 2,
                Id = Guid.Parse("438787f3-b33b-489c-b5a8-2f046a634dea"),
                TypeOfAnswerId = typeOfAnswer4.Id,
                RuleItemId = ruleItem41.Id
            };

            modelBuilder.Entity<TestGroupItem>().HasData(testGroup1, testGroup2, testGroup3);
            modelBuilder.Entity<StandardItem>().HasData(standardItem1);
            modelBuilder.Entity<ChapterItem>().HasData(chapterItem11, chapterItem12, chapterItem21, chapterItem31, chapterItem41);
            modelBuilder.Entity<IndicatorItem>().HasData(indicatorItem1, indicatorItem2, indicatorItem3, indicatorItem4);
            modelBuilder.Entity<IndicatorTestGroup>().HasData(indicatorTestGroup1, indicatorTestGroup2, indicatorTestGroup3, indicatorTestGroup4);
            modelBuilder.Entity<RequirementItem>().HasData(requirementItem1, requirementItem2, requirementItem3, requirementItem4);
            modelBuilder.Entity<RuleItem>().HasData(ruleItem11, ruleItem12, ruleItem21, ruleItem31, ruleItem41);
            modelBuilder.Entity<AnswerItem>().HasData(answerItem111, answerItem112, answerItem113, answerItem121, answerItem122, answerItem123, answerItem211, answerItem212, answerItem213, answerItem311, answerItem312, answerItem313, answerItem314, answerItem141, answerItem412);

            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}