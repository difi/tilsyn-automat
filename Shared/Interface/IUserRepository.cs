using Difi.Sjalvdeklaration.Shared.Classes;
using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface IUserRepository
    {
        IEnumerable<UserItem> GetAll();

        UserItem GetByIdPortenSub(string idPortenSub);

        bool Add(UserItem userItem);

        bool AddLink(UserCompany userCompanyItem);
    }
}