using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Microsoft.Extensions.Configuration;

namespace Difi.Sjalvdeklaration.Api
{
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository roleRepository;
        private readonly IConfiguration configuration;

        public RoleController(IRoleRepository roleRepository, IConfiguration configuration)
        {
            this.roleRepository = roleRepository;
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("GetAll")]
        public ApiResult<List<RoleItem>> GetAll()
        {
            HandleRequest();

            return roleRepository.GetAll<List<RoleItem>>();
        }

        private void HandleRequest()
        {
            if (Request.Headers["ApiKey"] != configuration["Api:Key"])
            {
                throw new Exception("Wrong ApiKey!");
            }

            roleRepository.SetCurrentUser(Guid.Parse(Request.Headers["UserGuid"]));
        }
    }
}