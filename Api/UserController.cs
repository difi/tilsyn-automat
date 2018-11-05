using System;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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

        [HttpGet]
        [Route("Login/{token}/{socialSecurityNumber}")]
        public UserItem Login(string token, string socialSecurityNumber)
        {
            return userRepository.Login(token, socialSecurityNumber).Result;
        }

        [HttpPost]
        [Route("Add")]
        public bool Add(UserAddItem addUserObject)
        {
            return userRepository.Add(addUserObject.UserItem, addUserObject.RoleList).Result;
        }

        [HttpPost]
        [Route("Update")]
        public bool Update(UserAddItem addUserObject)
        {
            return userRepository.Update(addUserObject.UserItem, addUserObject.RoleList).Result;
        }
    }
}