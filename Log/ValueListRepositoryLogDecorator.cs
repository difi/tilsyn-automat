using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using Difi.Sjalvdeklaration.Shared.Interface;

namespace Difi.Sjalvdeklaration.Log
{
    public class ValueListRepositoryLogDecorator : IValueListRepository
    {
        private readonly IValueListRepository inner;

        public ValueListRepositoryLogDecorator(IValueListRepository inner)
        {
            this.inner = inner;
        }

        public ApiResult<T> GetAllTypeOfMachine<T>() where T : List<ValueListTypeOfMachine>
        {
            return inner.GetAllTypeOfMachine<T>();
        }

        public ApiResult<T> GetAllTypeOfTest<T>() where T : List<ValueListTypeOfTest>
        {
            return inner.GetAllTypeOfTest<T>();
        }

        public ApiResult<T> GetAllTypeOfSupplierAndVersion<T>() where T : List<ValueListTypeOfSupplierAndVersion>
        {
            return inner.GetAllTypeOfSupplierAndVersion<T>();
        }

        public ApiResult<T> GetAllTypeOfStatus<T>() where T : List<ValueListTypeOfStatus>
        {
            return inner.GetAllTypeOfStatus<T>();
        }

        public ApiResult<T> GetAllPurposeOfTest<T>() where T : List<ValueListPurposeOfTest>
        {
            return inner.GetAllPurposeOfTest<T>();
        }
    }
}