using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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
                RejectChanges();

                dbContext.LogList.Add(logItem);
                dbContext.SaveChanges();

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public void RejectChanges()
        {
            foreach (var entry in dbContext.ChangeTracker.Entries().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;

                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }
    }
}