using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.Shared.Enum;

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
                //var item = dbContext.DeclarationList
                //    .Include(x => x.Company).ThenInclude(x => x.ContactPersonList)
                //    .Include(x => x.Company).ThenInclude(x => x.UserList)
                //    .Include(x => x.User)
                //    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.TypeOfTest)
                //    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.TypeOfMachine)
                //    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.SupplierAndVersion)
                //    .Include(x => x.TestGroupList).ThenInclude(x => x.TestGroupItem).ThenInclude(x => x.IndicatorList).ThenInclude(x => x.RuleList).ThenInclude(x => x.AnswerList).ThenInclude(x => x.TypeOfAnswer)
                //    .Include(x => x.TestGroupList).ThenInclude(x => x.TestGroupItem).ThenInclude(x => x.RequirementList).ThenInclude(x => x.RuleList).ThenInclude(x => x.Chapter)
                //    .Include(x => x.TestGroupList).ThenInclude(x => x.TestGroupItem).ThenInclude(x => x.RequirementList).ThenInclude(x => x.RequirementUserPrerequisiteList).ThenInclude(x => x.ValueListUserPrerequisite)
                //    .AsNoTracking().SingleOrDefault(x => x.Id == id);

                //if (item != null)
                //{
                //    result.Data = (T)item;
                //    result.Id = item.Id;
                //    result.Succeeded = true;
                //}
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
                var list = dbContext.DeclarationList
                    .Include(x => x.Company).ThenInclude(x => x.ContactPersonList)
                    .Include(x => x.Company).ThenInclude(x => x.UserList)
                    .Include(x => x.User)
                    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.TypeOfTest)
                    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.TypeOfMachine)
                    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.SupplierAndVersion)
                    .AsNoTracking().OrderBy(x => x.Name).ToList();

                result.Data = (T)list;
                result.Succeeded = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public ApiResult<T> GetOutcomeDataList<T>(Guid id) where T : List<OutcomeData>
        {
            var result = new ApiResult<T>();

            try
            {
                var list = dbContext.OutcomeData
                    .Include(x => x.Result)
                    .Include(x => x.Requirement)
                    .Include(x => x.Indicator).ThenInclude(x => x.TestGroupList)
                    .Include(x => x.RuleDataList).ThenInclude(x=>x.Result)
                    .Include(x => x.RuleDataList).ThenInclude(x => x.Rule)
                    .Include(x => x.RuleDataList).ThenInclude(x => x.AnswerDataList).ThenInclude(x => x.Result)
                    .Include(x => x.RuleDataList).ThenInclude(x => x.AnswerDataList).ThenInclude(x => x.AnswerItem)
                    .AsNoTracking().Where(x => x.DeclarationTestItemId == id).ToList();

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

                declarationItem.DeclarationTestItem = new DeclarationTestItem
                {
                    Id = declarationItem.Id,
                    TypeOfMachine = dbContext.VlTypeOfMachineList.Single(x => x.Id == 1),
                    TypeOfTest = dbContext.VlTypeOfTestList.Single(x => x.Id == 1)
                };

                var testGroup1 = dbContext.TestGroupList.SingleOrDefault(x => x.Name == "Kundens betjeningsområde");
                var testGroup2 = dbContext.TestGroupList.SingleOrDefault(x => x.Name == "Skilt");
                var testGroup3 = dbContext.TestGroupList.SingleOrDefault(x => x.Name == "Betjeningshøyde");

                declarationItem.TestGroupList = new List<DeclarationTestGroup>
                {
                    new DeclarationTestGroup {TestGroupItem = testGroup1, Order = 1},
                    new DeclarationTestGroup {TestGroupItem = testGroup2, Order = 2},
                    new DeclarationTestGroup {TestGroupItem = testGroup3, Order = 3}
                };

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

        public ApiResult Save(DeclarationItem declarationItem)
        {
            var result = new ApiResult();

            return result;

            try
            {
                //foreach (var declarationTestGroup in declarationItem.TestGroupList)
                //{
                //    foreach (var requirementItem in declarationTestGroup.TestGroupItem.RequirementList)
                //    {
                //        var outcomeData = requirementItem.OutcomeData;
                //        outcomeData.ResultId = (int)TypeOfResult.NotTested;

                //        foreach (var ruleData in outcomeData.RuleDataList)
                //        {
                //            ruleData.ResultId = (int)TypeOfResult.NotTested;

                //            foreach (var answerData in ruleData.AnswerDataList)
                //            {
                //                answerData.ResultId = (int) GetResultId(answerData);
                //            }

                //            if (ruleData.AnswerDataList.Any(x => x.ResultId == (int) TypeOfResult.Fail))
                //            {
                //                ruleData.ResultId = (int)TypeOfResult.Fail;
                //            }
                //            else
                //            {
                //                ruleData.ResultId = (int) TypeOfResult.Ok;
                //            }
                //        }

                //        if (outcomeData.RuleDataList.Any(x => x.ResultId == (int)TypeOfResult.Fail))
                //        {
                //            outcomeData.ResultId = (int)TypeOfResult.Fail;
                //        }
                //        else
                //        {
                //            outcomeData.ResultId = (int)TypeOfResult.Ok;
                //        }

                //        dbContext.OutcomeData.Add(outcomeData);
                //    }
                //}

                //var dbItem = Get<DeclarationItem>(declarationItem.Id).Data;

                //dbItem.Status = DeclarationStatus.Complete;
                //dbItem.SentInDate = DateTime.Now;

                //dbContext.DeclarationList.Update(dbItem);

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

        private TypeOfResult GetResultId(AnswerData answerData)
        {
            var answerItem = dbContext.AnswerList.Include(x => x.TypeOfAnswer).Single(x => x.Id == answerData.AnswerItemId);

            switch (answerItem.TypeOfAnswer.Id)
            {
                case (int) TypeOfAnswer.Bool when answerData.Bool == answerItem.Bool:
                    return TypeOfResult.Ok;

                case (int) TypeOfAnswer.Bool when answerData.Bool != answerItem.Bool:
                    return TypeOfResult.Fail;

                case (int) TypeOfAnswer.Int when answerData.Int > 0:
                {
                    return answerData.Int >= answerItem.MinInt && answerData.Int <= answerItem.MaxInt ? TypeOfResult.Ok : TypeOfResult.Fail;
                }

                default:
                    return TypeOfResult.NotTested;
            }
        }
    }
}