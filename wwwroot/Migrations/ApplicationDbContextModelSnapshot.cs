﻿// <auto-generated />
using System;
using Difi.Sjalvdeklaration.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Difi.Sjalvdeklaration.wwwroot.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.CompanyItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("CorporateIdentityNumber");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("CompanyList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.ContactPersonItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanyItemId");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.HasIndex("CompanyItemId");

                    b.ToTable("ContactPersonList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.DeclarationItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanyItemId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("DeadLineDate");

                    b.Property<string>("Name");

                    b.Property<DateTime>("SentInDate");

                    b.Property<int>("Status");

                    b.Property<Guid>("UserItemId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyItemId");

                    b.HasIndex("UserItemId");

                    b.ToTable("DeclarationList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.RoleItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsAdminRole");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("RoleList");

                    b.HasData(
                        new { Id = new Guid("86256d80-3c70-4143-a4aa-0662a0c7d247"), IsAdminRole = true, Name = "Admin" },
                        new { Id = new Guid("b12ddbf6-1e3d-4a11-9880-fe4ff5b14c01"), IsAdminRole = true, Name = "Saksbehandlare" },
                        new { Id = new Guid("8f53bf26-92ca-405b-af3e-22fe6cc07dad"), IsAdminRole = false, Name = "Virksomhet" }
                    );
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.UserCompany", b =>
                {
                    b.Property<Guid>("UserItemId");

                    b.Property<Guid>("CompanyItemId");

                    b.HasKey("UserItemId", "CompanyItemId");

                    b.HasIndex("CompanyItemId");

                    b.ToTable("UserCompanyList");
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.UserItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

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
                        new { Id = new Guid("9604fda2-43ed-41f2-af64-bbcc81afb4f9"), Created = new DateTime(2018, 11, 5, 11, 28, 11, 806, DateTimeKind.Local), Email = "martin@difi.no", LastOnline = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Martin Swartling", Phone = "912345678", SocialSecurityNumber = "12089400420", Title = "Avdelingssjef", Token = "fqgADdXVzSgBdjIGl1KloQWjN-qGPN66S1h8EiBtg3g=" },
                        new { Id = new Guid("4658d37d-b3d8-47e3-a0fb-e18a4c73734b"), Created = new DateTime(2018, 11, 5, 11, 28, 11, 808, DateTimeKind.Local), Email = "thea@difi.no", LastOnline = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Name = "Thea Sneve", Phone = "712345678", SocialSecurityNumber = "12089400269", Title = "Handläggare", Token = "72og6NuGTB95NqnWN4Mj2IF_pVgodGv_qZ1F8c8u77c=" }
                    );
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.UserRole", b =>
                {
                    b.Property<Guid>("UserItemId");

                    b.Property<Guid>("RoleItemId");

                    b.HasKey("UserItemId", "RoleItemId");

                    b.HasIndex("RoleItemId");

                    b.ToTable("UserRoleList");

                    b.HasData(
                        new { UserItemId = new Guid("9604fda2-43ed-41f2-af64-bbcc81afb4f9"), RoleItemId = new Guid("86256d80-3c70-4143-a4aa-0662a0c7d247") },
                        new { UserItemId = new Guid("9604fda2-43ed-41f2-af64-bbcc81afb4f9"), RoleItemId = new Guid("b12ddbf6-1e3d-4a11-9880-fe4ff5b14c01") },
                        new { UserItemId = new Guid("4658d37d-b3d8-47e3-a0fb-e18a4c73734b"), RoleItemId = new Guid("b12ddbf6-1e3d-4a11-9880-fe4ff5b14c01") }
                    );
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.ContactPersonItem", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.CompanyItem")
                        .WithMany("ContactPersonList")
                        .HasForeignKey("CompanyItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.DeclarationItem", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.CompanyItem", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.UserItem", "User")
                        .WithMany()
                        .HasForeignKey("UserItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.UserCompany", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.CompanyItem", "CompanyItem")
                        .WithMany("UserList")
                        .HasForeignKey("CompanyItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.UserItem", "UserItem")
                        .WithMany("CompanyList")
                        .HasForeignKey("UserItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Difi.Sjalvdeklaration.Shared.Classes.UserRole", b =>
                {
                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.RoleItem", "RoleItem")
                        .WithMany("UserList")
                        .HasForeignKey("RoleItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Difi.Sjalvdeklaration.Shared.Classes.UserItem", "UserItem")
                        .WithMany("RoleList")
                        .HasForeignKey("UserItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
