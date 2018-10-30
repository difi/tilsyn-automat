using Difi.Sjalvdeklaration.Shared.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(bc => new {bc.UserItemId, bc.RoleItemId});

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
                Id = Guid.NewGuid(),
                Name = "Admin"
            };

            var role2 = new RoleItem
            {
                Id = Guid.NewGuid(),
                Name = "Saksbehandlare"
            };

            var role3 = new RoleItem
            {
                Id = Guid.NewGuid(),
                Name = "Verksamhet"
            };

            var user1= new UserItem
            {
                Id = Guid.NewGuid(),
                SocialSecurityNumber = "12089400420",
                IdPortenSub = "fqgADdXVzSgBdjIGl1KloQWjN-qGPN66S1h8EiBtg3g=",
                Name = "Thea",
            };

            var user2 = new UserItem
            {
                Id = Guid.NewGuid(),
                SocialSecurityNumber = "12089400269",
                IdPortenSub = "72og6NuGTB95NqnWN4Mj2IF_pVgodGv_qZ1F8c8u77c=",
                Name = "Martin",
            };

            var user3 = new UserItem
            {
                Id = Guid.NewGuid(),
                SocialSecurityNumber = "12089400188",
                IdPortenSub = "8zrqvL9yMbkJAfU_53_WE1jbTFUehgxmf7MADGcv98g=",
                Name = "",
            };

            var company1 = new CompanyItem
            {
                Id = Guid.NewGuid(),
                Name = "Narvesen",
                CorporateIdentityNumber = "123456789",
                Code = "1111",
            };

            var company2 = new CompanyItem
            {
                Id = Guid.NewGuid(),
                Name = "Norwegian",
                CorporateIdentityNumber = "987654321",
                Code = "2222"
            };

            var company3 = new CompanyItem
            {
                Id = Guid.NewGuid(),
                Name = "NSB",
                CorporateIdentityNumber = "1122334455",
                Code = "3333"
            };

            var company4 = new CompanyItem
            {
                Id = Guid.NewGuid(),
                Name = "Esso",
                CorporateIdentityNumber = "1122334455",
                Code = "4444"
            };

            var company5 = new CompanyItem
            {
                Id = Guid.NewGuid(),
                Name = "7 - eleven",
                CorporateIdentityNumber = "1122334455",
                Code = "5555"
            };

            var company6 = new CompanyItem
            {
                Id = Guid.NewGuid(),
                Name = "Norske bank",
                CorporateIdentityNumber = "1122334455",
                Code = "6666"
            };

            modelBuilder.Entity<UserItem>().HasData(user1, user2, user3);
            modelBuilder.Entity<RoleItem>().HasData(role1, role2, role3);
            modelBuilder.Entity<CompanyItem>().HasData(company1, company2, company3, company4, company5, company6);

            modelBuilder.Entity<ContactPersonItem>().HasData(new ContactPersonItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Henrik Juhlin",
                    Email = "henrik.juhlin@funka.com",
                    Phone = "070-601 75 46",
                    CompanyItemId = company1.Id
                },
                new ContactPersonItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Henrik Juhlin",
                    Email = "henrik.juhlin@funka.com",
                    Phone = "070-601 75 46",
                    CompanyItemId = company2.Id
                },
                new ContactPersonItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Henrik Juhlin",
                    Email = "henrik.juhlin@funka.com",
                    Phone = "070-601 75 46",
                    CompanyItemId = company3.Id
                },
                new ContactPersonItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Henrik Juhlin",
                    Email = "henrik.juhlin@funka.com",
                    Phone = "070-601 75 46",
                    CompanyItemId = company4.Id
                }, new ContactPersonItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Henrik Juhlin",
                    Email = "henrik.juhlin@funka.com",
                    Phone = "070-601 75 46",
                    CompanyItemId = company5.Id
                }
                , new ContactPersonItem
                {
                    Id = Guid.NewGuid(),
                    Name = "Henrik Juhlin",
                    Email = "henrik.juhlin@funka.com",
                    Phone = "070-601 75 46",
                    CompanyItemId = company6.Id
                }
            );

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
                },
                new UserRole
                {
                    UserItemId = user3.Id,
                    RoleItemId = role3.Id
                });

            modelBuilder.Entity<UserCompany>().HasData(
                new UserCompany
                {
                    UserItemId = user3.Id,
                    CompanyItemId = company1.Id
                });

            modelBuilder.Entity<DeclarationItem>().HasData(
                new DeclarationItem
                {
                    Id = Guid.NewGuid(),
                    CompanyItemId = company1.Id,
                    UserItemId = user1.Id,
                    Name = "Automat for betaling på Oslo S",
                    CreatedDate = DateTime.Today.AddDays(-10),
                    Status = DeclarationStatus.Started
                }, new DeclarationItem
                {
                    Id = Guid.NewGuid(),
                    CompanyItemId = company2.Id,
                    UserItemId = user2.Id,
                    Name = "Billettautomat Gardemoen",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    Status = DeclarationStatus.NotStarted
                }, new DeclarationItem
                {
                    Id = Guid.NewGuid(),
                    CompanyItemId = company3.Id,
                    UserItemId = user1.Id,
                    Name = "Billettautomat på Oslo S",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    Status = DeclarationStatus.NotChecked
                }, new DeclarationItem
                {
                    Id = Guid.NewGuid(),
                    CompanyItemId = company4.Id,
                    UserItemId = user2.Id,
                    Name = "Betalingsautomat Trondheim",
                    CreatedDate = DateTime.Today.AddDays(-3),
                    Status = DeclarationStatus.NotChecked
                }, new DeclarationItem
                {
                    Id = Guid.NewGuid(),
                    CompanyItemId = company5.Id,
                    UserItemId = user1.Id,
                    Name = "Automat Grensen",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    Status = DeclarationStatus.MoreInfoNeed
                }, new DeclarationItem
                {
                    Id = Guid.NewGuid(),
                    CompanyItemId = company6.Id,
                    UserItemId = user2.Id,
                    Name = "Billettautomat Kristiansand",
                    CreatedDate = DateTime.Today.AddDays(-3),
                    Status = DeclarationStatus.Done
                });

            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}