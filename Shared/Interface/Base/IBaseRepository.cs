using System;

namespace Difi.Sjalvdeklaration.Shared.Interface.Base
{
    public interface IBaseRepository
    {
        void SetCurrentUser(Guid parse);

        void SetCurrentLang(string lang);
    }
}