using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using Difi.Sjalvdeklaration.Shared.Interface;
using System.Collections.Generic;

namespace Log
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
    }
}