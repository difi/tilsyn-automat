using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;
using Difi.Sjalvdeklaration.Shared.Declaration;

namespace Difi.Sjalvdeklaration.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeclarationController : ControllerBase

    {
        private readonly IDeclarationRepository declarationRepository;

        public DeclarationController(IDeclarationRepository declarationRepository)
        {
            this.declarationRepository = declarationRepository;
        }

        [HttpGet]
        [Route("Get/{id}")]
        public ApiResult<DeclarationItem> Get(Guid id)
        {
            HandleRequest();

            return declarationRepository.Get<DeclarationItem>(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public ApiResult<List<DeclarationItem>> GetAll()
        {
            HandleRequest();

            return declarationRepository.GetAll<List<DeclarationItem>>();
        }

        [HttpGet]
        [Route("GetForCompany/{id}")]
        public ApiResult<List<DeclarationItem>> GetForCompany(Guid id)
        {
            HandleRequest();

            return declarationRepository.GetForCompany<List<DeclarationItem>>(id);
        }

        [HttpGet]
        [Route("GetByFilter/{fromDate}/{toDate}/{status}")]
        public ApiResult<List<DeclarationItem>> GetByFilter(long fromDate, long toDate, int status)
        {
            HandleRequest();

            var filterModel = new FilterModel
            {
                FromDate = new DateTime(fromDate),
                ToDate = new DateTime(toDate),
                Status = status,
            };

            return declarationRepository.GetByFilter<List<DeclarationItem>>(filterModel);
        }

        [HttpGet]
        [Route("GetOutcomeDataList/{id}")]
        public ApiResult<List<OutcomeData>> GetOutcomeDataList(Guid id)
        {
            HandleRequest();

            return declarationRepository.GetOutcomeDataList<List<OutcomeData>>(id);
        }

        [HttpPost]
        [Route("Add")]
        public ApiResult Add(DeclarationItem declarationItem)
        {
            HandleRequest();

            return declarationRepository.Add(declarationItem);
        }

        [HttpPost]
        [Route("Update")]
        public ApiResult Update(DeclarationItem declarationItem)
        {
            HandleRequest();

            return declarationRepository.Update(declarationItem);
        }

        [HttpPost]
        [Route("Save")]
        public ApiResult<DeclarationSaveResult> Save(DeclarationSave declarationSave)
        {
            HandleRequest();

            return declarationRepository.Save<DeclarationSaveResult>(declarationSave.Id, declarationSave.CompanyId, declarationSave.DeclarationTestItem);
        }

        [HttpGet]
        [Route("SendIn/{id}/{companyId}")]
        public ApiResult SendIn(Guid id, Guid companyId)
        {
            HandleRequest();

            return declarationRepository.SendIn(id, companyId);
        }

        [HttpGet]
        [Route("HaveMachine/{id}/{companyId}/{haveMachine}")]
        public ApiResult HaveMachine(Guid id, Guid companyId, bool haveMachine)
        {
            HandleRequest();

            return declarationRepository.HaveMachine(id, companyId, haveMachine);
        }

        [HttpPost]
        [Route("AutoSave/{id}/{companyId}")]
        public ApiResult<DeclarationSaveResult> AutoSave(Guid id, Guid companyId, [FromBody]IDictionary<string, string> data, List<DeclarationIndicatorGroup> indicatorList)
        {
            var declarationItem = declarationRepository.Get<DeclarationItem>(id).Data;
            var declarationTestItem = new DeclarationTestHelper().CreateDeclarationTestItem(data, id, declarationItem.IndicatorList);

            var result = Save(new DeclarationSave
            {
                Id = id,
                CompanyId = companyId,
                DeclarationTestItem = declarationTestItem
            });

            return result;
        }

        private void HandleRequest()
        {
            declarationRepository.SetCurrentUser(Guid.Parse(Request.Headers["UserGuid"]));
        }
    }
}