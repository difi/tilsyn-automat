using Difi.Sjalvdeklaration.Shared.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
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

        public DbSet<ValueListTypeOfMachine> TypeOfMachineList { get; set; }

        public DbSet<ValueListTypeOfTest> TypeOfTestList { get; set; }

        public DbSet<ValueListTypeOfSupplierAndVersion> TypeOfSupplierAndVersionList { get; set; }

        public DbSet<ValueListFinishedStatus> FinishedStatusList { get; set; }

        public DbSet<Image> ImageList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<DeclarationItem>().HasOne(x => x.DeclarationTestItem).WithOne(x => x.DeclarationItem).HasForeignKey<DeclarationTestItem>(x => x.Id);

            modelBuilder.Entity<UserRole>().HasKey(bc => new { bc.UserItemId, bc.RoleItemId });

            modelBuilder.Entity<UserRole>()
                .HasOne(bc => bc.UserItem)
                .WithMany(b => b.RoleList)
                .HasForeignKey(bc => bc.UserItemId);

            modelBuilder.Entity<UserRole>()
                .HasOne(bc => bc.RoleItem)
                .WithMany(c => c.UserList)
                .HasForeignKey(bc => bc.RoleItemId);

            modelBuilder.Entity<UserCompany>().HasKey(bc => new { bc.UserItemId, bc.CompanyItemId });

            modelBuilder.Entity<UserCompany>()
                .HasOne(bc => bc.UserItem)
                .WithMany(b => b.CompanyList)
                .HasForeignKey(bc => bc.UserItemId);

            modelBuilder.Entity<UserCompany>()
                .HasOne(bc => bc.CompanyItem)
                .WithMany(c => c.UserList)
                .HasForeignKey(bc => bc.CompanyItemId);

            var role1 = new RoleItem
            {
                Id = Guid.Parse("BDB5182D-8D56-4034-BFB3-36888E719EBE"),
                Name = "Admin",
                IsAdminRole = true
            };

            var role2 = new RoleItem
            {
                Id = Guid.Parse("CEB3E909-2D86-42DE-951F-7646949718C1"),
                Name = "Saksbehandlare",
                IsAdminRole = true
            };

            var role3 = new RoleItem
            {
                Id = Guid.Parse("799CB2C6-EF81-4D43-AEE5-C28FB405BCD6"),
                Name = "Virksomhet"
            };

            var user1 = new UserItem
            {
                Id = Guid.Parse("1B21A2A1-36F5-47A3-A27B-49E241FAAFBE"),
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
                Id = Guid.Parse("04BE8925-63AE-4253-8930-828E624CBEA1"),
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

            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}