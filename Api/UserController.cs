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
        [Route("GetAllInternal")]
        public IEnumerable<UserItem> GetAllInternal()
        {
            return userRepository.GetAllInternal();
        }

        [HttpGet]
        [Route("Get/{id}")]
        public UserItem Get(Guid id)
        {
            return userRepository.Get(id);
        }

        [HttpGet]
        [Route("GetByToken/{token}")]
        public UserItem GetByToken(String token)
        {
            return userRepository.GetByToken(token);
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

        [HttpGet]
        [Route("Login/{token}/{socialSecurityNumber}")]
        public UserItem Login(string token, string socialSecurityNumber)
        {
            return userRepository.Login(token, socialSecurityNumber).Result;
        }
    }
}