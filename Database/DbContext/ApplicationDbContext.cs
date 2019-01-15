using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.Language;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.Standard;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Database.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
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

        public DbSet<RequirementItemLanguage> RequirementLanguageList { get; set; }

        public DbSet<IndicatorItem> IndicatorList { get; set; }

        public DbSet<IndicatorOutcomeItem> IndicatorOutcomeList { get; set; }

        public DbSet<IndicatorOutcomeItemLanguage> IndicatorOutcomeLanguageList { get; set; }

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

            modelBuilder.Entity<RuleData>().HasOne(x => x.Result).WithMany(x => x.RuleDataList).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
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
                SocialSecurityNumber = 12089400420,
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
                SocialSecurityNumber = 12089400269,
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
                new ValueListTypeOfSupplierAndVersion {Id = 1, Nb = "Velg betalingsterminal", Nn = "Vel betalingsterminal"},
                new ValueListTypeOfSupplierAndVersion {Id = 100, Nb = "Vet ikke", Nn = "Veit ikkje"},
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
                new ValueListTypeOfSupplierAndVersion {Id = 99999, Nb = "Annet", Nn = "Anna"},
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
                new ValueListTypeOfResult {Id = 1, Nb = "Samsvar", Nn = "Samsvar"},
                new ValueListTypeOfResult {Id = 2, Nb = "Brudd", Nn = "Brot"},
                new ValueListTypeOfResult {Id = 3, Text = "Ikke-forekomst"},
                new ValueListTypeOfResult {Id = 4, Text = "Ikke testbar"},
                new ValueListTypeOfResult {Id = 5, Text = "Ikke testa"}
            }.ToArray());

            modelBuilder.Entity<ValueListTypeOfStatus>().HasData(new List<ValueListTypeOfStatus>
            {
                new ValueListTypeOfStatus
                {
                    Id = 1,
                    Nb = "Opprettet",
                    Nn = "Oppretta",
                    CompanyNb = "Ikke påbegynt",
                    CompanyNn = "Ikkje starta på"
                },
                new ValueListTypeOfStatus
                {
                    Id = 2,
                    Nb = "Varslet",
                    Nn = "Varsla",
                    CompanyNb = "Ikke påbegynt",
                    CompanyNn = "Ikkje starta på"
                },
                new ValueListTypeOfStatus
                {
                    Id = 3,
                    Nb = "Påbegynt",
                    Nn = "Starta på",
                    CompanyNb = "Påbegynt",
                    CompanyNn = "Starta på"
                },
                new ValueListTypeOfStatus
                {
                    Id = 4,
                    Nb = "Fullført",
                    Nn = "Fullført",
                    CompanyNb = "Fullført",
                    CompanyNn = "Fullført"
                },
                new ValueListTypeOfStatus
                {
                    Id = 5,
                    Nb = "Åpen for korreksjon",
                    Nn = "Open for korreksjon",
                    CompanyNb = "Åpen for korreksjon",
                    CompanyNn = "Open for korreksjon"
                },
                new ValueListTypeOfStatus
                {
                    Id = 6,
                    Nb = "Avsluttet",
                    Nn = "Avslutta",
                    CompanyNb = "Fullført",
                    CompanyNn = "Fullført"
                },
                new ValueListTypeOfStatus
                {
                    Id = 7,
                    Nb = "Avlyst",
                    Nn = "Avlyst",
                    CompanyNb = "Avlyst",
                    CompanyNn = "Avlyst"
                }
            }.ToArray());

            modelBuilder.Entity<ValueListPurposeOfTest>().HasData(new List<ValueListPurposeOfTest>
            {
                new ValueListPurposeOfTest {Id = 1, Text = "Pilotmåling"},
                new ValueListPurposeOfTest {Id = 2, Text = "Tilsyn"},
                new ValueListPurposeOfTest {Id = 3, Text = "Statusmåling"}
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
                Order = 1,
            };

            var testGroupItemLanguage1 = new TestGroupItemLanguage
            {
                Id = Guid.Parse("d7f6c8de-9435-4c39-bd19-9642eca25e65"),
                Name = "Betjeningsområde",
                LanguageItemId = language1.Id,
                TestGroupItemId = testGroup1.Id
            };

            var testGroupItemLanguage1Nn = new TestGroupItemLanguage
            {
                Id = Guid.Parse("a6287d57-476c-4676-9d93-435a4e2f4195"),
                Name = "Beteningsområde",
                LanguageItemId = language2.Id,
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

            var testGroupItemLanguage2Nn = new TestGroupItemLanguage
            {
                Id = Guid.Parse("98fff1d6-1b62-4de8-9b0c-7c107bd04dfb"),
                Name = "Skilt",
                LanguageItemId = language2.Id,
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

            var testGroupItemLanguage3Nn = new TestGroupItemLanguage
            {
                Id = Guid.Parse("18b44c34-20b1-4999-8170-8814493f8fc0"),
                Name = "Beteningshøgde",
                LanguageItemId = language2.Id,
                TestGroupItemId = testGroup3.Id
            };

            var indicatorItem1 = new IndicatorItem
            {
                Id = Guid.Parse("692627b2-53bc-43f2-900d-44a40a21e7e9"),
                Name = "Kundens betjeningsområde",
                LastChanged = new DateTime(2018, 11, 21)
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
                IndicatorItemId = indicatorItem1.Id
            };

            var requirementItemLanguage1 = new RequirementItemLanguage
            {
                Id = Guid.Parse("0290478b-5818-437b-9097-7fbeaf3433a2"),
                Description = "Krav 3.1 Betjeningsområdet foran betalingsterminalen skal være minst 150 x 150 centimeter. Betjeningsområdet skal være uten hindringer",
                RequirementItemId = requirementItem1.Id,
                LanguageItemId = language1.Id,
            };

            var requirementItemLanguage1Nn = new RequirementItemLanguage
            {
                Id = Guid.Parse("49cd54b9-d1d5-4f06-9186-20e3de25a7af"),
                Description = "Krav 3.1 Beteningsområde framføre betalingsterminalen skal vere minst 150 x 150 centimeter. Beteningsområde skal vere utan hindringar.",
                RequirementItemId = requirementItem1.Id,
                LanguageItemId = language2.Id,
            };

            var requirementItem2 = new RequirementItem
            {
                Id = Guid.Parse("c65786bb-1b93-4153-b88c-935cc2a7ab60"),
                IndicatorItemId = indicatorItem2.Id
            };

            var requirementItemLanguage2 = new RequirementItemLanguage
            {
                Id = Guid.Parse("b9247a56-97d9-4aeb-ad1d-224c1d410eaf"),
                Description = "Krav 3.5 Dersom to eller flere automater står ved siden av hverandre, skal det være minst 150 centimeter fra midten av automaten til midten av neste automat.",
                RequirementItemId = requirementItem2.Id,
                LanguageItemId = language1.Id
            };

            var requirementItemLanguage2Nn = new RequirementItemLanguage
            {
                Id = Guid.Parse("d283278d-a276-4001-99fd-faab0a7dbb5d"),
                Description = "Krav 3.5 Dersom to eller fleire automatar står ved sida av kvarandre, skal det vere minst 150 centimeter frå midten av automaten til midten av neste automat.",
                RequirementItemId = requirementItem2.Id,
                LanguageItemId = language2.Id
            };

            var requirementItem3 = new RequirementItem
            {
                Id = Guid.Parse("aebd662d-9dd5-4a27-88d5-19d6c5e12e5a"),
                IndicatorItemId = indicatorItem3.Id,
            };

            var requirementItemLanguage3 = new RequirementItemLanguage
            {
                Id = Guid.Parse("5c873d77-9c1e-4c6f-82b6-83fdd77e892a"),
                Description = "Krav 1.3 Skilt skal plasseres over betalingsterminalen.",
                RequirementItemId = requirementItem3.Id,
                LanguageItemId = language1.Id
            };

            var requirementItemLanguage3Nn = new RequirementItemLanguage
            {
                Id = Guid.Parse("6ac22f59-843c-4b3b-a1c6-aa4bd95bc779"),
                Description = "Krav 1.3 Skilt skal plasserast over betalingsterminalen.",
                RequirementItemId = requirementItem3.Id,
                LanguageItemId = language2.Id
            };

            var requirementItem4 = new RequirementItem
            {
                Id = Guid.Parse("e503322b-ed77-4b69-adc4-eca19b6eb97d"),
                IndicatorItemId = indicatorItem4.Id
            };

            var requirementItemLanguage4 = new RequirementItemLanguage
            {
                Id = Guid.Parse("5ec84619-9cd3-4ee8-adad-9e55d04482d7"),
                Description = "Krav 4.2: Høyden på betjeningskomponenter som skjerm og tastatur skal være mellom 75 centimeter og 130 centimeter over gulvet.",
                RequirementItemId = requirementItem4.Id,
                LanguageItemId = language1.Id
            };

            var requirementItemLanguage4Nn = new RequirementItemLanguage
            {
                Id = Guid.Parse("74555409-91a1-4b81-97ec-76e005909a5e"),
                Description = "Krav 4.2: Høgda på beteningskomponentar som skjerm og tastatur skal vere mellom 75 centimeter og 130 centimeter over golvet. ",
                RequirementItemId = requirementItem4.Id,
                LanguageItemId = language2.Id
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
                HelpText = "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/01.png' alt='Avstander i kundens betjeningsområde. Illustrasjon.' /><p>Kundens betjeningsområde er plassen foran betalingsterminalen, der kundene står når de bruker betalingsterminalen for å betale varene sine, som vist i illustrasjonen over.</p><p>Du skal nå måle opp kundens betjeningsområde i form av et kvadrat. Hensikten med å måle opp området er at du skal få en bedre forståelse av hva du skal sjekke i egenkontrollen.</p><ul><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 75 cm mot venstre</li><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 75 cm mot høyre</li><li>Mål fra kassen/disken. Start på punktet midt foran betalingsterminalen og mål 150 cm ut i lokalet</li></ul></div><div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/11.png' alt='Kundens betjeningsområde foran betalingsautomaten. Illustrasjon.' /><h3>Krav:</h3><p>Kundens betjeningsområde foran betalingsterminalen skal være minst 150 x 150 centimeter. Betjeningsområdet skal være uten hindringer.</p><h3>Hensikt:</h3><p>Formålet er at rullestolbrukere kan komme frem til betalingsterminalen og snu rullestolen om det trengs. Hindringer gjør det vanskelig for kunden å komme frem til og bruke betalingsterminalen. En hindring er for eksempel varehyller, stolper, vegger, søppelbøtter, skilt eller benker.</p><p>Om det er mulig, skal du ta bort hindringer i kundens betjeningsområde før du svarer på spørsmålet.</p></div>",
                LanguageItemId = language1.Id,
                RuleItemId = ruleItem11.Id
            };

            var ruleItemLanguage11Nn = new RuleItemLanguage
            {
                Id = Guid.Parse("578dad2b-fa8c-4091-bcf3-336bf9fc5999"),
                HelpText = "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/01.png' alt='Avstander i kundens betjeningsområde. Illustrasjon.' /><p>Beteningsområdet til kunden er plassen framføre betalingsterminalen, der kundane står når dei brukar betalingsterminalen for å betale varene sine, som vist i illustrasjonen over.</p><p>Du skal no måle opp beteningsområdet til kunden i form av eit kvadrat. Formålet med å måle opp området er at du skal få ei betre forståing av kva du skal sjekke i eigenkontrollen.</p><ul><li>Mål frå kassen/disken. Start på punktet midt framføre betalingsterminalen og mål 75 cm mot venstre</li><li>Mål frå kassen/disken. Start på punktet midt framføre betalingsterminalen og mål 75 cm mot høgre</li><li>Mål frå kassen/disken. Start på punktet midt framføre betalingsterminalen og mål 150 cm ut i lokalet</li></ul></div><div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/11.png' alt='Kundens betjeningsområde foran betalingsautomaten. Illustrasjon.' /><h3>Krav:</h3><p><p>Beteningsområdet til kunden framføre betalingsterminalen skal vere minst 150 x 150 centimeter. Beteningsområde skal vere utan hindringar.</p><h3>Formål:</h3><p>Formålet er at rullestolbrukarar kan kome fram til betalingsterminalen og snu rullestolen om det trengst. Hindringar gjer det vanskeleg for kunden å kome fram til og bruke betalingsterminalen. Ei hindring er for eksempel varehyller, stolpar, veggar, søppelbøtter, skilt eller benkar.</p><p>Dersom det er mogleg, skal du ta bort hindringar i beteningsområdet til kunden før du svarar på spørsmålet.</p></div>",
                LanguageItemId = language2.Id,
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
                HelpText = "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/12.png' alt='Gjenstander over betjeningsområdet. Illustrasjon.' /><h3>Krav:</h3><p>Det skal ikke henge gjenstander lavere enn 220 cm ned i kundens betjeningsområde.</p><h3>Hensikt:</h3><p>Formålet er at høye kunder lett skal komme frem til og bruke betalingsterminalen. En hindring er for eksempel l skilt, plakater og lamper som henger ned fra taket.</p></div>",
                LanguageItemId = language1.Id,
                RuleItemId = ruleItem12.Id
            };

            var ruleItemLanguage12Nn = new RuleItemLanguage
            {
                Id = Guid.Parse("74eb4727-2bd8-4031-aa84-6d2f31411ea7"),
                HelpText = "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/12.png' alt='Gjenstander over betjeningsområdet. Illustrasjon.' /><h3>Krav:</h3><p>Det skal ikkje henge gjenstandar lågare enn 220 cm ned i beteningsområdet til kunden.</p><h3>Formål:</h3><p>Formålet er at høge kundar lett skal kome fram til og bruke betalingsterminalen. Ei hindring er for eksempel skilt, plakatar og lamper som heng ned frå taket.</p></div>",
                LanguageItemId = language2.Id,
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
                HelpText = "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/21.png' alt='Krav på avstand mellom betalingsautomater. Illustrasjon' /><h3>Krav: </h3><p>Dersom to eller flere betalingsterminaler står ved siden av hverandre på rett linje, skal det være minst 150 centimeter fra midten av betalingsterminalen til midten av neste betalingsterminal. NB Kravet gjelder ikke der betalingsterminalene står overfor hverandre.</p><h3>Hensikt: </h3><p>Formålet er at betalingsterminaler som står ved siden av hverandre, kan brukes samtidig, og at kundene som skal betale varene sine, kan komme seg bort uten å forstyrre hverandre.<br />Dersom det er flere betalingsterminaler som står ved siden av hverandre på rett linje, skal du måle avstanden til den nærmeste.<br />Utgangspunktet for målingen er midt foran på betalingsterminalen.</p></div>",
                LanguageItemId = language1.Id,
                RuleItemId = ruleItem21.Id
            };

            var ruleItemLanguage21Nn = new RuleItemLanguage
            {
                Id = Guid.Parse("63b58e58-cf92-4f17-b5e4-99a799d5d979"),
                HelpText = "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/21.png' alt='Krav på avstand mellom betalingsautomater. Illustrasjon' /><h3>Krav: </h3><p>Dersom to eller fleire betalingsterminalar står ved sidan av kvarandre på rett linje, skal det vere minst 150 centimeter frå midten av betalingsterminalen til midten av neste betalingsterminal. NB: Kravet gjeld ikkje der betalingsterminalane står overfor kvarandre.</p><h3>Formål:</h3><p>Formålet er at betalingsterminalar som står ved sida av kvarandre, kan brukast samtidig, og at kundane som skal betale varene sine, kan kome seg bort utan å forstyrre kvarandre.<br />Dersom det er fleire betalingsterminalar som står ved sidan av kvarandre på rett linje, skal du måle avstanden til den nærmaste.<br />Utgangspunktet for målinga er midt framme på betalingsterminalen.</p></div>",
                LanguageItemId = language2.Id,
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
                HelpText = "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/31.png' alt='Skilt over betalingsområdet. Illustrasjon' /><h3>Krav:</h3><p>Skiltet skal plasseres over betalingsterminalen. Skiltet skal være synlig på avstand, utenfor kundens betjeningsområde.</p><h3>Hensikt: </h3><p>Formålet er at kunden lett skal finne fram til betalingsterminalen.<br />Skiltet skal være plassert over området der kunden skal betale varene sine. Det kan for eksempel være over kassen eller disken der betalingsterminalen står.<br />Eksempler på tekst på skilt er</p><ul><li>Kasse</li><li>Betal her</li><li>Kort og kontanter</li><li>Nummer på kassen</li></ul></div>",
                LanguageItemId = language1.Id,
                RuleItemId = ruleItem31.Id
            };

            var ruleItemLanguage31Nn = new RuleItemLanguage
            {
                Id = Guid.Parse("3217ae5f-047d-44c9-8615-be563b296639"),
                HelpText = "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/31.png' alt='Skilt over betalingsområdet. Illustrasjon' /><h3>Krav:</h3><p>Skiltet skal plasserast over betalingsterminalen. Skiltet skal vere synleg på avstand, utanfor beteningsområdet til kunden.</p><h3>Formål:</h3><p>Formålet er at kunden lett skal finne fram til betalingsterminalen.<br />Skiltet skal vere plassert over området der kunden skal betale varene sine. Det kan for eksempel vere over kassa eller disken der betalingsterminalen står.<br />Eksempel på tekst på skilt er</p><ul><li>Kasse</li><li>Betal her</li><li>Kort og kontantar</li><li>Nummer på kassa</li></ul></div>",
                LanguageItemId = language2.Id,
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
                HelpText = "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/41.png' alt='Høyden på betjeningskomponenter. Illustrasjon' /><h3>Krav: </h3><p>Høyden på betjeningskomponenter som skjerm og tastatur skal være mellom 75 centimeter og 130 centimeter over gulvet.</p><h3>Hensikt:</h3><p>Formålet er at betalingsterminalen skal være enkel å nå og bruke, både for kunder som står og kunder som sitter, f.eks. rullestolbrukere.<br />Dersom du kan justere høyden på betalingsterminalen, skal du flytte den til mellom 75 og 130 cm over gulvet før du måler.<br />Utgangspunktet for målingen er midt på betalingsterminalen.</p></div>",
                LanguageItemId = language1.Id,
                RuleItemId = ruleItem41.Id
            };

            var ruleItemLanguage41Nn = new RuleItemLanguage
            {
                Id = Guid.Parse("9f7dff24-12db-40b9-9803-9f9af82058d1"),
                HelpText = "<div class='xlarge-6 large-6 small-12 small-centered text-center end columns'></div><div class='medium-11 medium-centered small-12 columns'><img src='/images/illustrations/41.png' alt='Høyden på betjeningskomponenter. Illustrasjon' /><h3>Krav: </h3><p>Høgda på beteningskomponentar som skjerm og tastatur skal vere mellom 75 centimeter og 130 centimeter over golvet.</p><h3>Formål:</h3><p>Formålet er at betalingsterminalen skal vere enkel å nå og bruke, både for kundar som står og kundar som sit, f.eks. rullestolbrukarar.<br />Dersom du kan justere høgda på betalingsterminalen, skal du flytte han til mellom 75 og 130 cm over golvet før du måler.<br />Utgangspunktet for målinga er midt på betalingsterminalen.</p></div>",
                LanguageItemId = language2.Id,
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

            var answerItemLanguage111Nn = new AnswerItemLanguage
            {
                Id = Guid.Parse("b552415f-6d7a-4900-b177-2628b234cce2"),
                LanguageItemId = language2.Id,
                AnswerItemId = answerItem111.Id,
                Question = "Finst det hindringar i beteningsområdet til kunden?",
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
                Question = "Bekreft med bilde",
            };

            var answerItemLanguage112Nn = new AnswerItemLanguage
            {
                Id = Guid.Parse("d61c82e8-a3a1-444f-bb63-ef34ba4b720e"),
                LanguageItemId = language2.Id,
                AnswerItemId = answerItem112.Id,
                Question = "Stadfest med bilde",
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
                Question = "Beskriv hindringene i kundens betjeningsområde:",
            };

            var answerItemLanguage113Nn = new AnswerItemLanguage
            {
                Id = Guid.Parse("eef618a0-e5bf-483a-8c10-fac1c04aa6be"),
                LanguageItemId = language2.Id,
                AnswerItemId = answerItem113.Id,
                Question = "Beskriv hindringane i beteningsområdet til kunden.",
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

            var answerItemLanguage121Nn = new AnswerItemLanguage
            {
                Id = Guid.Parse("28550bd9-fcba-4a39-be91-d2a6331a26e9"),
                LanguageItemId = language2.Id,
                AnswerItemId = answerItem121.Id,
                Question = "Heng det gjenstandar over beteningsområdet til kunden?",
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
                BoolFalseText = "0-219 cm, "
            };

            var answerItemLanguage122Nn = new AnswerItemLanguage
            {
                Id = Guid.Parse("d7d086fb-99a8-42b6-8200-338a85d886a1"),
                LanguageItemId = language2.Id,
                AnswerItemId = answerItem122.Id,
                Question = "Kor mange cm over golvet heng den lågaste gjenstanden i beteningsområdet til kunden?",
                BoolTrueText = "220 cm eller meir",
                BoolFalseText = "0-219 cm, "
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

            var answerItemLanguage123Nn = new AnswerItemLanguage
            {
                Id = Guid.Parse("2a0296f1-7ed5-4e38-97b4-defba4439b69"),
                LanguageItemId = language2.Id,
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
                Question = "Bekreft med bilde",
            };

            var answerItemLanguage124Nn = new AnswerItemLanguage
            {
                Id = Guid.Parse("93a705e1-5c90-4a6f-a03d-c2e3c449e4a6"),
                LanguageItemId = language2.Id,
                AnswerItemId = answerItem124.Id,
                Question = "Stadfest med bilde",
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

            var answerItemLanguage211Nn = new AnswerItemLanguage
            {
                Id = Guid.Parse("d28ac0ea-244d-478a-9ba2-efb51deb9b90"),
                LanguageItemId = language2.Id,
                AnswerItemId = answerItem211.Id,
                Question = "Står betalingsterminalen ved sidan av ein annan betalingsterminal, på rett linje?",
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

            var answerItemLanguage212Nn = new AnswerItemLanguage
            {
                Id = Guid.Parse("844733d7-44b6-4813-b8a6-8ed36012e1a4"),
                LanguageItemId = language2.Id,
                AnswerItemId = answerItem212.Id,
                Question = "Kor mange cm er det mellom betalingsterminalane?",
                BoolTrueText = "150 cm eller meir",
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

            var answerItemLanguage213Nn = new AnswerItemLanguage
            {
                Id = Guid.Parse("21aebbf3-e13d-4fff-a2e2-23e2ac613c29"),
                LanguageItemId = language2.Id,
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
                Question = "Bekreft med bilde",
            };

            var answerItemLanguage214Nn = new AnswerItemLanguage
            {
                Id = Guid.Parse("dde428e6-e13b-4140-860b-b185661d8dc6"),
                LanguageItemId = language2.Id,
                AnswerItemId = answerItem214.Id,
                Question = "Stadfest med bilde",
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

            var answerItemLanguage311Nn = new AnswerItemLanguage
            {
                Id = Guid.Parse("ed52107e-359a-4c71-b44e-1ea9a0052917"),
                LanguageItemId = language2.Id,
                AnswerItemId = answerItem311.Id,
                Question = "Finst det eit skilt som viser kvar kunden skal betale varene sine?",
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
                Question = "Bekreft med bilde",
            };

            var answerItemLanguage312Nn = new AnswerItemLanguage
            {
                Id = Guid.Parse("8db67b5c-e3b1-4053-a66a-3499c54a545d"),
                LanguageItemId = language2.Id,
                AnswerItemId = answerItem312.Id,
                Question = "Stadfest med bilde",
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

            var answerItemLanguage313Nn = new AnswerItemLanguage
            {
                Id = Guid.Parse("5bf1b010-1ad3-4b16-899d-d71463e5b3b7"),
                LanguageItemId = language2.Id,
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

            var answerItemLanguage314Nn = new AnswerItemLanguage
            {
                Id = Guid.Parse("9241ebd9-5d9d-4646-9531-f52e047ef3f1"),
                LanguageItemId = language2.Id,
                AnswerItemId = answerItem314.Id,
                Question = "Er skiltet synleg på avstand utanfor beteningsområdet til kunden?",
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
                BoolFalseText = "Annet, ",
            };

            var answerItemLanguage411Nn = new AnswerItemLanguage
            {
                Id = Guid.Parse("fd3d3290-b415-495d-8c38-bf6c6fb2a679"),
                LanguageItemId = language2.Id,
                AnswerItemId = answerItem411.Id,
                Question = "Kor mange cm er det frå golvet og opp til betalingsterminalen?",
                BoolTrueText = "Mellom 75 cm og 130 cm over golvet",
                BoolFalseText = "Anna, ",
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

            var answerItemLanguage412Nn = new AnswerItemLanguage
            {
                Id = Guid.Parse("e08eadf6-9f65-4af4-a202-12e24eba3a13"),
                LanguageItemId = language2.Id,
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
                Question = "Bekreft med bilde",
            };

            var answerItemLanguage413Nn = new AnswerItemLanguage
            {
                Id = Guid.Parse("dbf5bc8b-de37-4c68-8219-f2785d832eb3"),
                LanguageItemId = language2.Id,
                AnswerItemId = answerItem413.Id,
                Question = "Stadfest med bilde",
            };

            var indicatorOutcomeItem11 = new IndicatorOutcomeItem
            {
                Id = Guid.Parse("0025bb09-6dfe-4069-ae6b-27cb28ba8300"),
                IndicatorItemId = indicatorItem1.Id,
                Order = 1,
                ResultString1 = "1,1"
            };

            var indicatorOutcomeItem12 = new IndicatorOutcomeItem
            {
                Id = Guid.Parse("d438e931-f57c-4a5c-bb5c-3e3a66824827"),
                IndicatorItemId = indicatorItem1.Id,
                Order = 2,
                ResultString1 = "1,1,1",
                ResultString2 = "1,1,1,1"
            };

            var indicatorOutcomeItem13 = new IndicatorOutcomeItem
            {
                Id = Guid.Parse("d18a7bce-556c-45cc-87d7-c765261166d5"),
                IndicatorItemId = indicatorItem1.Id,
                Order = 3,
                ResultString1 = "1,2,2,2"
            };

            var indicatorOutcomeItem14 = new IndicatorOutcomeItem
            {
                Id = Guid.Parse("a9b2bb20-7240-4a93-ba1a-ae270e8679f1"),
                IndicatorItemId = indicatorItem1.Id,
                Order = 4,
                ResultString1 = "2,1"
            };

            var indicatorOutcomeItem15 = new IndicatorOutcomeItem
            {
                Id = Guid.Parse("4edceffe-eb77-4ca0-a498-24be5372d333"),
                IndicatorItemId = indicatorItem1.Id,
                Order = 5,
                ResultString1 = "2,1,1",
                ResultString2 = "2,1,1,1"
            };

            var indicatorOutcomeItem16 = new IndicatorOutcomeItem
            {
                Id = Guid.Parse("6cd1b621-12e6-4a03-bd6e-a7c8b39de251"),
                IndicatorItemId = indicatorItem1.Id,
                Order = 6,
                ResultString1 = "2,2,2,2"
            };

            var indicatorOutcomeItemLanguage11 = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("2e230687-302b-4da7-ae95-00d615f1fc2a"),
                IndicatorOutcomeItemId = indicatorOutcomeItem11.Id,
                LanguageItemId = language1.Id,
                OutcomeText = "Kundens betjeningsområde foran betalingsterminalen er uten hindringer. Det henger ikke gjenstander over kundens betjeningsområde."
            };

            var indicatorOutcomeItemLanguage11Nn = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("880a21aa-fb0f-41e6-b627-f40db33a4b71"),
                IndicatorOutcomeItemId = indicatorOutcomeItem11.Id,
                LanguageItemId = language2.Id,
                OutcomeText = "Beteningsområde til kunden framføre betalingsterminalen er utan hindringar. Det heng ikkje gjenstandar over beteningsområde til kunden."
            };

            var indicatorOutcomeItemLanguage12 = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("cf2e7b7c-7fdd-45d1-8140-f6c299805358"),
                IndicatorOutcomeItemId = indicatorOutcomeItem12.Id,
                LanguageItemId = language1.Id,
                OutcomeText = "Kundens betjeningsområde foran betalingsterminalen er uten hindringer. Gjenstander som henger over kundens betjeningsområde, er minst 220 cm over gulvet."
            };

            var indicatorOutcomeItemLanguage12Nn = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("6a198dba-d09e-43b3-bd79-8b1733b93912"),
                IndicatorOutcomeItemId = indicatorOutcomeItem12.Id,
                LanguageItemId = language2.Id,
                OutcomeText = "Beteningsområde til kunden framføre betalingsterminalen er utan hindringar. Gjenstandar som heng over beteningsområde til kunden, er minst 220 cm over golvet."
            };

            var indicatorOutcomeItemLanguage13 = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("20dc4731-c388-40f9-8c6a-45b92591f003"),
                IndicatorOutcomeItemId = indicatorOutcomeItem13.Id,
                LanguageItemId = language1.Id,
                OutcomeText = "Kundens betjeningsområde foran betalingsterminalen er uten hindringer. Gjenstander som henger over kundens betjeningsområde, er lavere enn 220 cm over gulvet."
            };

            var indicatorOutcomeItemLanguage13Nn = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("1d35bc8d-0e41-4532-83ec-c0e7f66406f8"),
                IndicatorOutcomeItemId = indicatorOutcomeItem13.Id,
                LanguageItemId = language2.Id,
                OutcomeText = "Beteningsområde til kunden framføre betalingsterminalen er utan hindringar. Gjenstandar som heng over beteningsområde til kunden, er lågare enn 220 cm over golvet."
            };

            var indicatorOutcomeItemLanguage14 = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("5631c088-146b-4df6-98a6-7a7f4e8d6331"),
                IndicatorOutcomeItemId = indicatorOutcomeItem14.Id,
                LanguageItemId = language1.Id,
                OutcomeText = "Det finnes hindringer i kundens betjeningsområde foran betalingsterminalen. Det henger ikke gjenstander over kundens betjeningsområde."
            };

            var indicatorOutcomeItemLanguage14Nn = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("db731f0f-830c-48d9-ae42-2583d3c1583e"),
                IndicatorOutcomeItemId = indicatorOutcomeItem14.Id,
                LanguageItemId = language2.Id,
                OutcomeText = "Det finst hindringar i beteningsområde til kunden framføre betalingsterminalen. Det heng ikkje gjenstandar over beteningsområde til kunden."
            };

            var indicatorOutcomeItemLanguage15 = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("bace523f-8d4c-4c2f-80e7-b87e2a4fb330"),
                IndicatorOutcomeItemId = indicatorOutcomeItem15.Id,
                LanguageItemId = language1.Id,
                OutcomeText = "Det finnes hindringer i kundens betjeningsområde foran betalingsterminalen. Gjenstander som henger over kundens betjeningsområde, er minst 220 cm over gulvet."
            };

            var indicatorOutcomeItemLanguage15Nn = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("7d583641-4a2d-465c-ac49-98f67198be7f"),
                IndicatorOutcomeItemId = indicatorOutcomeItem15.Id,
                LanguageItemId = language2.Id,
                OutcomeText = "Det finst hindringar i beteningsområde til kunden framføre betalingsterminalen. Gjenstandar som heng over beteningsområde til kunden, er minst 220 cm over golvet."
            };

            var indicatorOutcomeItemLanguage16 = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("174f9a3a-a5b9-4e00-8fcb-f3d9b8fd215e"),
                IndicatorOutcomeItemId = indicatorOutcomeItem16.Id,
                LanguageItemId = language1.Id,
                OutcomeText = "Det finnes hindringer i kundens betjeningsområde foran betalingsterminalen og gjenstander som henger over kundens betjeningsområde, er lavere enn 220 cm over gulvet."
            };

            var indicatorOutcomeItemLanguage16Nn = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("cf89bc22-6e6d-4877-b82b-2c77eedc02ca"),
                IndicatorOutcomeItemId = indicatorOutcomeItem16.Id,
                LanguageItemId = language2.Id,
                OutcomeText = "Det finst hindringar i beteningsområde til kunden framføre betalingsterminalen og gjenstandar som heng over beteningsområde til kunden, er lågare enn 220 cm over golvet."
            };

            var indicatorOutcomeItem21 = new IndicatorOutcomeItem
            {
                Id = Guid.Parse("30f07a36-ff0b-4692-b7bf-0f2d8dee923a"),
                IndicatorItemId = indicatorItem2.Id,
                Order = 1,
                ResultString1 = "1,1",
                ResultString2 = "1,1,1"
            };

            var indicatorOutcomeItem22 = new IndicatorOutcomeItem
            {
                Id = Guid.Parse("ae869b09-090d-459b-827c-4d61a1578478"),
                IndicatorItemId = indicatorItem2.Id,
                Order = 2,
                ResultString1 = "2,2,2"
            };

            var indicatorOutcomeItem23 = new IndicatorOutcomeItem
            {
                Id = Guid.Parse("c11dcd56-0aaa-4253-8565-34132b640f15"),
                IndicatorItemId = indicatorItem2.Id,
                Order = 3,
                ResultString1 = "1"
            };

            var indicatorOutcomeItemLanguage21 = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("541fde0f-502e-4e6f-82f1-aca378d76b60"),
                IndicatorOutcomeItemId = indicatorOutcomeItem21.Id,
                LanguageItemId = language1.Id,
                OutcomeText = "Det er minst 150 cm mellom betalingsterminalene."
            };

            var indicatorOutcomeItemLanguage21Nn = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("e365b040-2025-4ca0-a91b-957857b00717"),
                IndicatorOutcomeItemId = indicatorOutcomeItem21.Id,
                LanguageItemId = language2.Id,
                OutcomeText = "Det er minst 150 cm mellom betalingsterminalane."
            };

            var indicatorOutcomeItemLanguage22 = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("6b3a3de6-d6ff-45a4-8061-6e62d6970747"),
                IndicatorOutcomeItemId = indicatorOutcomeItem22.Id,
                LanguageItemId = language1.Id,
                OutcomeText = "Betalingsterminalene står for tett."
            };

            var indicatorOutcomeItemLanguage22Nn = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("f98ea509-68e5-4a18-92c0-ce0b3ce58073"),
                IndicatorOutcomeItemId = indicatorOutcomeItem22.Id,
                LanguageItemId = language2.Id,
                OutcomeText = "Betalingsterminalane står for tett."
            };

            var indicatorOutcomeItemLanguage23 = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("8bb7a824-82ca-4fbc-bb33-151a38b0a054"),
                IndicatorOutcomeItemId = indicatorOutcomeItem23.Id,
                LanguageItemId = language1.Id,
                OutcomeText = "Betalingsterminalen står ikke på rett linje ved siden av en annen betalingsterminal."
            };

            var indicatorOutcomeItemLanguage23Nn = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("dd35032d-653e-4117-8146-3e19a478f573"),
                IndicatorOutcomeItemId = indicatorOutcomeItem23.Id,
                LanguageItemId = language2.Id,
                OutcomeText = "Betalingsterminalen står ikkje på rett linje ved sida av ein annan betalingsterminal."
            };

            var indicatorOutcomeItem31 = new IndicatorOutcomeItem
            {
                Id = Guid.Parse("e5a123b7-f2d4-4d25-b6d7-544c3b7c63b8"),
                IndicatorItemId = indicatorItem3.Id,
                Order = 1,
                ResultString1 = "1,1,1"
            };

            var indicatorOutcomeItem32 = new IndicatorOutcomeItem
            {
                Id = Guid.Parse("85d5b052-1f22-449d-b0a3-2883593ace54"),
                IndicatorItemId = indicatorItem3.Id,
                Order = 2,
                ResultString1 = "1,1,2"
            };

            var indicatorOutcomeItem33 = new IndicatorOutcomeItem
            {
                Id = Guid.Parse("d0ab6b63-c6c9-4a4f-81b0-5be0a4497278"),
                IndicatorItemId = indicatorItem3.Id,
                Order = 3,
                ResultString1 = "1,2,1"
            };

            var indicatorOutcomeItem34 = new IndicatorOutcomeItem
            {
                Id = Guid.Parse("402f1644-36d0-4ad5-853b-aee2f4bfbf75"),
                IndicatorItemId = indicatorItem3.Id,
                Order = 4,
                ResultString1 = "1,2,2"
            };

            var indicatorOutcomeItem35 = new IndicatorOutcomeItem
            {
                Id = Guid.Parse("54d4cb13-a006-4a8b-9fdb-89a01a9b9040"),
                IndicatorItemId = indicatorItem3.Id,
                Order = 5,
                ResultString1 = "2"
            };

            var indicatorOutcomeItemLanguage31 = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("20308d8f-c099-436a-bf7b-f91a2fac0376"),
                IndicatorOutcomeItemId = indicatorOutcomeItem31.Id,
                LanguageItemId = language1.Id,
                OutcomeText = "Det finnes et skilt som viser hvor kunden skal betale varene sine. Skiltet er synlig på avstand utenfor kundens betjeningsområde og plassert over området der kunden skal betale varene sine."
            };

            var indicatorOutcomeItemLanguage31Nn = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("8361fd23-d73a-489a-89b7-212d87377b5a"),
                IndicatorOutcomeItemId = indicatorOutcomeItem31.Id,
                LanguageItemId = language2.Id,
                OutcomeText = "Det finst eit skilt som viser kvar kunden skal betale varene sine. Skiltet er synleg på avstand utanfor beteningsområde til kunden og plassert over området der kunden skal betale varene sine."
            };

            var indicatorOutcomeItemLanguage32 = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("1b27cdd4-a34b-486c-a5ff-684afa4579e7"),
                IndicatorOutcomeItemId = indicatorOutcomeItem32.Id,
                LanguageItemId = language1.Id,
                OutcomeText = "Skilt til området der kunden skal betale varene sine, er ikke synlig på avstand utenfor kundens betjeningsområde."
            };

            var indicatorOutcomeItemLanguage32Nn = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("6859b4be-dd97-4c59-8c69-618fd03fd528"),
                IndicatorOutcomeItemId = indicatorOutcomeItem32.Id,
                LanguageItemId = language2.Id,
                OutcomeText = "Skilt til området der kunden skal betale varene sine, er ikkje synleg på avstand utanfor beteningsområde til kunden."
            };

            var indicatorOutcomeItemLanguage33 = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("8b2343e2-a121-4247-8b19-318d0d42984c"),
                IndicatorOutcomeItemId = indicatorOutcomeItem33.Id,
                LanguageItemId = language1.Id,
                OutcomeText = "Skilt er ikke plassert over området der kunden skal betale varene sine."
            };

            var indicatorOutcomeItemLanguage33Nn = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("4c1c8046-ad7e-4c0d-920f-a3d52e8fedb6"),
                IndicatorOutcomeItemId = indicatorOutcomeItem33.Id,
                LanguageItemId = language2.Id,
                OutcomeText = "Skilt er ikkje plassert over området der kunden skal betale varene sine."
            };

            var indicatorOutcomeItemLanguage34 = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("2595a239-44fc-4837-9aee-c6dd9f46d71c"),
                IndicatorOutcomeItemId = indicatorOutcomeItem34.Id,
                LanguageItemId = language1.Id,
                OutcomeText = "Skilt til området der kunden skal betale varene sine, er ikke synlig på avstand utenfor kundens betjeningsområde. Skilt er ikke plassert over området der kunden skal betale varene sine."
            };

            var indicatorOutcomeItemLanguage34Nn = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("53328236-d9ed-4194-9520-9278dafe0f01"),
                IndicatorOutcomeItemId = indicatorOutcomeItem34.Id,
                LanguageItemId = language2.Id,
                OutcomeText = "Skilt til området der kunden skal betale varene sine, er ikkje synleg på avstand utanfor beteningsområde til kunden."
            };

            var indicatorOutcomeItemLanguage35 = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("f6d58cdf-cafa-4892-a847-1a70fa2dd4e2"),
                IndicatorOutcomeItemId = indicatorOutcomeItem35.Id,
                LanguageItemId = language1.Id,
                OutcomeText = "Det finnes ikke et skilt som viser hvor kunden skal betale."
            };

            var indicatorOutcomeItemLanguage35Nn = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("77a7707b-293d-41b9-b657-886acfe53275"),
                IndicatorOutcomeItemId = indicatorOutcomeItem35.Id,
                LanguageItemId = language2.Id,
                OutcomeText = "Det finst ikkje eit skilt som viser kvar kunden skal betale."
            };

            var indicatorOutcomeItem41 = new IndicatorOutcomeItem
            {
                Id = Guid.Parse("043ccfc1-ff23-43f3-a130-3d399638f24f"),
                IndicatorItemId = indicatorItem4.Id,
                Order = 1,
                ResultString1 = "1",
                ResultString2 = "1,1"
            };

            var indicatorOutcomeItem42 = new IndicatorOutcomeItem
            {
                Id = Guid.Parse("8d69236d-8940-417e-aab6-d41d74539ef2"),
                IndicatorItemId = indicatorItem4.Id,
                Order = 2,
                ResultString1 = "2,2"
            };

            var indicatorOutcomeItemLanguage41 = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("c80f2711-1229-48d5-a15d-eb790d00f7f2"),
                IndicatorOutcomeItemId = indicatorOutcomeItem41.Id,
                LanguageItemId = language1.Id,
                OutcomeText = "Betalingsterminalen er mellom 75 og 130 cm over gulvet."
            };

            var indicatorOutcomeItemLanguage41Nn = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("a9665f46-40d8-42b9-b2cf-317e929a9122"),
                IndicatorOutcomeItemId = indicatorOutcomeItem41.Id,
                LanguageItemId = language2.Id,
                OutcomeText = "Betalingsterminalen er mellom 75 og 130 cm over golvet."
            };

            var indicatorOutcomeItemLanguage42 = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("840d94f6-0c3c-47d8-bcfd-7d4a148eec06"),
                IndicatorOutcomeItemId = indicatorOutcomeItem42.Id,
                LanguageItemId = language1.Id,
                OutcomeText = "Betalingsterminalen er ikke mellom 75 og 130 cm over gulvet."
            };

            var indicatorOutcomeItemLanguage42Nn = new IndicatorOutcomeItemLanguage
            {
                Id = Guid.Parse("5d415407-52e3-410b-8b88-aa999dae169c"),
                IndicatorOutcomeItemId = indicatorOutcomeItem42.Id,
                LanguageItemId = language2.Id,
                OutcomeText = "Betalingsterminalen er ikkje mellom 75 og 130 cm over golvet."
            };

            modelBuilder.Entity<LanguageItem>().HasData(language1, language2);
            modelBuilder.Entity<TestGroupItem>().HasData(testGroup1, testGroup2, testGroup3);
            modelBuilder.Entity<TestGroupItemLanguage>().HasData(testGroupItemLanguage1, testGroupItemLanguage2, testGroupItemLanguage3, testGroupItemLanguage1Nn, testGroupItemLanguage2Nn, testGroupItemLanguage3Nn);
            modelBuilder.Entity<StandardItem>().HasData(standardItem1);
            modelBuilder.Entity<ChapterItem>().HasData(chapterItem11, chapterItem12, chapterItem21, chapterItem31, chapterItem41);
            modelBuilder.Entity<IndicatorItem>().HasData(indicatorItem1, indicatorItem2, indicatorItem3, indicatorItem4);
            modelBuilder.Entity<IndicatorOutcomeItem>().HasData(indicatorOutcomeItem11, indicatorOutcomeItem12, indicatorOutcomeItem13, indicatorOutcomeItem14, indicatorOutcomeItem15, indicatorOutcomeItem16, indicatorOutcomeItem21, indicatorOutcomeItem22, indicatorOutcomeItem23, indicatorOutcomeItem31, indicatorOutcomeItem32, indicatorOutcomeItem33, indicatorOutcomeItem34, indicatorOutcomeItem35, indicatorOutcomeItem41, indicatorOutcomeItem42);
            modelBuilder.Entity<IndicatorOutcomeItemLanguage>().HasData(indicatorOutcomeItemLanguage11, indicatorOutcomeItemLanguage12, indicatorOutcomeItemLanguage13, indicatorOutcomeItemLanguage14, indicatorOutcomeItemLanguage15, indicatorOutcomeItemLanguage16, indicatorOutcomeItemLanguage21, indicatorOutcomeItemLanguage22, indicatorOutcomeItemLanguage23, indicatorOutcomeItemLanguage31, indicatorOutcomeItemLanguage32, indicatorOutcomeItemLanguage33, indicatorOutcomeItemLanguage34, indicatorOutcomeItemLanguage35, indicatorOutcomeItemLanguage41, indicatorOutcomeItemLanguage42, indicatorOutcomeItemLanguage11Nn, indicatorOutcomeItemLanguage12Nn, indicatorOutcomeItemLanguage13Nn, indicatorOutcomeItemLanguage14Nn, indicatorOutcomeItemLanguage15Nn, indicatorOutcomeItemLanguage16Nn, indicatorOutcomeItemLanguage21Nn, indicatorOutcomeItemLanguage22Nn, indicatorOutcomeItemLanguage23Nn, indicatorOutcomeItemLanguage31Nn, indicatorOutcomeItemLanguage32Nn, indicatorOutcomeItemLanguage33Nn, indicatorOutcomeItemLanguage34Nn, indicatorOutcomeItemLanguage35Nn, indicatorOutcomeItemLanguage41Nn, indicatorOutcomeItemLanguage42Nn);
            modelBuilder.Entity<IndicatorTestGroup>().HasData(indicatorTestGroup1, indicatorTestGroup2, indicatorTestGroup3, indicatorTestGroup4);
            modelBuilder.Entity<RequirementItem>().HasData(requirementItem1, requirementItem2, requirementItem3, requirementItem4);
            modelBuilder.Entity<RequirementItemLanguage>().HasData(requirementItemLanguage1, requirementItemLanguage2, requirementItemLanguage3, requirementItemLanguage4, requirementItemLanguage1Nn, requirementItemLanguage2Nn, requirementItemLanguage3Nn, requirementItemLanguage4Nn);
            modelBuilder.Entity<RuleItem>().HasData(ruleItem11, ruleItem12, ruleItem21, ruleItem31, ruleItem41);
            modelBuilder.Entity<RuleItemLanguage>().HasData(ruleItemLanguage11, ruleItemLanguage12, ruleItemLanguage21, ruleItemLanguage31, ruleItemLanguage41, ruleItemLanguage11Nn, ruleItemLanguage12Nn, ruleItemLanguage21Nn, ruleItemLanguage31Nn, ruleItemLanguage41Nn);
            modelBuilder.Entity<AnswerItem>().HasData(answerItem111, answerItem112, answerItem113, answerItem124, answerItem121, answerItem122, answerItem123, answerItem211, answerItem212, answerItem213, answerItem214, answerItem311, answerItem312, answerItem313, answerItem314, answerItem411, answerItem412, answerItem413);
            modelBuilder.Entity<AnswerItemLanguage>().HasData(answerItemLanguage111, answerItemLanguage112, answerItemLanguage113, answerItemLanguage124, answerItemLanguage121, answerItemLanguage122, answerItemLanguage123, answerItemLanguage211, answerItemLanguage212, answerItemLanguage213, answerItemLanguage214, answerItemLanguage311, answerItemLanguage312, answerItemLanguage313, answerItemLanguage314, answerItemLanguage411, answerItemLanguage412, answerItemLanguage413, answerItemLanguage111Nn, answerItemLanguage112Nn, answerItemLanguage113Nn, answerItemLanguage124Nn, answerItemLanguage121Nn, answerItemLanguage122Nn, answerItemLanguage123Nn, answerItemLanguage211Nn, answerItemLanguage212Nn, answerItemLanguage213Nn, answerItemLanguage214Nn, answerItemLanguage311Nn, answerItemLanguage312Nn, answerItemLanguage313Nn, answerItemLanguage314Nn, answerItemLanguage411Nn, answerItemLanguage412Nn, answerItemLanguage413Nn);

            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}