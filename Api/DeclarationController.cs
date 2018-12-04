using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration.Data;

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
        public ApiResult Save(DeclarationSave declarationSave)
        {
            HandleRequest();

            return declarationRepository.Save(declarationSave.Id, declarationSave.OutcomeDataList, declarationSave.DeclarationTestItem);
        }

        [HttpGet]
        [Route("SendIn/{id}")]
        public ApiResult SendIn(Guid id)
        {
            HandleRequest();

            return declarationRepository.SendIn(id);
        }

        [HttpGet]
        [Route("HaveMachine/{id}/{haveMachine}")]
        public ApiResult HaveMachine(Guid id, bool haveMachine)
        {
            HandleRequest();

            return declarationRepository.HaveMachine(id, haveMachine);
        }

        private void HandleRequest()
        {
            declarationRepository.SetCurrentUser(Guid.Parse(Request.Headers["UserGuid"]));
        }
    }
}