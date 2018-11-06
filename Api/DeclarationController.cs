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
        public DeclarationItem Get(Guid id)
        {
            return declarationRepository.Get(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<DeclarationItem> GetAll()
        {
            return declarationRepository.GetAll();
        }

        [HttpPost]
        [Route("Add")]
        public bool Add(DeclarationItem declarationItem)
        {
            return declarationRepository.Add(declarationItem).Result;
        }

        [HttpPost]
        [Route("Update")]
        public bool Update(DeclarationItem declarationItem)
        {
            return declarationRepository.Update(declarationItem).Result;
        }

        [HttpGet]
        [Route("SendIn/{id}")]
        public bool SendIn(Guid id)
        {
            return declarationRepository.SendIn(id).Result;
        }
    }
}