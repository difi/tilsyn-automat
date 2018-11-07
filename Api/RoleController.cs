﻿using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Api
{
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public ApiResult<List<RoleItem>> GetAll()
        {
            return roleRepository.GetAll<List<RoleItem>>();
        }
    }
}