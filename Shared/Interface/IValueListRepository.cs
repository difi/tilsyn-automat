using System;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Interface.Base;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface IValueListRepository : IBaseRepository
    {
        ApiResult<T> GetAllTypeOfMachine<T>() where T : List<ValueListTypeOfMachine>;

        ApiResult<T> GetAllTypeOfTest<T>() where T : List<ValueListTypeOfTest>;

        ApiResult<T> GetAllTypeOfSupplierAndVersion<T>() where T : List<ValueListTypeOfSupplierAndVersion>;

        ApiResult<T> GetAllTypeOfStatus<T>() where T : List<ValueListTypeOfStatus>;

        ApiResult<T> GetAllPurposeOfTest<T>() where T : List<ValueListPurposeOfTest>;
    }
}