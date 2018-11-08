using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using System;
using System.Collections.Generic;

namespace Log
{
    public class CompanyRepositoryLogDecorator : ICompanyRepository
    {
        private Guid userId;
        private readonly ICompanyRepository inner;
        private readonly ILogRepository logRepository;

        public CompanyRepositoryLogDecorator(ICompanyRepository inner, ILogRepository logRepository)
        {
            this.inner = inner;
            this.logRepository = logRepository;
        }

        public void SetCurrentUser(Guid id)
        {
            userId = id;
        }

        public ApiResult<T> Get<T>(Guid id) where T : CompanyItem
        {
            return inner.Get<T>(id);
        }

        public ApiResult<T> GetByCorporateIdentityNumber<T>(string corporateIdentityNumber) where T : CompanyItem
        {
            return inner.GetByCorporateIdentityNumber<T>(corporateIdentityNumber);
        }

        public ApiResult<T> GetAll<T>() where T : List<CompanyItem>
        {
            return inner.GetAll<T>();
        }

        public ApiResult Add(CompanyItem companyItem)
        {
            var result = inner.Add(companyItem);

            logRepository.Add(new LogItem(userId, result, companyItem));

            return result;
        }

        public ApiResult Update(CompanyItem companyItem)
        {
            var result = inner.Update(companyItem);

            logRepository.Add(new LogItem(userId, result, companyItem));

            return result;
        }

        public ApiResult Remove(Guid id)
        {
            var result = inner.Remove(id);

            logRepository.Add(new LogItem(userId, result, id));

            return result;
        }

        public ApiResult ExcelImport(ExcelItemRow excelRow)
        {
            var result = inner.ExcelImport(excelRow);

            logRepository.Add(new LogItem(userId, result, excelRow));

            return result;
        }

        public ApiResult AddLink(UserCompany userCompanyItem)
        {
            var result = inner.AddLink(userCompanyItem);

            logRepository.Add(new LogItem(userId, result, userCompanyItem));

            return result;
        }

        public ApiResult RemoveLink(UserCompany userCompanyItem)
        {
            var result = inner.RemoveLink(userCompanyItem);

            logRepository.Add(new LogItem(userId, result, userCompanyItem));

            return result;
        }
    }
}