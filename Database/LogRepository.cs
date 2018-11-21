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

        public bool Add(LogItem logItem)
        {
            try
            {
                dbContext.LogList.Add(logItem);
                dbContext.SaveChanges();

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }
}