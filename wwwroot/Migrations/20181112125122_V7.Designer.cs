﻿// <auto-generated />
using System;
using Difi.Sjalvdeklaration.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181112125122_V7")]
    partial class V7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Company.CompanyItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressCity");

                    b.Property<string>("AddressStreet");

                    b.Property<string>("AddressZip");

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("CorporateIdentityNumber")
                        .IsRequired();

                    b.Property<string>("CustomName");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("CompanyList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Company.ContactPersonItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanyItemId");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("PhoneCountryCode");

                    b.HasKey("Id");

                    b.HasIndex("CompanyItemId");

                    b.ToTable("ContactPersonList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.DeclarationItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanyItemId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("DeadlineDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("SentInDate");

                    b.Property<int>("Status");

                    b.Property<Guid>("UserItemId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyItemId");

                    b.HasIndex("UserItemId");

                    b.ToTable("DeclarationList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.DeclarationTestItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CaseNumber");

                    b.Property<Guid>("DeclarationItemId");

                    b.Property<string>("DescriptionInText");

                    b.Property<int?>("FinishedStatusId");

                    b.Property<Guid?>("Image1Id");

                    b.Property<Guid?>("Image2Id");

                    b.Property<int?>("SupplierAndVersionId");

                    b.Property<string>("SupplierAndVersionOther");

                    b.Property<int?>("TypeOfMachineId");

                    b.Property<int?>("TypeOfTestId");

                    b.HasKey("Id");

                    b.HasIndex("DeclarationItemId")
                        .IsUnique();

                    b.HasIndex("FinishedStatusId");

                    b.HasIndex("Image1Id");

                    b.HasIndex("Image2Id");

                    b.HasIndex("SupplierAndVersionId");

                    b.HasIndex("TypeOfMachineId");

                    b.HasIndex("TypeOfTestId");

                    b.ToTable("DeclarationTestItem");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.OutcomeItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("DeclarationItemId");

                    b.Property<Guid?>("DeclarationTestItemId");

                    b.Property<string>("Description");

                    b.Property<int>("IndicatorId");

                    b.Property<Guid?>("RequirementId");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("DeclarationTestItemId");

                    b.HasIndex("RequirementId");

                    b.ToTable("OutcomeItem");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.RequirementItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ChapterHeading");

                    b.Property<string>("ChapterNumber");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Standard");

                    b.HasKey("Id");

                    b.ToTable("RequirementItem");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.RequirementUserPrerequisite", b =>
                {
                    b.Property<Guid>("RequirementItemId");

                    b.Property<int>("ValueListUserPrerequisiteId");

                    b.HasKey("RequirementItemId", "ValueListUserPrerequisiteId");

                    b.HasIndex("ValueListUserPrerequisiteId");

                    b.ToTable("RequirementUserPrerequisite");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Path");

                    b.HasKey("Id");

                    b.ToTable("ImageList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.LogItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CallParameter1");

                    b.Property<string>("CallParameter2");

                    b.Property<string>("Class");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Function");

                    b.Property<string>("ResultException");

                    b.Property<Guid>("ResultId");

                    b.Property<string>("ResultString");

                    b.Property<bool>("ResultSucceeded");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("LogList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.User.RoleItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsAdminRole");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("RoleList");

                    b.HasData(
                        new { Id = new Guid("bdb5182d-8d56-4034-bfb3-36888e719ebe"), IsAdminRole = true, Name = "Admin" },
                        new { Id = new Guid("ceb3e909-2d86-42de-951f-7646949718c1"), IsAdminRole = true, Name = "Saksbehandlare" },
                        new { Id = new Guid("799cb2c6-ef81-4d43-aee5-c28fb405bcd6"), IsAdminRole = false, Name = "Virksomhet" }
                    );
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.User.UserCompany", b =>
                {
                    b.Property<Guid>("UserItemId");

                    b.Property<Guid>("CompanyItemId");

                    b.HasKey("UserItemId", "CompanyItemId");

                    b.HasIndex("CompanyItemId");

                    b.ToTable("UserCompanyList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.User.UserItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CountryCode");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email");

                    b.Property<DateTime>("LastOnline");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<string>("SocialSecurityNumber")
                        .IsRequired();

                    b.Property<string>("Title");

                    b.Property<string>("Token");

                    b.HasKey("Id");

                    b.ToTable("UserList");

                    b.HasData(
                        new { Id = new Guid("1b21a2a1-36f5-47a3-a27b-49e241faafbe"), CountryCode = "0047", Created = new DateTime(2011, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), Email = "martin@difi.no", LastOnline = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Martin Swartling", Phone = "912345678", SocialSecurityNumber = "12089400420", Title = "Avdelingssjef", Token = "fqgADdXVzSgBdjIGl1KloQWjN-qGPN66S1h8EiBtg3g=" },
                        new { Id = new Guid("04be8925-63ae-4253-8930-828e624cbea1"), CountryCode = "0047", Created = new DateTime(2011, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), Email = "thea@difi.no", LastOnline = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Thea Sneve", Phone = "712345678", SocialSecurityNumber = "12089400269", Title = "Handläggare", Token = "72og6NuGTB95NqnWN4Mj2IF_pVgodGv_qZ1F8c8u77c=" }
                    );
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.User.UserRole", b =>
                {
                    b.Property<Guid>("UserItemId");

                    b.Property<Guid>("RoleItemId");

                    b.HasKey("UserItemId", "RoleItemId");

                    b.HasIndex("RoleItemId");

                    b.ToTable("UserRoleList");

                    b.HasData(
                        new { UserItemId = new Guid("1b21a2a1-36f5-47a3-a27b-49e241faafbe"), RoleItemId = new Guid("bdb5182d-8d56-4034-bfb3-36888e719ebe") },
                        new { UserItemId = new Guid("1b21a2a1-36f5-47a3-a27b-49e241faafbe"), RoleItemId = new Guid("ceb3e909-2d86-42de-951f-7646949718c1") },
                        new { UserItemId = new Guid("04be8925-63ae-4253-8930-828e624cbea1"), RoleItemId = new Guid("ceb3e909-2d86-42de-951f-7646949718c1") }
                    );
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListFinishedStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("VlFinishedStatusList");

                    b.HasData(
                        new { Id = 1, Text = "Inget" },
                        new { Id = 2, Text = "Avvik" },
                        new { Id = 3, Text = "Merknad" }
                    );
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListTypeOfMachine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("VlTypeOfMachineList");

                    b.HasData(
                        new { Id = 1, Text = "Betalingsterminal" },
                        new { Id = 2, Text = "Billettautomat" },
                        new { Id = 3, Text = "Selvbetjent kasse" },
                        new { Id = 4, Text = "Minibank" },
                        new { Id = 5, Text = "Vareautomat" }
                    );
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListTypeOfSupplierAndVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("VlTypeOfSupplierAndVersionList");

                    b.HasData(
                        new { Id = 1, Text = "Vet ikke" },
                        new { Id = 2, Text = "Ingenico iCT250" },
                        new { Id = 3, Text = "Ingenico iCT250E" },
                        new { Id = 4, Text = "Ingenico iCT250r" },
                        new { Id = 5, Text = "Ingenico iPP350" },
                        new { Id = 6, Text = "Ingenico iSelf" },
                        new { Id = 7, Text = "Ingenico iSMP" },
                        new { Id = 8, Text = "Ingenico isMP4" },
                        new { Id = 9, Text = "Ingenico iUP" },
                        new { Id = 10, Text = "Ingenico iWL250" },
                        new { Id = 11, Text = "Ingenico iWL250B " },
                        new { Id = 12, Text = "Ingenico iWL250G" },
                        new { Id = 13, Text = "Ingenico iWL251" },
                        new { Id = 14, Text = "Ingenico iWL252" },
                        new { Id = 15, Text = "iZettle Reader" },
                        new { Id = 16, Text = "SumUp Air" },
                        new { Id = 17, Text = "Verifone VX 520 C" },
                        new { Id = 18, Text = "Verifone VX 680" },
                        new { Id = 19, Text = "Verifone VX 690" },
                        new { Id = 20, Text = "Verifone VX 820" },
                        new { Id = 21, Text = "Verifone VX 820 Duet" },
                        new { Id = 22, Text = "Verifone Xenteo ECO" },
                        new { Id = 23, Text = "Verifone Yomani XR" }
                    );
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListTypeOfTest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("VlTypeOfTestList");

                    b.HasData(
                        new { Id = 1, Text = "Automat" },
                        new { Id = 2, Text = "Webside" },
                        new { Id = 3, Text = "Applikasjon" }
                    );
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListUserPrerequisite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("VlUserPrerequisiteList");

                    b.HasData(
                        new { Id = 1, Text = "Blinde" },
                        new { Id = 2, Text = "Svaksynte" },
                        new { Id = 3, Text = "Fargeblinde" },
                        new { Id = 4, Text = "Døvblinde" },
                        new { Id = 5, Text = "Døve" },
                        new { Id = 6, Text = "Nedsett høyrsel/tunghøyrde" },
                        new { Id = 7, Text = "Nedsett kognisjon" },
                        new { Id = 8, Text = "Nedsett motorikk" },
                        new { Id = 9, Text = "Fotosensitivitet/anfall" },
                        new { Id = 10, Text = "Fysisk størrelse" },
                        new { Id = 11, Text = "Redusert taktil sensibilitet" }
                    );
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Company.ContactPersonItem", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Company.CompanyItem")
                        .WithMany("ContactPersonList")
                        .HasForeignKey("CompanyItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.DeclarationItem", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Company.CompanyItem", "Company")
                        .WithMany("DeclarationList")
                        .HasForeignKey("CompanyItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.User.UserItem", "User")
                        .WithMany()
                        .HasForeignKey("UserItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.DeclarationTestItem", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.DeclarationItem", "DeclarationItem")
                        .WithOne("DeclarationTestItem")
                        .HasForeignKey("Difi.Sjalvdeklaration.Shared.Classes.Declaration.DeclarationTestItem", "DeclarationItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListFinishedStatus", "FinishedStatus")
                        .WithMany()
                        .HasForeignKey("FinishedStatusId");

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Image", "Image1")
                        .WithMany()
                        .HasForeignKey("Image1Id");

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Image", "Image2")
                        .WithMany()
                        .HasForeignKey("Image2Id");

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListTypeOfSupplierAndVersion", "SupplierAndVersion")
                        .WithMany()
                        .HasForeignKey("SupplierAndVersionId");

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListTypeOfMachine", "TypeOfMachine")
                        .WithMany()
                        .HasForeignKey("TypeOfMachineId");

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListTypeOfTest", "TypeOfTest")
                        .WithMany()
                        .HasForeignKey("TypeOfTestId");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.OutcomeItem", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.DeclarationTestItem")
                        .WithMany("OutcomeList")
                        .HasForeignKey("DeclarationTestItemId");

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.RequirementItem", "Requirement")
                        .WithMany()
                        .HasForeignKey("RequirementId");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.Declaration.RequirementUserPrerequisite", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Declaration.RequirementItem", "RequirementItem")
                        .WithMany("RequirementUserPrerequisiteList")
                        .HasForeignKey("RequirementItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.ValueList.ValueListUserPrerequisite", "ValueListUserPrerequisite")
                        .WithMany()
                        .HasForeignKey("ValueListUserPrerequisiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.User.UserCompany", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.Company.CompanyItem", "CompanyItem")
                        .WithMany("UserList")
                        .HasForeignKey("CompanyItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.User.UserItem", "UserItem")
                        .WithMany("CompanyList")
                        .HasForeignKey("UserItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.User.UserRole", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.User.RoleItem", "RoleItem")
                        .WithMany("UserList")
                        .HasForeignKey("RoleItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.User.UserItem", "UserItem")
                        .WithMany("RoleList")
                        .HasForeignKey("UserItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
