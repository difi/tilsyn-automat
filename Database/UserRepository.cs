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

        public IEnumerable<UserItem> GetAll()
        {
            return dbContext.UserList.Include(x => x.RoleList).ThenInclude(x => x.RoleItem).AsNoTracking().ToList();
        }

        public UserItem Get(Guid id)
        {
            var item = dbContext.UserList.Include(x => x.RoleList).ThenInclude(x => x.RoleItem).Include(x => x.CompanyList).ThenInclude(x => x.CompanyItem).ThenInclude(x => x.ContactPersonList).SingleOrDefault(x => x.Id == id);

            return item;
        }

        public UserItem GetByToken(string token)
        {
            var item = dbContext.UserList.Include(x => x.RoleList).ThenInclude(x => x.RoleItem).Include(x => x.CompanyList).ThenInclude(x => x.CompanyItem).ThenInclude(x => x.ContactPersonList).SingleOrDefault(x => x.IdPortenSub == token);

            return item;
        }

        public async Task<UserItem> Login(string idPortenSub, string socialSecurityNumber)
        {
            var idPortenSubItem = dbContext.UserList.Include(x => x.RoleList).ThenInclude(x => x.RoleItem).Include(x => x.CompanyList).ThenInclude(x => x.CompanyItem).ThenInclude(x => x.ContactPersonList).SingleOrDefault(x => x.IdPortenSub == idPortenSub);
            if (idPortenSubItem != null)
            {
                return idPortenSubItem;
            }

            var socialSecurityNumberItem = dbContext.UserList.Include(x => x.RoleList).ThenInclude(x => x.RoleItem).Include(x => x.CompanyList).ThenInclude(x => x.CompanyItem).ThenInclude(x => x.ContactPersonList).SingleOrDefault(x => x.SocialSecurityNumber == socialSecurityNumber);
            if (socialSecurityNumberItem != null)
            {
                socialSecurityNumberItem.IdPortenSub = idPortenSub;
                await dbContext.SaveChangesAsync();

                return socialSecurityNumberItem;
            }

            var newUserItem = new UserItem
            {
                IdPortenSub = idPortenSub,
                SocialSecurityNumber = socialSecurityNumber,
                Id = Guid.NewGuid(),
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
                    userItemInDb.IdPortenSub = userItem.IdPortenSub;
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
                var userItemDb = Get(userItem.Id);

                userItemDb.Name = userItem.Name;
                userItemDb.SocialSecurityNumber = userItem.SocialSecurityNumber;
                userItemDb.Email = userItem.Email;
                userItemDb.Phone = userItem.Phone;
                userItemDb.Title = userItem.Title;

                dbContext.UserRoleList.RemoveRange(dbContext.UserRoleList.Where(x => x.UserItemId == userItemDb.Id));

                if (roleList != null && roleList.Any())
                {
                    foreach (var roleItem in roleList)
                    {
                        dbContext.UserRoleList.Add(new UserRole { RoleItemId = roleItem.Id, UserItemId = userItem.Id });
                    }
                }

                dbContext.UserList.Update(userItemDb);
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