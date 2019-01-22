using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Interface.Base;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface IUserRepository : IBaseRepository
    {
        ApiResult<T> Get<T>(Guid id) where T : UserItem;

        ApiResult<T> GetByToken<T>(string token) where T : UserItem;

        ApiResult<T> GetAll<T>() where T : List<UserItem>;

        ApiResult<T> GetAllInternal<T>() where T : List<UserItem>;

        ApiResult<T> Login<T>(string token, long socialSecurityNumber) where T : UserItem;

        ApiResult Add(UserItem userItem, List<RoleItem> roleList);

        ApiResult Update(UserItem userItem, List<RoleItem> roleList);

        ApiResult Remove(Guid id);
    }
}