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

        public ApiResult<T> Get<T>(Guid id) where T : UserItem
        {
            var result = new ApiResult<T>();

            try
            {
                var item = dbContext.UserList.Include(x => x.RoleList).ThenInclude(x => x.RoleItem).Include(x => x.CompanyList).ThenInclude(x => x.CompanyItem).ThenInclude(x => x.ContactPersonList).SingleOrDefault(x => x.Id == id);

                if (item != null)
                {
                    result.Data = (T)item;
                    result.Succeeded = true;
                }
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public ApiResult<T> GetByToken<T>(string token) where T : UserItem
        {
            var result = new ApiResult<T>();

            try
            {
                var item = dbContext.UserList.Include(x => x.RoleList).ThenInclude(x => x.RoleItem).Include(x => x.CompanyList).ThenInclude(x => x.CompanyItem).ThenInclude(x => x.ContactPersonList).SingleOrDefault(x => x.Token == token);

                if (item != null)
                {
                    result.Data = (T)item;
                    result.Succeeded = true;
                }
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public ApiResult<T> GetAllInternal<T>() where T : IEnumerable<UserItem>
        {
            var result = new ApiResult<T>();

            try
            {
                var list = dbContext.UserList.Include(x => x.RoleList).ThenInclude(x => x.RoleItem).AsNoTracking().Where(rl => rl.RoleList.Any(r => r.RoleItem.IsAdminRole)).OrderBy(x => x.Name);

                result.Data = (T)list;
                result.Succeeded = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public async Task<ApiResult<T>> Login<T>(string token, string socialSecurityNumber) where T : UserItem
        {
            var result = new ApiResult<T>();

            try
            {
                var tokenItem = dbContext.UserList.Include(x => x.RoleList).ThenInclude(x => x.RoleItem).Include(x => x.CompanyList).ThenInclude(x => x.CompanyItem).ThenInclude(x => x.ContactPersonList).SingleOrDefault(x => x.Token == token);
                if (tokenItem != null)
                {
                    tokenItem.LastOnline = DateTime.Now;
                    await dbContext.SaveChangesAsync();

                    result.Data = (T)tokenItem;
                    result.Succeeded = true;

                    return result;
                }

                var socialSecurityNumberItem = dbContext.UserList.Include(x => x.RoleList).ThenInclude(x => x.RoleItem).Include(x => x.CompanyList).ThenInclude(x => x.CompanyItem).ThenInclude(x => x.ContactPersonList).SingleOrDefault(x => x.SocialSecurityNumber == socialSecurityNumber);
                if (socialSecurityNumberItem != null)
                {
                    socialSecurityNumberItem.Token = token;
                    socialSecurityNumberItem.LastOnline = DateTime.Now;
                    await dbContext.SaveChangesAsync();

                    result.Data = (T)socialSecurityNumberItem;
                    result.Succeeded = true;

                    return result;
                }

                var newUserItem = new UserItem
                {
                    Token = token,
                    SocialSecurityNumber = socialSecurityNumber,
                    Id = Guid.NewGuid(),
                    Created = DateTime.Now,
                    LastOnline = DateTime.Now,

                    Name = "Virksomhet"
                };

                var role = dbContext.RoleList.Single(x => x.Name == "Virksomhet");

                if ((await Add(newUserItem, new List<RoleItem> { role })).Succeeded)
                {
                    return Get<T>(newUserItem.Id);
                }
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public async Task<ApiResult> Add(UserItem userItem, List<RoleItem> roleList)
        {
            var result = new ApiResult();

            try
            {
                var userItemInDb = dbContext.UserList.SingleOrDefault(x => x.SocialSecurityNumber == userItem.SocialSecurityNumber);

                if (userItemInDb != null)
                {
                    userItemInDb.Token = userItem.Token;
                    await dbContext.SaveChangesAsync();
                }
                else
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
                }

                result.Succeeded = true;
                result.Id = userItem.Id;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public async Task<ApiResult> Update(UserItem userItem, List<RoleItem> roleList)
        {
            var result = new ApiResult();

            try
            {
                var dbItem = Get<UserItem>(userItem.Id).Data;

                dbItem.Name = userItem.Name;
                dbItem.SocialSecurityNumber = userItem.SocialSecurityNumber;
                dbItem.Email = userItem.Email;
                dbItem.PhoneCountryCode = userItem.PhoneCountryCode;
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

                result.Succeeded = true;
                result.Id = userItem.Id;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public async Task<ApiResult> Remove(Guid id)
        {
            var result = new ApiResult();

            try
            {
                var dbItem = dbContext.UserList.SingleOrDefault(x => x.Id == id);

                if (dbItem == null)
                {
                    throw new InvalidOperationException();
                }

                dbContext.UserList.Remove(dbItem);

                await dbContext.SaveChangesAsync();

                result.Succeeded = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }
    }
}