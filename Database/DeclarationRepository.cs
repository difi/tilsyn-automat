using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Difi.Sjalvdeklaration.Database
{
    public class DeclarationRepository : IDeclarationRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IUserRepository userRepository;

        public DeclarationRepository(ApplicationDbContext dbContext, IUserRepository userRepository)
        {
            this.dbContext = dbContext;
            this.userRepository = userRepository;
        }

        public IEnumerable<DeclarationItem> GetAll()
        {
            try
            {
                var declarationItems = dbContext.DeclarationList.Include(x => x.Company).ThenInclude(x => x.ContactPersonList).Include(x => x.Company).ThenInclude(x => x.UserList).Include(x => x.User).AsNoTracking().ToList();

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
                var declarationItem = dbContext.DeclarationList.Include(x => x.Company).ThenInclude(x => x.ContactPersonList).Include(x => x.Company).ThenInclude(x => x.UserList).Include(x => x.User).AsNoTracking().SingleOrDefault(x => x.Id == id);

                return declarationItem;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Add(DeclarationItem declarationItem)
        {
            try
            {
                declarationItem.Id = Guid.NewGuid();
                declarationItem.CreatedDate = DateTime.Now;
                declarationItem.User = userRepository.Get(declarationItem.UserItemId);

                dbContext.DeclarationList.Add(declarationItem);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Update(DeclarationItem declarationItem)
        {
            try
            {
                var dbItem = Get(declarationItem.Id);

                dbItem.Name = declarationItem.Name;
                dbItem.DeadlineDate = declarationItem.DeadlineDate;
                dbItem.Status = declarationItem.Status;
                dbItem.User = userRepository.Get(declarationItem.UserItemId);

                dbContext.DeclarationList.Update(dbItem);

                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> SendIn(Guid id)
        {
            try
            {
                var dbItem = Get(id);

                dbItem.Status = DeclarationStatus.Complete;
                dbItem.SentInDate = DateTime.Now;

                dbContext.DeclarationList.Update(dbItem);

                await dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}