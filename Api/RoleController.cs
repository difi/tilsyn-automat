using System;
using System.Collections.Generic;
using System.Text;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Difi.Sjalvdeklaration.Api
{
    [Route("api/[controller]")]
    public class RoleController: ControllerBase
    {
        private readonly IRoleRepository roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<RoleItem> GetAll()
        {
            return roleRepository.GetAll();
        }
    }
}
