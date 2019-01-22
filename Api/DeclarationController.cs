using Difi.Sjalvdeklaration.Api.Base;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;
using Difi.Sjalvdeklaration.Shared.Declaration;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Api
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DeclarationController : ApiControllerBase
    {
        private readonly IDeclarationRepository declarationRepository;
        private readonly IConfiguration configuration;

        public DeclarationController(IDeclarationRepository declarationRepository, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(declarationRepository, configuration, httpContextAccessor)
        {
            this.declarationRepository = declarationRepository;
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("Get/{id}")]
        public ApiResult<DeclarationItem> Get(Guid id)
        {
            return HandleRequest<DeclarationItem>() ?? declarationRepository.Get<DeclarationItem>(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public ApiResult<List<DeclarationItem>> GetAll()
        {
            return HandleRequest<List<DeclarationItem>>() ?? declarationRepository.GetAll<List<DeclarationItem>>();
        }

        [HttpGet]
        [Route("GetForCompany/{id}")]
        public ApiResult<List<DeclarationItem>> GetForCompany(Guid id)
        {
            return HandleRequest<List<DeclarationItem>>() ?? declarationRepository.GetForCompany<List<DeclarationItem>>(id);
        }

        [HttpGet]
        [Route("GetByFilter/{fromDate}/{toDate}/{status}")]
        public ApiResult<List<DeclarationItem>> GetByFilter(long fromDate, long toDate, int status)
        {
            var filterModel = new FilterModel
            {
                FromDate = new DateTime(fromDate),
                ToDate = new DateTime(toDate),
                Status = status,
            };

            return HandleRequest<List<DeclarationItem>>() ?? declarationRepository.GetByFilter<List<DeclarationItem>>(filterModel);
        }

        [HttpGet]
        [Route("GetOutcomeDataList/{id}")]
        public ApiResult<List<OutcomeData>> GetOutcomeDataList(Guid id)
        {
            return HandleRequest<List<OutcomeData>>() ?? declarationRepository.GetOutcomeDataList<List<OutcomeData>>(id);
        }

        [HttpGet]
        [Route("SendIn/{id}/{companyId}")]
        public ApiResult SendIn(Guid id, Guid companyId)
        {
            return HandleRequest() ?? declarationRepository.SendIn(id, companyId);
        }

        [HttpGet]
        [Route("HaveMachine/{id}/{companyId}/{haveMachine}")]
        public ApiResult HaveMachine(Guid id, Guid companyId, bool haveMachine)
        {
            return HandleRequest() ?? declarationRepository.HaveMachine(id, companyId, haveMachine);
        }

        [HttpPost]
        [Route("Add")]
        public ApiResult Add(DeclarationItem declarationItem)
        {
            return HandleRequest() ?? declarationRepository.Add(declarationItem);
        }

        [HttpPost]
        [Route("Update")]
        public ApiResult Update(DeclarationItem declarationItem)
        {
            return HandleRequest() ?? declarationRepository.Update(declarationItem);
        }

        [HttpPost]
        [Route("Save")]
        public ApiResult<DeclarationSaveResult> Save(DeclarationSave declarationSave)
        {
            return HandleRequest<DeclarationSaveResult>() ?? declarationRepository.Save<DeclarationSaveResult>(declarationSave.Id, declarationSave.CompanyId, declarationSave.DeclarationTestItem);
        }

        [HttpPost]
        [Route("AutoSave/{id}/{companyId}")]
        public ApiResult<DeclarationSaveResult> AutoSave(Guid id, Guid companyId, [FromBody]IDictionary<string, string> data, List<DeclarationIndicatorGroup> indicatorList)
        {
            var declarationItem = declarationRepository.Get<DeclarationItem>(id).Data;
            var declarationTestItem = new DeclarationTestHelper().CreateDeclarationTestItem(data, id, declarationItem.IndicatorList);

            return declarationRepository.Save<DeclarationSaveResult>(id, companyId, declarationTestItem);
        }
    }
}