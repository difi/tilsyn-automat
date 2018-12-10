using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Difi.Sjalvdeklaration.Database
{
    public class LogRepository : ILogRepository
    {
        private readonly LogDbContext dbContext;
        private readonly IStringLocalizer<LogRepository> localizer;

        public LogRepository(LogDbContext dbContext, IStringLocalizer<LogRepository> localizer)
        {
            this.dbContext = dbContext;
            this.localizer = localizer;
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
                else
                {
                    result.Exception = new Exception(localizer["Log item with id: {0} doesn't exist.", id]);
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
                var list = dbContext.LogList.AsNoTracking().OrderByDescending(x => x.Created).Take(100).ToList();

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