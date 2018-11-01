using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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

        public UserItem GetByIdPortenSub(string idPortenSub)
        {
            var item = dbContext.UserList.Include(x => x.RoleList).ThenInclude(x => x.RoleItem).Include(x => x.CompanyList).ThenInclude(x => x.CompanyItem).ThenInclude(x => x.ContactPersonList).SingleOrDefault(x => x.IdPortenSub == idPortenSub);

            return item;
        }

        public bool Add(UserItem userItem)
        {
            if (GetByIdPortenSub(userItem.IdPortenSub) != null)
            {
                return false;
            }

            try
            {
                dbContext.UserList.Add(userItem);
                dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddLink(UserCompany userCompanyItem)
        {
            try
            {
                dbContext.UserCompanyList.Add(userCompanyItem);
                dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}