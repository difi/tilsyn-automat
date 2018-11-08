using System;
using Difi.Sjalvdeklaration.Shared.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface IUserRepository
    {
        void SetCurrentUser(Guid id);

        ApiResult<T> Get<T>(Guid id) where T : UserItem;

        ApiResult<T> GetByToken<T>(string token) where T : UserItem;

        ApiResult<T> GetAllInternal<T>() where T : List<UserItem>;

        ApiResult<T> Login<T>(string token, string socialSecurityNumber) where T : UserItem;

        ApiResult Add(UserItem userItem, List<RoleItem> roleList);

        ApiResult Update(UserItem userItem, List<RoleItem> roleList);

        ApiResult Remove(Guid id);
    }
}