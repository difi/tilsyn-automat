using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.ValueList;
using Difi.Sjalvdeklaration.Shared.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Difi.Sjalvdeklaration.Database
{
    public class ValueListRepository : IValueListRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ValueListRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ApiResult<T> GetAllTypeOfMachine<T>() where T : List<ValueListTypeOfMachine>
        {
            var result = new ApiResult<T>();

            try
            {
                var list = dbContext.VlTypeOfMachineList.AsNoTracking().OrderBy(x => x.Text).ToList();

                result.Data = (T)list;
                result.Succeeded = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public ApiResult<T> GetAllTypeOfTest<T>() where T : List<ValueListTypeOfTest>
        {
            var result = new ApiResult<T>();

            try
            {
                var list = dbContext.VlTypeOfTestList.AsNoTracking().OrderBy(x => x.Text).ToList();

                result.Data = (T)list;
                result.Succeeded = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public ApiResult<T> GetAllTypeOfSupplierAndVersion<T>() where T : List<ValueListTypeOfSupplierAndVersion>
        {
            var result = new ApiResult<T>();

            try
            {
                var list = dbContext.VlTypeOfSupplierAndVersionList.AsNoTracking().OrderBy(x => x.Text).ToList();

                result.Data = (T)list;
                result.Succeeded = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }
    }
}