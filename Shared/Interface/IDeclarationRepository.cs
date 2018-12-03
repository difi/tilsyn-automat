using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface IDeclarationRepository
    {
        void SetCurrentUser(Guid parse);

        ApiResult<T> Get<T>(Guid id) where T : DeclarationItem;

        ApiResult<T> GetAll<T>() where T : List<DeclarationItem>;

        ApiResult<T> GetOutcomeDataList<T>(Guid id) where T : List<OutcomeData>;

        ApiResult Add(DeclarationItem declarationItem);

        ApiResult Update(DeclarationItem declarationItem);

        ApiResult Save(Guid declarationItemId, List<OutcomeData> outcomeDataList, DeclarationTestItem declarationTestItem);

        ApiResult SendIn(Guid id);
    }
}