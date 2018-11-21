using Difi.Sjalvdeklaration.Shared.Classes;
using Microsoft.EntityFrameworkCore;

namespace Difi.Sjalvdeklaration.Database
{
    public class LogDbContext : DbContext
    {
        public DbSet<LogItem> LogList { get; set; }

        public LogDbContext(DbContextOptions<LogDbContext> options)
            : base(options)
        {
        }
    }
}