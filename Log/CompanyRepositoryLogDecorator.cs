using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.Shared.Extensions;
using Difi.Sjalvdeklaration.Shared.Interface;

namespace Difi.Sjalvdeklaration.Log
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
            var companyItemBefore = companyItem.DeepClone();

            var result = inner.Add(companyItem);

            logRepository.Add(new LogItem(userId, result, companyItemBefore));

            return result;
        }

        public ApiResult Update(CompanyItem companyItem)
        {
            var companyItemBefore = companyItem.DeepClone();

            var result = inner.Update(companyItem);

            logRepository.Add(new LogItem(userId, result, companyItemBefore));

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
            var excelRowBefore = excelRow.DeepClone();

            var result = inner.ExcelImport(excelRow);

            logRepository.Add(new LogItem(userId, result, excelRowBefore));

            return result;
        }

        public ApiResult AddLink(UserCompany userCompanyItem)
        {
            var userCompanyItemBefore = userCompanyItem.DeepClone();

            var result = inner.AddLink(userCompanyItem);

            logRepository.Add(new LogItem(userId, result, userCompanyItemBefore));

            return result;
        }

        public ApiResult RemoveLink(UserCompany userCompanyItem)
        {
            var userCompanyItemBefore = userCompanyItem.DeepClone();

            var result = inner.RemoveLink(userCompanyItem);

            logRepository.Add(new LogItem(userId, result, userCompanyItemBefore));

            return result;
        }

        public ApiResult UpdateCustom(CompanyCustomItem companyCustomItem)
        {
            var companyCustomItemBefore = companyCustomItem.DeepClone();

            var result = inner.UpdateCustom(companyCustomItem);

            logRepository.Add(new LogItem(userId, result, companyCustomItemBefore));

            return result;
        }
    }
}