using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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

        [HttpGet]
        [Route("SendIn/{id}")]
        public ApiResult SendIn(Guid id)
        {
            HandleRequest();

            return declarationRepository.SendIn(id);
        }

        private void HandleRequest()
        {
            declarationRepository.SetCurrentUser(Guid.Parse(Request.Headers["UserGuid"]));
        }
    }
}