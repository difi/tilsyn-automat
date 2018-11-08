using Difi.Sjalvdeklaration.Shared.Classes;
using System;
using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface IDeclarationRepository
    {
        void SetCurrentUser(Guid parse);

        ApiResult<T> Get<T>(Guid id) where T : DeclarationItem;

        ApiResult<T> GetAll<T>() where T : List<DeclarationItem>;

        ApiResult Add(DeclarationItem declarationItem);

        ApiResult Update(DeclarationItem declarationItem);

        ApiResult SendIn(Guid id);    }
}