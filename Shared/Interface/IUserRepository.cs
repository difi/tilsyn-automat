using System;
using Difi.Sjalvdeklaration.Shared.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface IUserRepository
    {
        IEnumerable<UserItem> GetAll();

        UserItem Get(Guid id);

        UserItem GetByIdPortenSub(string idPortenSub);

        Task<bool> Add(UserItem userItem, List<RoleItem> roleList);

        Task<bool> Update(UserItem userItem, List<RoleItem> roleList);

        Task<bool> AddLink(UserCompany userCompanyItem);
    }
}