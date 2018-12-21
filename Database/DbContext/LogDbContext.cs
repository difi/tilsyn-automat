using Difi.Sjalvdeklaration.Shared.Classes.Log;
using Microsoft.EntityFrameworkCore;

namespace Difi.Sjalvdeklaration.Database.DbContext
{
    public class LogDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<LogItem> LogList { get; set; }

        public LogDbContext(DbContextOptions<LogDbContext> options)
            : base(options)
        {
        }
    }
}