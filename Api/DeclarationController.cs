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
            return declarationRepository.Get<DeclarationItem>(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public ApiResult<IEnumerable<DeclarationItem>> GetAll()
        {
            return declarationRepository.GetAll<IEnumerable<DeclarationItem>>();
        }

        [HttpPost]
        [Route("Add")]
        public ApiResult Add(DeclarationItem declarationItem)
        {
            return declarationRepository.Add(declarationItem).Result;
        }

        [HttpPost]
        [Route("Update")]
        public ApiResult Update(DeclarationItem declarationItem)
        {
            return declarationRepository.Update(declarationItem).Result;
        }

        [HttpGet]
        [Route("SendIn/{id}")]
        public ApiResult SendIn(Guid id)
        {
            return declarationRepository.SendIn(id).Result;
        }
    }
}