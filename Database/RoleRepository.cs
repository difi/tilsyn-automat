using System.Collections.Generic;
using System.Linq;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.EntityFrameworkCore;

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
            return dbContext.RoleList.AsNoTracking().ToList();
        }
    }
}