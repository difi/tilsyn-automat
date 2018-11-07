using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;

namespace Difi.Sjalvdeklaration.Database
{
    public class LogRepository : ILogRepository
    {
        private readonly ApplicationDbContext dbContext;

        public LogRepository(ApplicationDbContext dbContext)
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
            catch
            {
                return false;
            }
        }
    }
}