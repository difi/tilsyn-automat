using Difi.Sjalvdeklaration.Shared.Classes;
using Microsoft.EntityFrameworkCore;
using System;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                PhoneCountryCode = "0047",
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

            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}