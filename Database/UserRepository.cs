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

        public UserItem GetByIdPortenSub(string idPortenSub)
        {
            if (String.IsNullOrEmpty(idPortenSub))
            {
                return null;
            }

            var item = dbContext.UserList.Include(x => x.RoleList).ThenInclude(x => x.RoleItem).Include(x => x.CompanyList).ThenInclude(x => x.CompanyItem).ThenInclude(x => x.ContactPersonList).SingleOrDefault(x => x.IdPortenSub == idPortenSub);

            return item;
        }

        public async Task<bool> Add(UserItem userItem, List<RoleItem> roleList)
        {
            if (GetByIdPortenSub(userItem.IdPortenSub) != null)
            {
                return false;
            }

            try
            {
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

        public async Task<bool> AddLink(UserCompany userCompanyItem)
        {
            try
            {
                dbContext.UserCompanyList.Add(userCompanyItem);
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