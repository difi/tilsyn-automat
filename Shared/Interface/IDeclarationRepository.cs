using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface IDeclarationRepository
    {
        IEnumerable<DeclarationItem> GetAll();
    }
}