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
                Id = Guid.NewGuid(),
                Name = "Admin",
                IsAdminRole = true
            };

            var role2 = new RoleItem
            {
                Id = Guid.NewGuid(),
                Name = "Saksbehandlare",
                IsAdminRole = true
            };

            var role3 = new RoleItem
            {
                Id = Guid.NewGuid(),
                Name = "Verksamhet"
            };

            var user1 = new UserItem
            {
                Id = Guid.NewGuid(),
                SocialSecurityNumber = "12089400420",
                IdPortenSub = "fqgADdXVzSgBdjIGl1KloQWjN-qGPN66S1h8EiBtg3g=",
                Name = "Martin Swartling",
                Email = "martin@difi.no",
                Phone = "912345678",
                Title = "Avdelingssjef",
                Created = DateTime.Now
            };

            var user2 = new UserItem
            {
                Id = Guid.NewGuid(),
                SocialSecurityNumber = "12089400269",
                IdPortenSub = "72og6NuGTB95NqnWN4Mj2IF_pVgodGv_qZ1F8c8u77c=",
                Name = "Thea Sneve",
                Email = "thea@difi.no",
                Phone = "712345678",
                Title = "Handläggare",
                Created = DateTime.Now
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