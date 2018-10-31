using System;
using Difi.Sjalvdeklaration.Shared.Classes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Difi.Sjalvdeklaration.Shared.Interface;

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