using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.Database
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<UserItem> GetAllInternal()
        {
            return dbContext.UserList.Include(x => x.RoleList).ThenInclude(x => x.RoleItem).AsNoTracking().Where(rl => rl.RoleList.Any(r => r.RoleItem.IsAdminRole)).ToList();
        }

        public UserItem Get(Guid id)
        {
            var item = dbContext.UserList.Include(x => x.RoleList).ThenInclude(x => x.RoleItem).Include(x => x.CompanyList).ThenInclude(x => x.CompanyItem).ThenInclude(x => x.ContactPersonList).SingleOrDefault(x => x.Id == id);

            return item;
        }

        public UserItem GetByToken(string token)
        {
            var item = dbContext.UserList.Include(x => x.RoleList).ThenInclude(x => x.RoleItem).Include(x => x.CompanyList).ThenInclude(x => x.CompanyItem).ThenInclude(x => x.ContactPersonList).SingleOrDefault(x => x.Token == token);

            return item;
        }

        public async Task<bool> Remove(Guid id)
        {
            try
            {
                var dbItem = dbContext.UserList.SingleOrDefault(x => x.Id == id);

                if (dbItem == null)
                {
                    throw new InvalidOperationException();
                }

                dbContext.UserList.Remove(dbItem);

                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<UserItem> Login(string token, string socialSecurityNumber)
        {
            var tokenItem = dbContext.UserList.Include(x => x.RoleList).ThenInclude(x => x.RoleItem).Include(x => x.CompanyList).ThenInclude(x => x.CompanyItem).ThenInclude(x => x.ContactPersonList).SingleOrDefault(x => x.Token == token);
            if (tokenItem != null)
            {
                tokenItem.LastOnline = DateTime.Now;
                await dbContext.SaveChangesAsync();

                return tokenItem;
            }

            var socialSecurityNumberItem = dbContext.UserList.Include(x => x.RoleList).ThenInclude(x => x.RoleItem).Include(x => x.CompanyList).ThenInclude(x => x.CompanyItem).ThenInclude(x => x.ContactPersonList).SingleOrDefault(x => x.SocialSecurityNumber == socialSecurityNumber);
            if (socialSecurityNumberItem != null)
            {
                socialSecurityNumberItem.Token = token;
                socialSecurityNumberItem.LastOnline = DateTime.Now;
                await dbContext.SaveChangesAsync();

                return socialSecurityNumberItem;
            }

            var newUserItem = new UserItem
            {
                Token = token,
                SocialSecurityNumber = socialSecurityNumber,
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                LastOnline = DateTime.Now,
                
                Name = "Virksomhet",
            };

            var role = dbContext.RoleList.Single(x => x.Name == "Virksomhet");

            if (await Add(newUserItem, new List<RoleItem> {role}))
            {
                return Get(newUserItem.Id);
            }

            return null;
        }


        public async Task<bool> Add(UserItem userItem, List<RoleItem> roleList)
        {
            try
            {
                var userItemInDb = dbContext.UserList.SingleOrDefault(x => x.SocialSecurityNumber == userItem.SocialSecurityNumber);

                if (userItemInDb != null)
                {
                    userItemInDb.Token = userItem.Token;
                    await dbContext.SaveChangesAsync();

                    return true;
                }

                userItem.Id = Guid.NewGuid();
                userItem.Created = DateTime.Now;

                if (roleList != null && roleList.Any())
                {
                    foreach (var roleItem in roleList)
                    {
                        dbContext.UserRoleList.Add(new UserRole { RoleItemId = roleItem.Id, UserItemId = userItem.Id });
                    }
                }

                dbContext.UserList.Add(userItem);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(UserItem userItem, List<RoleItem> roleList)
        {
            try
            {
                var dbItem = Get(userItem.Id);

                dbItem.Name = userItem.Name;
                dbItem.SocialSecurityNumber = userItem.SocialSecurityNumber;
                dbItem.Email = userItem.Email;
                dbItem.Phone = userItem.Phone;
                dbItem.Title = userItem.Title;

                dbContext.UserRoleList.RemoveRange(dbContext.UserRoleList.Where(x => x.UserItemId == dbItem.Id));

                if (roleList != null && roleList.Any())
                {
                    foreach (var roleItem in roleList)
                    {
                        dbContext.UserRoleList.Add(new UserRole { RoleItemId = roleItem.Id, UserItemId = userItem.Id });
                    }
                }

                dbContext.UserList.Update(dbItem);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}