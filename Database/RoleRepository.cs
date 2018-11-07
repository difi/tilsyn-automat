using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Difi.Sjalvdeklaration.Database
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext dbContext;

        public RoleRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<RoleItem> GetAll()
        {
            return dbContext.RoleList.AsNoTracking().OrderBy(x => x.Name).ToList();
        }
    }
}