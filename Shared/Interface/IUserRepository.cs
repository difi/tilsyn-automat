using System.Collections.Generic;
using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes;

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