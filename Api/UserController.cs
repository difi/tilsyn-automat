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
            return userRepository.Get<UserItem>(id);
        }

        [HttpGet]
        [Route("GetByToken/{token}")]
        public ApiResult<UserItem> GetByToken(String token)
        {
            return userRepository.GetByToken<UserItem>(token);
        }

        [HttpGet]
        [Route("GetAllInternal")]
        public ApiResult<IEnumerable<UserItem>> GetAllInternal()
        {
            return userRepository.GetAllInternal<IEnumerable<UserItem>>();
        }

        [HttpGet]
        [Route("Login/{token}/{socialSecurityNumber}")]
        public ApiResult<UserItem> Login(string token, string socialSecurityNumber)
        {
            return userRepository.Login<UserItem>(token, socialSecurityNumber).Result;
        }

        [HttpPost]
        [Route("Add")]
        public ApiResult Add(UserAddItem addUserObject)
        {
            return userRepository.Add(addUserObject.UserItem, addUserObject.RoleList).Result;
        }

        [HttpPost]
        [Route("Update")]
        public ApiResult Update(UserAddItem addUserObject)
        {
            return userRepository.Update(addUserObject.UserItem, addUserObject.RoleList).Result;
        }

        [HttpGet]
        [Route("Remove/{id}")]
        public ApiResult Remove(string id)
        {
            return userRepository.Remove(Guid.Parse(id)).Result;
        }
    }
}