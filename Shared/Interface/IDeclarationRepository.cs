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

        Task<ApiResult> Add(DeclarationItem declarationItem);

        Task<ApiResult> Update(DeclarationItem declarationItem);

        Task<ApiResult> SendIn(Guid id);
    }
}