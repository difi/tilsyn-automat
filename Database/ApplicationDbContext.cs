using Difi.Sjalvdeklaration.Shared.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules.Standard;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;

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

        public DbSet<LogItem> LogList { get; set; }

        public DbSet<ImageItem> ImageList { get; set; }

        public DbSet<ValueListTypeOfMachine> VlTypeOfMachineList { get; set; }

        public DbSet<ValueListTypeOfTest> VlTypeOfTestList { get; set; }

        public DbSet<ValueListTypeOfSupplierAndVersion> VlTypeOfSupplierAndVersionList { get; set; }

        public DbSet<ValueListFinishedStatus> VlFinishedStatusList { get; set; }

        public DbSet<ValueListUserPrerequisite> VlUserPrerequisiteList { get; set; }

        public DbSet<ValueListTypeOfAnswer> VlTypeOfAnswer { get; set; }

        public DbSet<ValueListTypeOfResult> VlTypeOfResult { get; set; }

        public DbSet<RequirementUserPrerequisite> RequirementUserPrerequisiteList { get; set; }

        public DbSet<RuleItem> RuleList { get; set; }

        public DbSet<AnswerItem> AnswerList { get; set; }

        public DbSet<RequirementItem> RequirementList { get; set; }

        public DbSet<ChapterItem> ChapterList { get; set; }

        public DbSet<StandardItem> StandardList { get; set; }

        public DbSet<TestGroupItem> TestGroupList { get; set; }

        public DbSet<DeclarationTestGroup> DeclarationTestGroupList { get; set; }

        public DbSet<OutcomeData> OutcomeData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(x => new {x.UserItemId, x.RoleItemId});

            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.UserItem)
                .WithMany(x => x.RoleList)
                .HasForeignKey(x => x.UserItemId);

            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.RoleItem)
                .WithMany(x => x.UserList)
                .HasForeignKey(x => x.RoleItemId);

            modelBuilder.Entity<UserCompany>().HasKey(x => new {x.UserItemId, x.CompanyItemId});

            modelBuilder.Entity<UserCompany>()
                .HasOne(x => x.UserItem)
                .WithMany(x => x.CompanyList)
                .HasForeignKey(x => x.UserItemId);

            modelBuilder.Entity<UserCompany>()
                .HasOne(x => x.CompanyItem)
                .WithMany(x => x.UserList)
                .HasForeignKey(x => x.CompanyItemId);

            modelBuilder.Entity<DeclarationTestGroup>().HasKey(x => new { x.TestGroupItemId, x.DeclarationItemId });

            modelBuilder.Entity<DeclarationTestGroup>()
                .HasOne(x => x.DeclarationItem)
                .WithMany(x => x.TestGroupList)
                .HasForeignKey(x => x.DeclarationItemId);

            modelBuilder.Entity<DeclarationTestGroup>()
                .HasOne(x => x.TestGroupItem)
                .WithMany(x => x.DeclarationList)
                .HasForeignKey(x => x.TestGroupItemId);

            modelBuilder.Entity<RequirementUserPrerequisite>().HasKey(x => new {x.RequirementItemId, x.ValueListUserPrerequisiteId});
            modelBuilder.Entity<RequirementItem>().HasMany(x => x.RequirementUserPrerequisiteList);

            modelBuilder.Entity<AnswerData>().HasOne(x => x.AnswerItem).WithMany(x=>x.AnswerDataList).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            modelBuilder.Entity<OutcomeData>().HasOne(x => x.Requirement).WithMany(x => x.OutcomeDataList).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            modelBuilder.Entity<RuleItem>().HasOne(x => x.Chapter).WithMany(x => x.RuleList).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            modelBuilder.Entity<RuleItem>().HasOne(x => x.Standard).WithMany(x => x.RuleList).Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<OutcomeData>().HasMany(x => x.RuleDataList).WithOne(x => x.OutcomeData).Metadata.DeleteBehavior = DeleteBehavior.Cascade;


            var role1 = new RoleItem
            {
                Id = Guid.Parse("e7a78cdc-49f9-4e6c-8abd-afcfc08ca5eb"),
                Name = "Admin",
                IsAdminRole = true
            };

            var role2 = new RoleItem
            {
                Id = Guid.Parse("9e184394-81bb-45cf-a157-dba79a3286d7"),
                Name = "Saksbehandlare",
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
                CountryCode = "0047",
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
                CountryCode = "0047",
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

            var typeOfAnswer1 = new ValueListTypeOfAnswer {Id = 1, Text = "string"};
            var typeOfAnswer2 = new ValueListTypeOfAnswer {Id = 2, Text = "bool"};
            var typeOfAnswer3 = new ValueListTypeOfAnswer {Id = 3, Text = "int"};
            var typeOfAnswer4 = new ValueListTypeOfAnswer {Id = 4, Text = "image"};

            modelBuilder.Entity<ValueListTypeOfAnswer>().HasData(typeOfAnswer1, typeOfAnswer2, typeOfAnswer3, typeOfAnswer4);

            modelBuilder.Entity<ValueListTypeOfResult>().HasData(new List<ValueListTypeOfResult>
            {
                new ValueListTypeOfResult {Id = 1, Text = "Samsvar"},
                new ValueListTypeOfResult {Id = 2, Text = "Brudd"},
                new ValueListTypeOfResult {Id = 3, Text = "Ikke-forekomst"},
                new ValueListTypeOfResult {Id = 4, Text = "Ikke testbar"},
                new ValueListTypeOfResult {Id = 5, Text = "Ikke testa"}
            }.ToArray());

            var testGroup1 = new TestGroupItem
            {
                Id = Guid.Parse("aec1869a-30f8-403c-b909-df115173f009"),
                Name = "Kundens betjeningsområde",
            };

            var testGroup2 = new TestGroupItem
            {
                Id = Guid.Parse("b6c22ac9-d775-4dfd-ac8e-b4ca565ea3fb"),
                Name = "Skilt",
            };

            var testGroup3 = new TestGroupItem
            {
                Id = Guid.Parse("9aae6bc9-4b60-405c-81a7-ec142d8c1ca6"),
                Name = "Betjeningshøyde"
            };

            var requirementItem1 = new RequirementItem
            {
                Order = 1,
                Id = Guid.Parse("875e76b5-c926-43a0-8738-c4f41c7a0b8b"),
                Description = "Krav 3.1 Betjeningsområdet foran betalingsterminalen skal være minst 150 x 150 centimeter. Det skal ikke være hindringer i betjeningsområdet.",
                IndicatorId = 1,
                TestGroupItemId = testGroup1.Id
            };

            var requirementItem2 = new RequirementItem
            {
                Order = 2,
                Id = Guid.Parse("c65786bb-1b93-4153-b88c-935cc2a7ab60"),
                Description = "Krav 3.5 Dersom to eller flere automater står ved siden av hverandre, skal det være minst 150 centimeter fra midten av automaten til midten av neste automat.",
                IndicatorId = 1,
                TestGroupItemId = testGroup1.Id
            };

            var requirementItem3 = new RequirementItem
            {
                Order = 3,
                Id = Guid.Parse("aebd662d-9dd5-4a27-88d5-19d6c5e12e5a"),
                Description = "Krav 1.3 Skilt skal plasseres over betalingsterminalen.",
                IndicatorId = 1,
                TestGroupItemId = testGroup2.Id
            };

            var requirementItem4 = new RequirementItem
            {
                Order = 4,
                Id = Guid.Parse("e503322b-ed77-4b69-adc4-eca19b6eb97d"),
                Description = "Krav 4.2: Høyden på betjeningskomponenter som skjerm og tastatur skal være mellom 75 centimeter og 130 centimeter over gulvet.",
                IndicatorId = 1,
                TestGroupItemId = testGroup3.Id
            };

            var standardItem1 = new StandardItem
            {
                Id = Guid.Parse("7851b33f-4cec-405c-8533-53cf7a6832e2"),
                Standard = "CEN/TS"
            };

            var chapterItem1 = new ChapterItem
            {
                Id = Guid.Parse("75468cd0-478b-45e9-8a8e-51b0e574fb3b"),
                RequirementsInSupervisor = "Krav 1.3 Skilt skal plasseres over betalingsterminalen.",
                ChapterHeading = "Location signs and visual indications ",
                ChapterNumber = "15291:2006 5.2",
                StandardItemId = standardItem1.Id
            };

            var ruleItem1 = new RuleItem
            {
                Order = 1,
                RequirementItemId = requirementItem4.Id,
                Id = Guid.Parse("832e0843-cab3-4dbc-9799-974e283fcc0b"),
                Instruction = "Finnes det et skilt som viser hvor kunden skal betale varene sine?",
                HelpText = "Krav: Skilt skal plasseres over betalingsterminalen.<br /><br />Det skal være et skilt som er synlig på avstand utenfor kundens betjeningsområde. Formålet er at brukeren kan finne fram til betalingsterminalen.<br /><br />Skiltet skal være plassert over området der kunden skal betale varene sine. Det kan for eksempel være over kassen eller disken der betalingsterminalen er plassert.<br /><br />Eksempler på tekst på skilt er<br />- Kasse<br />- Betal her<br />- Kort og kontant<br />- Nummer på kasse<br />",
                ToolsNeed = "Ingen",
                ChapterItemId = chapterItem1.Id,
                StandardItemId = standardItem1.Id,
            };

            var ruleItem2 = new RuleItem
            {
                Order = 2,
                RequirementItemId = requirementItem4.Id,
                Id = Guid.Parse("4c4cd93b-ad4c-49b3-af05-f9e9fc7cb15a"),
                Instruction = "Er skiltet plassert over området der kunden skal betale varene sine?",
                ToolsNeed = "Ingen",
                ChapterItemId = chapterItem1.Id,
                StandardItemId = standardItem1.Id,
            };

            var ruleItem3 = new RuleItem
            {
                Order = 3,
                RequirementItemId = requirementItem4.Id,
                Id = Guid.Parse("5cec30b8-2c28-4f7e-b9d7-6655a745c2ef"),
                Instruction = "Er skiltet synlig på avstand utenfor kundens betjeningsområde?",
                ToolsNeed = "Ingen",
                ChapterItemId = chapterItem1.Id,
                StandardItemId = standardItem1.Id,
            };

            var answerItem1 = new AnswerItem
            {
                Order = 1,
                Id = Guid.Parse("d8611e84-0f00-4d75-bcab-cbf127fb68b5"),
                TypeOfAnswerId = typeOfAnswer2.Id,
                Bool =  true,
                RuleItemId = ruleItem1.Id,
            };

            var answerItem2 = new AnswerItem
            {
                Order = 2,
                Id = Guid.Parse("c4870935-ee11-4557-a9c3-aca678c17565"),
                TypeOfAnswerId = typeOfAnswer4.Id,
                Bool = true,
                RuleItemId = ruleItem1.Id,
            };

            var answerItem3 = new AnswerItem
            {
                Order = 1,
                Id = Guid.Parse("9a51cc68-857e-4822-ac81-0ec3ebe7bf43"),
                TypeOfAnswerId = typeOfAnswer2.Id,
                Bool = true,
                RuleItemId = ruleItem2.Id,
            };

            var answerItem4 = new AnswerItem
            {
                Order = 1,
                Id = Guid.Parse("f69c1e45-99d8-4293-a242-c5ed9e126e99"),
                TypeOfAnswerId = typeOfAnswer2.Id,
                Bool = true,
                RuleItemId = ruleItem3.Id,
            };

            modelBuilder.Entity<TestGroupItem>().HasData(testGroup1, testGroup2, testGroup3);
            modelBuilder.Entity<StandardItem>().HasData(standardItem1);
            modelBuilder.Entity<ChapterItem>().HasData(chapterItem1);
            modelBuilder.Entity<RequirementItem>().HasData(requirementItem1, requirementItem2, requirementItem3, requirementItem4);
            modelBuilder.Entity<RuleItem>().HasData(ruleItem1, ruleItem2, ruleItem3);
            modelBuilder.Entity<AnswerItem>().HasData(answerItem1, answerItem2, answerItem3, answerItem4);

            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}