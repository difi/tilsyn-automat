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

                var temp = dbContext.DeclarationList.Include(x => x.Company).Include(x => x.User).AsNoTracking().ToList();

                return temp;
            }
            catch (Exception exception)
            {
                var temp = exception;

                return null;
            }
        }
    }
}