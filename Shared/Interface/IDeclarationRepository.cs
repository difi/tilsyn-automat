using Difi.Sjalvdeklaration.Shared.Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface IDeclarationRepository
    {
        ApiResult<T> Get<T>(Guid id) where T : DeclarationItem;

        ApiResult<T> GetAll<T>() where T : IEnumerable<DeclarationItem>;

        Task<ApiResult> Add(DeclarationItem declarationItem);

        Task<ApiResult> Update(DeclarationItem declarationItem);

        Task<ApiResult> SendIn(Guid id);
    }
}