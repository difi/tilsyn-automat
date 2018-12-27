using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.Shared.Enum;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using Difi.Sjalvdeklaration.Database.DbContext;

namespace Difi.Sjalvdeklaration.Database
{
    public class DeclarationRepository : IDeclarationRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IUserRepository userRepository;
        private readonly IStringLocalizer<DeclarationRepository> localizer;

        public DeclarationRepository(ApplicationDbContext dbContext, IUserRepository userRepository, IStringLocalizer<DeclarationRepository> localizer)
        {
            this.dbContext = dbContext;
            this.userRepository = userRepository;
            this.localizer = localizer;
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
                    .Include(x => x.IndicatorList).ThenInclude(x => x.TestGroupItem)
                    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.TypeOfTest)
                    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.PurposeOfTest)
                    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.TypeOfMachine)
                    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.SupplierAndVersion)
                    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.FinishedStatus)
                    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.Image1)
                    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.Image2)
                    .Include(x => x.IndicatorList).ThenInclude(x => x.IndicatorItem).ThenInclude(x => x.RuleList).ThenInclude(x => x.AnswerList).ThenInclude(x => x.TypeOfAnswer)
                    .Include(x => x.IndicatorList).ThenInclude(x => x.IndicatorItem).ThenInclude(x => x.RuleList).ThenInclude(x => x.Chapter)
                    .Include(x => x.IndicatorList).ThenInclude(x => x.IndicatorItem).ThenInclude(x => x.IndicatorUserPrerequisiteList).ThenInclude(x => x.ValueListUserPrerequisite)
                    .AsNoTracking().SingleOrDefault(x => x.Id == id);

                if (item != null)
                {
                    var testGroupLanguageList = dbContext.TestGroupLanguageList.Include(x => x.LanguageItem).Where(x => x.LanguageItem.Name == "nb-NO");
                    var ruleLanguageList = dbContext.RuleLanguageList.Include(x => x.LanguageItem).Where(x => x.LanguageItem.Name == "nb-NO");
                    var answerLanguageList = dbContext.AnswerLanguageList.Include(x => x.LanguageItem).Where(x => x.LanguageItem.Name == "nb-NO");

                    foreach (var declarationIndicatorGroup in item.IndicatorList)
                    {
                        declarationIndicatorGroup.TestGroupItem.Language = testGroupLanguageList.SingleOrDefault(x => x.TestGroupItemId == declarationIndicatorGroup.TestGroupItemId);

                        foreach (var ruleItem in declarationIndicatorGroup.IndicatorItem.RuleList)
                        {
                            ruleItem.Language = ruleLanguageList.SingleOrDefault(x => x.RuleItemId == ruleItem.Id);

                            foreach (var answerItem in ruleItem.AnswerList)
                            {
                                answerItem.Language = answerLanguageList.SingleOrDefault(x => x.AnswerItemId == answerItem.Id);
                            }
                        }
                    }

                    result.Data = (T)item;
                    result.Id = item.Id;
                    result.Succeeded = true;
                }
                else
                {
                    result.Exception = new Exception(localizer["Declaration with id: {0} doesn't exist.", id]);
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
                    .Include(x => x.IndicatorList).ThenInclude(x => x.TestGroupItem)
                    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.TypeOfTest)
                    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.PurposeOfTest)
                    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.TypeOfMachine)
                    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.SupplierAndVersion)
                    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.FinishedStatus)
                    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.Image1)
                    .Include(x => x.DeclarationTestItem).ThenInclude(x => x.Image2)
                    .Include(x => x.IndicatorList).ThenInclude(x => x.IndicatorItem).ThenInclude(x => x.RuleList).ThenInclude(x => x.AnswerList).ThenInclude(x => x.TypeOfAnswer)
                    .Include(x => x.IndicatorList).ThenInclude(x => x.IndicatorItem).ThenInclude(x => x.RuleList).ThenInclude(x => x.Chapter)
                    .Include(x => x.IndicatorList).ThenInclude(x => x.IndicatorItem).ThenInclude(x => x.IndicatorUserPrerequisiteList).ThenInclude(x => x.ValueListUserPrerequisite)
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

        public ApiResult<T> GetByFilter<T>(FilterModel filterModel) where T : List<DeclarationItem>
        {
            var result = new ApiResult<T>();

            try
            {
                var all = GetAll<T>().Data;
                var filterdList = all.Where(x => x.DeadlineDate > filterModel.FromDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59) && x.DeadlineDate < filterModel.ToDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59)).ToList();

                if (filterModel.Status > 0)
                {
                    filterdList = filterdList.Where(x => x.StatusId == filterModel.Status).ToList();
                }

                result.Data = (T)filterdList;
                result.Succeeded = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }

        public ApiResult<T> GetForCompany<T>(Guid id) where T : List<DeclarationItem>
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
                    .AsNoTracking().Where(x => x.CompanyItemId == id).OrderBy(x => x.Name).ToList();

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
                    .Include(x => x.IndicatorOutcomeItem)
                    .Include(x => x.Indicator).ThenInclude(x => x.TestGroupList)
                    .Include(x => x.Indicator).ThenInclude(x => x.RuleList).ThenInclude(x => x.Chapter).ThenInclude(x => x.Standard)
                    .Include(x => x.Indicator).ThenInclude(x => x.RuleList).ThenInclude(x => x.Requirement)
                    .Include(x => x.RuleDataList).ThenInclude(x => x.Result)
                    .Include(x => x.RuleDataList).ThenInclude(x => x.Rule)
                    .Include(x => x.RuleDataList).ThenInclude(x => x.AnswerDataList).ThenInclude(x => x.Result)
                    .Include(x => x.RuleDataList).ThenInclude(x => x.AnswerDataList).ThenInclude(x => x.AnswerItem)
                    .Include(x => x.RuleDataList).ThenInclude(x => x.AnswerDataList).ThenInclude(x => x.Image)
                    .AsNoTracking().Where(x => x.DeclarationTestItemId == id).ToList();

                var indicatorOutcomeLanguageList = dbContext.IndicatorOutcomeLanguageList.Include(x => x.LanguageItem).Where(x => x.LanguageItem.Name == "nb-NO");
                var requirementLanguageList = dbContext.RequirementLanguageList.Include(x => x.LanguageItem).Where(x => x.LanguageItem.Name == "nb-NO");

                foreach (var outcomeData in list)
                {
                    if (outcomeData.IndicatorOutcomeItem != null)
                    {
                        outcomeData.IndicatorOutcomeItem.Language = indicatorOutcomeLanguageList.SingleOrDefault(x => x.IndicatorOutcomeItemId == outcomeData.IndicatorOutcomeItemId);
                    }

                    foreach (var ruleItem in outcomeData.Indicator.RuleList)
                    {
                        if (ruleItem != null)
                        {
                            ruleItem.Requirement.Language = requirementLanguageList.SingleOrDefault(x => x.RequirementItemId == ruleItem.RequirementItemId);
                        }
                    }
                }

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

                if (!String.IsNullOrEmpty(declarationItem.UserName))
                {
                    var user = dbContext.UserList.SingleOrDefault(x => x.Name == declarationItem.UserName);

                    if (user != null)
                    {
                        declarationItem.UserItemId = user.Id;
                    }
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

                if (dbItem == null)
                {
                    throw new InvalidOperationException(localizer["Declaration with id: {0} doesn't exist.", declarationItem.Id]);
                }

                dbItem.Name = declarationItem.Name;
                dbItem.CaseNumber = declarationItem.CaseNumber;
                dbItem.DeadlineDate = declarationItem.DeadlineDate;
                dbItem.StatusId = declarationItem.StatusId;
                dbItem.UserItemId = userRepository.Get<UserItem>(declarationItem.UserItemId).Data.Id;
                dbItem.DeclarationTestItem.PurposeOfTestId = declarationItem.DeclarationTestItem.PurposeOfTestId;

                if (declarationItem.StatusId == (int)DeclarationStatus.Finished || declarationItem.StatusId == (int)DeclarationStatus.Canceled)
                {
                    var companyItem = dbContext.CompanyList.Include(x => x.UserList).ThenInclude(x => x.UserItem).AsNoTracking().SingleOrDefault(x => x.Id == declarationItem.CompanyItemId);

                    if (companyItem != null)
                    {
                        foreach (var userCompany in companyItem.UserList)
                        {
                            dbContext.Remove(userCompany);
                        }

                        companyItem.Code = string.Empty;
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

        public ApiResult<T> Save<T>(Guid declarationItemId, DeclarationTestItem declarationTestItem) where T: DeclarationSaveResult
        {
            var result = new ApiResult<T>
            {
                Data = (T) new DeclarationSaveResult
                {
                    StausCount =  0,
                    Step1Done = false,
                    OutcomeData = new List<OutcomeData>()
                }
            };

            var testGroupItemList = new List<TestGroupItem>();
            var answerLanguageList = dbContext.AnswerLanguageList.Include(x => x.LanguageItem).Where(x => x.LanguageItem.Name == "nb-NO");

            foreach (var declarationIndicatorGroup in dbContext.DeclarationList.Include(x => x.IndicatorList).ThenInclude(x => x.TestGroupItem).ThenInclude(x => x.IndicatorList).Single(x => x.Id == declarationItemId).IndicatorList.OrderBy(x => x.TestGroupOrder))
            {
                if (testGroupItemList.All(x => x.Id != declarationIndicatorGroup.TestGroupItemId))
                {
                    var item = declarationIndicatorGroup.TestGroupItem;
                    item.AllDone = true;

                    testGroupItemList.Add(item);
                }
            }

            try
            {
                dbContext.OutcomeData.RemoveRange(dbContext.OutcomeData.Where(x => x.DeclarationTestItemId == declarationItemId));

                foreach (var outcomeData in declarationTestItem.OutcomeDataList)
                {
                    var allDone = true;

                    outcomeData.ResultId = (int)TypeOfResult.NotTested;

                    foreach (var ruleData in outcomeData.RuleDataList)
                    {
                        ruleData.ResultId = (int)TypeOfResult.NotTested;

                        foreach (var answerData in ruleData.AnswerDataList)
                        {
                            answerData.ResultId = (int)GetResultId(answerData, ruleData);

                            UpdateParent(ruleData, answerData);
                        }

                        if (ruleData.AnswerDataList.Any(x => x.ResultId == (int)TypeOfResult.Fail))
                        {
                            ruleData.ResultId = (int)TypeOfResult.Fail;
                        }
                        else
                        {
                            if (ruleData.AnswerDataList.Any(x => x.ResultId == (int)TypeOfResult.Ok))
                            {
                                ruleData.ResultId = (int)TypeOfResult.Ok;
                            }
                        }

                        if (ruleData.AnswerDataList.Any(x => x.ResultId == (int)TypeOfResult.NotTested))
                        {
                            allDone = false;
                        }
                    }

                    if (outcomeData.RuleDataList.Any(x => x.ResultId == (int)TypeOfResult.Fail))
                    {
                        outcomeData.ResultId = (int)TypeOfResult.Fail;
                    }
                    else
                    {
                        if (outcomeData.RuleDataList.Any(x => x.ResultId == (int)TypeOfResult.Ok))
                        {
                            outcomeData.ResultId = (int)TypeOfResult.Ok;
                        }
                    }

                    var indicatorItem = dbContext.IndicatorList.Include(x => x.TestGroupList).Single(x => x.Id == outcomeData.IndicatorItemId);
                    var listItem = testGroupItemList.Single(x => x.IndicatorList.Any(y => y.IndicatorItemId == indicatorItem.Id));

                    if (listItem.AllDone)
                    {
                        listItem.AllDone = allDone;
                    }

                    outcomeData.AllDone = allDone;

                    var answerDataString = string.Empty;
                    var resultString = string.Empty;

                    foreach (var ruleData in outcomeData.RuleDataList)
                    {
                        foreach (var answerData in ruleData.AnswerDataList)
                        {
                            if (!string.IsNullOrEmpty(answerData.String))
                            {
                                if (!string.IsNullOrEmpty(resultString))
                                {
                                    resultString += ", ";
                                }

                                resultString += answerLanguageList.Single(x => x.AnswerItemId == answerData.AnswerItemId).Question + ": " + answerData.String;
                            }

                            if (answerData.Int > 0)
                            {
                                if (!string.IsNullOrEmpty(resultString))
                                {
                                    resultString += ", ";
                                }

                                resultString += answerLanguageList.Single(x => x.AnswerItemId == answerData.AnswerItemId).Question + ": " + answerData.Int;
                            }

                            if (answerData.ResultId == (int)TypeOfResult.Ok || answerData.ResultId == (int)TypeOfResult.Fail)
                            {
                                if (!string.IsNullOrEmpty(answerDataString))
                                {
                                    answerDataString += ",";
                                }

                                answerDataString += answerData.ResultId;
                            }
                        }
                    }

                    outcomeData.ResultText = resultString;

                    var match = dbContext.IndicatorOutcomeList.SingleOrDefault(x => x.IndicatorItemId == outcomeData.IndicatorItemId && (x.ResultString1 == answerDataString || x.ResultString2 == answerDataString));

                    if (match != null)
                    {
                        outcomeData.IndicatorOutcomeItemId = match.Id;
                    }

                    dbContext.OutcomeData.Add(outcomeData);

                    result.Data.OutcomeData.Add(new OutcomeData
                    {
                        Id = outcomeData.Id,
                        IndicatorItemId = outcomeData.IndicatorItemId,
                        DeclarationTestItemId = outcomeData.DeclarationTestItemId,
                        AllDone = outcomeData.AllDone
                    });
                }

                var dbItem = dbContext.DeclarationList.Include(x => x.DeclarationTestItem).Single(x => x.Id == declarationItemId);

                dbItem.DeclarationTestItem.StatusCount = testGroupItemList.Count(x => x.AllDone);

                dbItem.DeclarationTestItem.SupplierAndVersionId = declarationTestItem.SupplierAndVersionId == 1 ? null : declarationTestItem.SupplierAndVersionId;
                dbItem.DeclarationTestItem.SupplierAndVersionOther = declarationTestItem.SupplierAndVersionOther;
                dbItem.DeclarationTestItem.DescriptionInText = declarationTestItem.DescriptionInText;
                dbItem.DeclarationTestItem.Image1Id = declarationTestItem.Image1Id;
                dbItem.DeclarationTestItem.Image2Id = declarationTestItem.Image2Id;

                if (dbItem.DeclarationTestItem.SupplierAndVersionId != null && dbItem.DeclarationTestItem.SupplierAndVersionId > 0 && !string.IsNullOrEmpty(dbItem.DeclarationTestItem.DescriptionInText) && dbItem.DeclarationTestItem.Image1Id != null && dbItem.DeclarationTestItem.Image2Id != null)
                {
                    dbItem.DeclarationTestItem.StatusCount++;
                    result.Data.Step1Done = true;
                }

                dbContext.SaveChanges();

                result.Data.StausCount = dbItem.DeclarationTestItem.StatusCount;
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

        public ApiResult SendIn(Guid id)
        {
            var result = new ApiResult();

            try
            {
                var dbItem = dbContext.DeclarationList.Include(x => x.DeclarationTestItem).ThenInclude(x => x.OutcomeDataList).SingleOrDefault(x => x.Id == id);

                if (dbItem == null)
                {
                    throw new InvalidOperationException(localizer["Declaration with id: {0} doesn't exist.", id]);
                }

                dbItem.DeclarationTestItem.FinishedStatusId = dbItem.DeclarationTestItem.OutcomeDataList.All(x => x.ResultId == 1) ? 1 : 2;
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

        public ApiResult HaveMachine(Guid id, bool haveMachine)
        {
            var result = new ApiResult();

            try
            {
                var dbItem = dbContext.DeclarationList.Include(x => x.DeclarationTestItem).SingleOrDefault(x => x.Id == id);

                if (dbItem == null)
                {
                    throw new InvalidOperationException(localizer["Declaration with id: {0} doesn't exist.", id]);
                }

                if (dbItem.StatusId == (int)DeclarationStatus.Sent || dbItem.StatusId == (int)DeclarationStatus.Created)
                {
                    dbItem.StatusId = (int)DeclarationStatus.Started;
                }

                dbItem.DeclarationTestItem.HaveMachine = haveMachine;

                if (haveMachine == false)
                {
                    dbItem.StatusId = (int)DeclarationStatus.SentIn;
                    dbItem.SentInDate = DateTime.Now;
                }

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

            if (answerData.ResultId == (int)TypeOfResult.Ok || answerData.ResultId == (int)TypeOfResult.Fail)
            {
                if (answerItem.LinkedParentFailedId != Guid.Empty)
                {
                    var item = ruleData.AnswerDataList.Single(x => x.AnswerItemId == answerItem.LinkedParentFailedId);

                    item.ResultId = answerData.ResultId;

                    UpdateParent(ruleData, item);
                }
            }
        }

        private TypeOfResult GetResultId(AnswerData answerData, RuleData ruleData)
        {
            var answerItem = dbContext.AnswerList.Include(x => x.TypeOfAnswer).AsNoTracking().Single(x => x.Id == answerData.AnswerItemId);

            if (answerItem.LinkedParentFailedId != Guid.Empty)
            {
                var parentFailed = ruleData.AnswerDataList.Single(x => x.AnswerItemId == answerItem.LinkedParentFailedId);

                if (parentFailed.ResultId == (int)TypeOfResult.Ok)
                {
                    answerData.String = string.Empty;
                    answerData.Int = null;
                    answerData.Bool = null;
                    answerData.ImageId = null;

                    return TypeOfResult.NotTestable;
                }

                if (parentFailed.ResultId == (int)TypeOfResult.NotTestable)
                {
                    answerData.String = string.Empty;
                    answerData.Int = null;
                    answerData.Bool = null;
                    answerData.ImageId = null;

                    return TypeOfResult.NotTestable;
                }
            }

            if (answerItem.LinkedParentCorrectId != Guid.Empty)
            {
                var parentCorrect = ruleData.AnswerDataList.Single(x => x.AnswerItemId == answerItem.LinkedParentCorrectId);

                if (parentCorrect.ResultId == (int)TypeOfResult.Fail)
                {
                    answerData.String = string.Empty;
                    answerData.Int = null;
                    answerData.Bool = null;
                    answerData.ImageId = null;

                    return TypeOfResult.NotTestable;
                }

                if (parentCorrect.ResultId == (int)TypeOfResult.NotTestable)
                {
                    answerData.String = string.Empty;
                    answerData.Int = null;
                    answerData.Bool = null;
                    answerData.ImageId = null;

                    return TypeOfResult.NotTestable;
                }
            }

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

                case (int)TypeOfAnswer.String when string.IsNullOrWhiteSpace(answerData.String):
                    return TypeOfResult.NotTested;

                case (int)TypeOfAnswer.String when !string.IsNullOrWhiteSpace(answerData.String):
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