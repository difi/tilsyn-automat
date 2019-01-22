using Difi.Sjalvdeklaration.Api.Base;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.User;
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
    public class UserController : ApiControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(userRepository, configuration, httpContextAccessor)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        [Route("Get/{id}")]
        public ApiResult<UserItem> Get(Guid id)
        {
            return HandleRequest<UserItem>() ?? userRepository.Get<UserItem>(id);
        }

        [HttpGet]
        [Route("GetByToken/{token}")]
        public ApiResult<UserItem> GetByToken(string token)
        {
            return HandleRequest<UserItem>() ?? userRepository.GetByToken<UserItem>(token);
        }

        [HttpGet]
        [Route("GetAllInternal")]
        public ApiResult<List<UserItem>> GetAllInternal()
        {
            return HandleRequest<List<UserItem>>() ?? userRepository.GetAllInternal<List<UserItem>>();
        }

        [HttpGet]
        [Route("GetAll")]
        public ApiResult<List<UserItem>> GetAll()
        {
            return HandleRequest<List<UserItem>>() ?? userRepository.GetAll<List<UserItem>>();
        }

        [HttpGet]
        [Route("Login/{token}/{socialSecurityNumber}")]
        public ApiResult<UserItem> Login(string token, long socialSecurityNumber)
        {
            return HandleRequest<UserItem>() ?? userRepository.Login<UserItem>(token, socialSecurityNumber);
        }

        [HttpGet]
        [Route("Remove/{id}")]
        public ApiResult Remove(string id)
        {
            return HandleRequest() ?? userRepository.Remove(Guid.Parse(id));
        }

        [HttpPost]
        [Route("Add")]
        public ApiResult Add(UserAddItem addUserObject)
        {
            return HandleRequest() ?? userRepository.Add(addUserObject.UserItem, addUserObject.RoleList);
        }

        [HttpPost]
        [Route("Update")]
        public ApiResult Update(UserAddItem addUserObject)
        {
            return HandleRequest() ?? userRepository.Update(addUserObject.UserItem, addUserObject.RoleList);
        }
    }
}