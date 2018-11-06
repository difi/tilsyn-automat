using Difi.Sjalvdeklaration.Shared.Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface IDeclarationRepository
    {
        IEnumerable<DeclarationItem> GetAll();

        DeclarationItem Get(Guid id);

        Task<bool> Add(DeclarationItem declarationItem);

        Task<bool> Update(DeclarationItem declarationItem);

        Task<bool> SendIn(Guid id);
    }
}