using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.User;

namespace Difi.Sjalvdeklaration.Database
{
    public class DeclarationRepository : IDeclarationRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IUserRepository userRepository;
        private readonly ICompanyRepository companyRepository;

        public DeclarationRepository(ApplicationDbContext dbContext, IUserRepository userRepository, ICompanyRepository companyRepository)
        {
            this.dbContext = dbContext;
            this.userRepository = userRepository;
            this.companyRepository = companyRepository;
        }

        public void SetCurrentUser(Guid parse)
        {
        }

        public ApiResult<T> Get<T>(Guid id) where T : DeclarationItem
        {
            var result = new ApiResult<T>();

            try
            {
                var item = dbContext.DeclarationList.Include(x => x.Company).ThenInclude(x => x.ContactPersonList).Include(x => x.Company).ThenInclude(x => x.UserList).Include(x => x.User).AsNoTracking().SingleOrDefault(x => x.Id == id);

                if (item != null)
                {
                    result.Data = (T)item;
                    result.Id = item.Id;
                    result.Succeeded = true;
                }
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public ApiResult<T> GetAll<T>() where T : List<DeclarationItem>
        {
            var result = new ApiResult<T>();

            try
            {
                var list = dbContext.DeclarationList.Include(x => x.Company).ThenInclude(x => x.ContactPersonList).Include(x => x.Company).ThenInclude(x => x.UserList).Include(x => x.User).AsNoTracking().OrderBy(x => x.Name).ToList();

                result.Data = (T)list;
                result.Succeeded = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public ApiResult Add(DeclarationItem declarationItem)
        {
            var result = new ApiResult();

            try
            {
                declarationItem.Id = Guid.NewGuid();
                declarationItem.CreatedDate = DateTime.Now;
                declarationItem.Status = DeclarationStatus.Created;
                declarationItem.User = userRepository.Get<UserItem>(declarationItem.UserItemId).Data;

                dbContext.DeclarationList.Add(declarationItem);
                dbContext.SaveChanges();

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

        public ApiResult Update(DeclarationItem declarationItem)
        {
            var result = new ApiResult();

            try
            {
                var dbItem = Get<DeclarationItem>(declarationItem.Id).Data;

                dbItem.Name = declarationItem.Name;
                dbItem.DeadlineDate = declarationItem.DeadlineDate;
                dbItem.Status = declarationItem.Status;
                dbItem.User = (UserItem)userRepository.Get<UserItem>(declarationItem.UserItemId).Data;

                dbContext.DeclarationList.Update(dbItem);

                if (declarationItem.Status == DeclarationStatus.Finished || declarationItem.Status == DeclarationStatus.Canceled)
                {
                    var companyItem = companyRepository.Get<CompanyItem>(declarationItem.CompanyItemId).Data;

                    foreach (var userCompany in companyItem.UserList)
                    {
                        dbContext.Remove(userCompany);
                    }
                }

                dbContext.SaveChanges();

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

        public ApiResult SendIn(Guid id)
        {
            var result = new ApiResult();

            try
            {
                var dbItem = Get<DeclarationItem>(id).Data;

                dbItem.Status = DeclarationStatus.Complete;
                dbItem.SentInDate = DateTime.Now;

                dbContext.DeclarationList.Update(dbItem);

                dbContext.SaveChanges();

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