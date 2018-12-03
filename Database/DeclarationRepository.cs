using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.Shared.Enum;
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
        private readonly IUserRepository userRepository;

        public DeclarationRepository(ApplicationDbContext dbContext, IUserRepository userRepository)
        {
            this.dbContext = dbContext;
            this.userRepository = userRepository;
        }

        public void SetCurrentUser(Guid parse)
        {
        }

        public ApiResult<T> Get<T>(Guid id) where T : DeclarationItem
        {
            var result = new ApiResult<T>();

            try
            {
                var item = dbContext.DeclarationList
                    .Include(x => x.Company).ThenInclude(x => x.ContactPersonList)
                    .Include(x => x.Company).ThenInclude(x => x.UserList)
                    .Include(x => x.User)
                    .Include(x => x.Status)
                    .Include(x => x.IndicatorList).ThenInclude(x=>x.TestGroupItem)
                    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.TypeOfTest)
                    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.TypeOfMachine)
                    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.SupplierAndVersion)
                    .Include(x => x.IndicatorList).ThenInclude(x => x.IndicatorItem).ThenInclude(x => x.RuleList).ThenInclude(x => x.AnswerList).ThenInclude(x => x.TypeOfAnswer)
                    .Include(x => x.IndicatorList).ThenInclude(x => x.IndicatorItem).ThenInclude(x => x.RuleList).ThenInclude(x => x.Chapter)
                    .Include(x => x.IndicatorList).ThenInclude(x => x.IndicatorItem).ThenInclude(x => x.IndicatorUserPrerequisiteList).ThenInclude(x => x.ValueListUserPrerequisite)
                    .AsNoTracking().SingleOrDefault(x => x.Id == id);

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
                var list = dbContext.DeclarationList
                    .Include(x => x.Company).ThenInclude(x => x.ContactPersonList)
                    .Include(x => x.Company).ThenInclude(x => x.UserList)
                    .Include(x => x.User)
                    .Include(x => x.Status)
                    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.TypeOfTest)
                    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.TypeOfMachine)
                    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.SupplierAndVersion)
                    .AsNoTracking().OrderBy(x => x.Name).ToList();

                result.Data = (T) list;
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
                    .Include(x => x.Indicator).ThenInclude(x => x.TestGroupList)
                    .Include(x => x.RuleDataList).ThenInclude(x => x.Result)
                    .Include(x => x.RuleDataList).ThenInclude(x => x.Rule)
                    .Include(x => x.RuleDataList).ThenInclude(x => x.AnswerDataList).ThenInclude(x => x.Result)
                    .Include(x => x.RuleDataList).ThenInclude(x => x.AnswerDataList).ThenInclude(x => x.AnswerItem)
                    .Include(x => x.RuleDataList).ThenInclude(x => x.AnswerDataList).ThenInclude(x => x.Image)
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
                declarationItem.StatusId = (int)DeclarationStatus.Created;
                declarationItem.UserItemId = userRepository.Get<UserItem>(declarationItem.UserItemId).Data.Id;
                declarationItem.IndicatorList = new List<DeclarationIndicatorGroup>();

                declarationItem.DeclarationTestItem = new DeclarationTestItem
                {
                    Id = declarationItem.Id,
                    TypeOfMachine = dbContext.VlTypeOfMachineList.Single(x => x.Id == 1),
                    TypeOfTest = dbContext.VlTypeOfTestList.Single(x => x.Id == 1),
                    PurposeOfTestId = declarationItem.DeclarationTestItem.PurposeOfTestId
                };

                foreach (var indicatorTestGroup in dbContext.IndicatorTestGroupList.Include(x => x.IndicatorItem).Include(x => x.TestGroupItem))
                {
                    declarationItem.IndicatorList.Add(new DeclarationIndicatorGroup
                    {
                        IndicatorItem = indicatorTestGroup.IndicatorItem,
                        TestGroupOrder = indicatorTestGroup.TestGroupItem.Order,
                        IndicatorInTestGroupOrder = indicatorTestGroup.Order,
                        TestGroupItemId = indicatorTestGroup.TestGroupItemId
                    });
                }

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
                var dbItem = dbContext.DeclarationList.Include(x => x.DeclarationTestItem).Single(x => x.Id == declarationItem.Id);

                dbItem.Name = declarationItem.Name;
                dbItem.CaseNumber = declarationItem.CaseNumber;
                dbItem.DeadlineDate = declarationItem.DeadlineDate;
                dbItem.StatusId = declarationItem.StatusId;
                dbItem.UserItemId = userRepository.Get<UserItem>(declarationItem.UserItemId).Data.Id;
                dbItem.DeclarationTestItem.PurposeOfTestId = declarationItem.DeclarationTestItem.PurposeOfTestId;

                //if (declarationItem.Status == DeclarationStatus.Finished || declarationItem.Status == DeclarationStatus.Canceled)
                //{
                //    var companyItem = companyRepository.Get<CompanyItem>(declarationItem.CompanyItemId).Data;

                //    foreach (var userCompany in companyItem.UserList)
                //    {
                //        dbContext.Remove(userCompany);
                //    }
                //}

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

        public ApiResult Save(Guid declarationItemId, List<OutcomeData> outcomeDataList, DeclarationTestItem declarationTestItem)
        {
            var result = new ApiResult();

            try
            {
                dbContext.OutcomeData.RemoveRange(dbContext.OutcomeData.Where(x => x.DeclarationTestItemId == declarationItemId));

                foreach (var outcomeData in outcomeDataList)
                {
                    outcomeData.ResultId = (int) TypeOfResult.NotTested;

                    foreach (var ruleData in outcomeData.RuleDataList)
                    {
                        ruleData.ResultId = (int) TypeOfResult.NotTested;

                        foreach (var answerData in ruleData.AnswerDataList)
                        {
                            answerData.ResultId = (int) GetResultId(answerData);

                            UpdateParent(ruleData, answerData);
                        }

                        //if (ruleData.AnswerDataList.Any(x => x.ResultId == (int) TypeOfResult.Fail))
                        //{
                        //    ruleData.ResultId = (int) TypeOfResult.Fail;
                        //}
                        //else
                        //{
                        //    ruleData.ResultId = (int) TypeOfResult.Ok;
                        //}
                    }

                    //if (outcomeData.RuleDataList.Any(x => x.ResultId == (int) TypeOfResult.Fail))
                    //{
                    //    outcomeData.ResultId = (int) TypeOfResult.Fail;
                    //}
                    //else
                    //{
                    //    outcomeData.ResultId = (int) TypeOfResult.Ok;
                    //}

                    dbContext.OutcomeData.Add(outcomeData);
                }

                var dbItem = dbContext.DeclarationList.Include(x=>x.DeclarationTestItem).Single(x => x.Id == declarationItemId);
                dbItem.StatusId = (int) DeclarationStatus.Started;

                dbItem.DeclarationTestItem.DescriptionInText = declarationTestItem.DescriptionInText;
                dbItem.DeclarationTestItem.Image1Id = declarationTestItem.Image1Id;
                dbItem.DeclarationTestItem.Image2Id = declarationTestItem.Image2Id;

                dbContext.SaveChanges();

                result.Succeeded = true;
                result.Id = dbItem.Id;
            }
            catch (Exception exception)
            {
                result.Succeeded = false;
                result.Exception = exception;
            }

            return result;
        }

        private void UpdateParent(RuleData ruleData, AnswerData answerData)
        {
            var answerItem = dbContext.AnswerList.Include(x => x.TypeOfAnswer).AsNoTracking().Single(x => x.Id == answerData.AnswerItemId);

            if (answerData.ResultId == (int) TypeOfResult.Ok || answerData.ResultId == (int) TypeOfResult.Fail)
            {
                if (answerItem.LinkedParentFailedId != Guid.Empty)
                {
                    var item = ruleData.AnswerDataList.Single(x => x.AnswerItemId == answerItem.LinkedParentFailedId);

                    item.ResultId = answerData.ResultId;

                    UpdateParent(ruleData, item);
                }
            }
        }

        public ApiResult SendIn(Guid id)
        {
            var result = new ApiResult();

            try
            {
                var dbItem = dbContext.DeclarationList.Single(x => x.Id == id);
                dbItem.StatusId = (int)DeclarationStatus.SentIn;
                dbItem.SentInDate = DateTime.Now;

                dbContext.SaveChanges();

                result.Succeeded = true;
                result.Id = dbItem.Id;
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
            var answerItem = dbContext.AnswerList.Include(x => x.TypeOfAnswer).AsNoTracking().Single(x => x.Id == answerData.AnswerItemId);

            switch (answerItem.TypeOfAnswer.Id)
            {
                case (int)TypeOfAnswer.Bool when answerData.Bool == null:
                    return TypeOfResult.NotTested;

                case (int)TypeOfAnswer.Bool when answerData.Bool == answerItem.Bool:

                    return TypeOfResult.Ok;

                case (int)TypeOfAnswer.Bool when answerData.Bool != answerItem.Bool:
                    return TypeOfResult.Fail;

                case (int)TypeOfAnswer.Int when answerData.Int > 0:
                    {
                        if (answerItem.MaxInt > 0)
                        {
                            return answerData.Int >= answerItem.MinInt && answerData.Int <= answerItem.MaxInt ? TypeOfResult.Ok : TypeOfResult.Fail;
                        }

                        return answerData.Int >= answerItem.MinInt ? TypeOfResult.Ok : TypeOfResult.Fail;
                    }

                case (int)TypeOfAnswer.String when String.IsNullOrWhiteSpace(answerData.String):
                    return TypeOfResult.NotTested;

                case (int)TypeOfAnswer.String when !String.IsNullOrWhiteSpace(answerData.String):
                    return TypeOfResult.NotTestable;

                case (int)TypeOfAnswer.Image when answerData.ImageId == null:
                    return TypeOfResult.NotTested;

                case (int)TypeOfAnswer.Image when answerData.ImageId != null:
                    return TypeOfResult.NotTestable;

                default:
                    return TypeOfResult.NotTested;
            }
        }
    }
}