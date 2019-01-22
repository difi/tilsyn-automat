using Difi.Sjalvdeklaration.Api.Base;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Api
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class RoleController : ApiControllerBase
    {
        private readonly IRoleRepository roleRepository;

        public RoleController(IRoleRepository roleRepository, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(roleRepository, configuration, httpContextAccessor)
        {
            this.roleRepository = roleRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public ApiResult<List<RoleItem>> GetAll()
        {
            return HandleRequest<List<RoleItem>>() ?? roleRepository.GetAll<List<RoleItem>>();
        }
    }
}