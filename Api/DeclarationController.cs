using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Rules;
using Difi.Sjalvdeklaration.Shared.Declaration;
using Microsoft.Extensions.Configuration;

namespace Difi.Sjalvdeklaration.Api
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DeclarationController : ControllerBase
    {
        private readonly IDeclarationRepository declarationRepository;
        private readonly IConfiguration configuration;

        public DeclarationController(IDeclarationRepository declarationRepository, IConfiguration configuration)
        {
            this.declarationRepository = declarationRepository;
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("Get/{id}")]
        public ApiResult<DeclarationItem> Get(Guid id)
        {
            if (!HandleRequest())
            {
                return new ApiResult<DeclarationItem> { Exception = new Exception("Wrong ApiKey!") };
            }

            return declarationRepository.Get<DeclarationItem>(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public ApiResult<List<DeclarationItem>> GetAll()
        {
            if (!HandleRequest())
            {
                return new ApiResult<List<DeclarationItem>> { Exception = new Exception("Wrong ApiKey!") };
            }

            return declarationRepository.GetAll<List<DeclarationItem>>();
        }

        [HttpGet]
        [Route("GetForCompany/{id}")]
        public ApiResult<List<DeclarationItem>> GetForCompany(Guid id)
        {
            if (!HandleRequest())
            {
                return new ApiResult<List<DeclarationItem>> { Exception = new Exception("Wrong ApiKey!") };
            }

            return declarationRepository.GetForCompany<List<DeclarationItem>>(id);
        }

        [HttpGet]
        [Route("GetByFilter/{fromDate}/{toDate}/{status}")]
        public ApiResult<List<DeclarationItem>> GetByFilter(long fromDate, long toDate, int status)
        {
            if (!HandleRequest())
            {
                return new ApiResult<List<DeclarationItem>> { Exception = new Exception("Wrong ApiKey!") };
            }

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
            if (!HandleRequest())
            {
                return new ApiResult<List<OutcomeData>> { Exception = new Exception("Wrong ApiKey!") };
            }

            return declarationRepository.GetOutcomeDataList<List<OutcomeData>>(id);
        }

        [HttpGet]
        [Route("SendIn/{id}/{companyId}")]
        public ApiResult SendIn(Guid id, Guid companyId)
        {
            if (!HandleRequest())
            {
                return new ApiResult { Exception = new Exception("Wrong ApiKey!") };
            }

            return declarationRepository.SendIn(id, companyId);
        }

        [HttpGet]
        [Route("HaveMachine/{id}/{companyId}/{haveMachine}")]
        public ApiResult HaveMachine(Guid id, Guid companyId, bool haveMachine)
        {
            if (!HandleRequest())
            {
                return new ApiResult { Exception = new Exception("Wrong ApiKey!") };
            }

            return declarationRepository.HaveMachine(id, companyId, haveMachine);
        }

        [HttpPost]
        [Route("Add")]
        public ApiResult Add(DeclarationItem declarationItem)
        {
            if (!HandleRequest())
            {
                return new ApiResult { Exception = new Exception("Wrong ApiKey!") };
            }

            return declarationRepository.Add(declarationItem);
        }

        [HttpPost]
        [Route("Update")]
        public ApiResult Update(DeclarationItem declarationItem)
        {
            if (!HandleRequest())
            {
                return new ApiResult { Exception = new Exception("Wrong ApiKey!") };
            }
            return declarationRepository.Update(declarationItem);
        }

        [HttpPost]
        [Route("Save")]
        public ApiResult<DeclarationSaveResult> Save(DeclarationSave declarationSave)
        {
            if (!HandleRequest())
            {
                return new ApiResult<DeclarationSaveResult> { Exception = new Exception("Wrong ApiKey!") };
            }

            return declarationRepository.Save<DeclarationSaveResult>(declarationSave.Id, declarationSave.CompanyId, declarationSave.DeclarationTestItem);
        }

        [HttpPost]
        [Route("AutoSave/{id}/{companyId}")]
        public ApiResult<DeclarationSaveResult> AutoSave(Guid id, Guid companyId, [FromBody]IDictionary<string, string> data, List<DeclarationIndicatorGroup> indicatorList)
        {
            Request.Headers.Add("ApiKey", configuration["Api:Key"]);

            HandleRequest();

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

        private bool HandleRequest()
        {
            if (Request.Headers["ApiKey"] != configuration["Api:Key"])
            {
                return false;
            }

            declarationRepository.SetCurrentUser(Guid.Parse(Request.Headers["UserGuid"]));
            declarationRepository.SetCurrentLang(Request.Headers["Lang"]);

            return true;
        }
    }
}