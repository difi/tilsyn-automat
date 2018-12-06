using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using System;

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
    }
}