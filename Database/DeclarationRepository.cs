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
                var declarationItems = dbContext.DeclarationList.Include(x => x.Company).ThenInclude(x => x.ContactPersonList).Include(x => x.Company).ThenInclude(x => x.UserList).Include(x => x.User).AsNoTracking().OrderBy(x => x.Name).ToList();

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

        public async Task<ApiResult> Add(DeclarationItem declarationItem)
        {
            var result = new ApiResult();

            try
            {
                declarationItem.Id = Guid.NewGuid();
                declarationItem.CreatedDate = DateTime.Now;
                declarationItem.Status = DeclarationStatus.Created;
                declarationItem.User = userRepository.Get(declarationItem.UserItemId);

                dbContext.DeclarationList.Add(declarationItem);
                await dbContext.SaveChangesAsync();

                result.Succeeded = true;
                result.Id = declarationItem.Id;
            }
            catch (Exception exception)
            {
                result.Succeeded = false;
                result.Exception = exception;
            }

            return result;
        }

        public async Task<ApiResult> Update(DeclarationItem declarationItem)
        {
            var result = new ApiResult();

            try
            {
                var dbItem = Get(declarationItem.Id);

                dbItem.Name = declarationItem.Name;
                dbItem.DeadlineDate = declarationItem.DeadlineDate;
                dbItem.Status = declarationItem.Status;
                dbItem.User = userRepository.Get(declarationItem.UserItemId);

                dbContext.DeclarationList.Update(dbItem);

                await dbContext.SaveChangesAsync();

                result.Succeeded = true;
                result.Id = declarationItem.Id;
            }
            catch (Exception exception)
            {
                result.Succeeded = false;
                result.Exception = exception;
            }

            return result;
        }

        public async Task<ApiResult> SendIn(Guid id)
        {
            var result = new ApiResult();

            try
            {
                var dbItem = Get(id);

                dbItem.Status = DeclarationStatus.Complete;
                dbItem.SentInDate = DateTime.Now;

                dbContext.DeclarationList.Update(dbItem);

                await dbContext.SaveChangesAsync();

                result.Succeeded = true;
                result.Id = id;
            }
            catch (Exception exception)
            {
                result.Succeeded = false;
                result.Exception = exception;
            }

            return result;
        }
    }
}