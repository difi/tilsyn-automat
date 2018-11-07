using System;
using Difi.Sjalvdeklaration.Shared.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface IUserRepository
    {
        IEnumerable<UserItem> GetAllInternal();

        UserItem Get(Guid id);

        UserItem GetByToken(string token);

        Task<ApiResult> Add(UserItem userItem, List<RoleItem> roleList);

        Task<ApiResult> Update(UserItem userItem, List<RoleItem> roleList);

        Task<ApiResult> Remove(Guid parse);

        Task<UserItem> Login(string token, string socialSecurityNumber);
    }
}