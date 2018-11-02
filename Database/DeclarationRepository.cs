using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Difi.Sjalvdeklaration.Database
{
    public class DeclarationRepository : IDeclarationRepository
    {
        private readonly ApplicationDbContext dbContext;

        public DeclarationRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<DeclarationItem> GetAll()
        {
            try
            {
                var declarationItems = dbContext.DeclarationList.Include(x => x.Company).Include(x => x.User).AsNoTracking().ToList();

                return declarationItems;
            }
            catch
            {
                return null;
            }
        }

        public DeclarationItem Get(Guid id)
        {
            try
            {
                var declarationItem = dbContext.DeclarationList.Include(x => x.Company).Include(x => x.User).AsNoTracking().SingleOrDefault(x => x.Id == id);

                return declarationItem;
            }
            catch
            {
                return null;
            }
        }
    }
}