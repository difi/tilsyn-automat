using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Difi.Sjalvdeklaration.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        [Route("Get/{id}")]
        public ApiResult<UserItem> Get(Guid id)
        {
            HandleRequest();

            return userRepository.Get<UserItem>(id);
        }

        [HttpGet]
        [Route("GetByToken/{token}")]
        public ApiResult<UserItem> GetByToken(String token)
        {
            HandleRequest();

            return userRepository.GetByToken<UserItem>(token);
        }

        [HttpGet]
        [Route("GetAllInternal")]
        public ApiResult<List<UserItem>> GetAllInternal()
        {
            HandleRequest();

            return userRepository.GetAllInternal<List<UserItem>>();
        }

        [HttpGet]
        [Route("Login/{token}/{socialSecurityNumber}")]
        public ApiResult<UserItem> Login(string token, string socialSecurityNumber)
        {
            HandleRequest();

            return userRepository.Login<UserItem>(token, socialSecurityNumber);
        }

        [HttpPost]
        [Route("Add")]
        public ApiResult Add(UserAddItem addUserObject)
        {
            HandleRequest();

            return userRepository.Add(addUserObject.UserItem, addUserObject.RoleList);
        }

        [HttpPost]
        [Route("Update")]
        public ApiResult Update(UserAddItem addUserObject)
        {
            HandleRequest();

            return userRepository.Update(addUserObject.UserItem, addUserObject.RoleList);
        }

        [HttpGet]
        [Route("Remove/{id}")]
        public ApiResult Remove(string id)
        {
            HandleRequest();

            return userRepository.Remove(Guid.Parse(id));
        }

        private void HandleRequest()
        {
            userRepository.SetCurrentUser(Guid.Parse(Request.Headers["UserGuid"]));
        }
    }
}