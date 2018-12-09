using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Difi.Sjalvdeklaration.Database
{
    public class LogRepository : ILogRepository
    {
        private readonly LogDbContext dbContext;

        public LogRepository(LogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ApiResult Add(LogItem logItem)
        {
            var result = new ApiResult();

            try
            {
                dbContext.LogList.Add(logItem);
                dbContext.SaveChanges();


                result.Succeeded = true;
                result.Id = logItem.Id;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public ApiResult<T> Get<T>(Guid id) where T:LogItem
        {
            var result = new ApiResult<T>();

            try
            {
                var item = dbContext.LogList.AsNoTracking().SingleOrDefault(x => x.Id == id);

                if (item != null)
                {
                    result.Data = (T)item;
                    result.Id = item.Id;
                    result.Succeeded = true;
                }
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public ApiResult<T> GetAll<T>() where T: List<LogItem>
        {
            var result = new ApiResult<T>();

            try
            {
                var list = dbContext.LogList.AsNoTracking().OrderByDescending(x => x.Created).ToList();

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