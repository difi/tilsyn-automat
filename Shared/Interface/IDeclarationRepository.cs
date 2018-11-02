using Difi.Sjalvdeklaration.Shared.Classes;
using System;
using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface IDeclarationRepository
    {
        IEnumerable<DeclarationItem> GetAll();

        DeclarationItem Get(Guid id);
    }
}