using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Microsoft.Extensions.Configuration;

namespace Difi.Sjalvdeklaration.Api
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IConfiguration configuration;

        public UserController(IUserRepository userRepository, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
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
        [Route("GetAll")]
        public ApiResult<List<UserItem>> GetAll()
        {
            HandleRequest();

            return userRepository.GetAll<List<UserItem>>();
        }

        [HttpGet]
        [Route("Login/{token}/{socialSecurityNumber}")]
        public ApiResult<UserItem> Login(string token, long socialSecurityNumber)
        {
            HandleRequest();

            return userRepository.Login<UserItem>(token, socialSecurityNumber);
        }

        [HttpGet]
        [Route("Remove/{id}")]
        public ApiResult Remove(string id)
        {
            HandleRequest();

            return userRepository.Remove(Guid.Parse(id));
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

        private void HandleRequest()
        {
            if (Request.Headers["ApiKey"] != configuration["Api:Key"])
            {
                throw new Exception("Wrong ApiKey!");
            }

            userRepository.SetCurrentUser(Guid.Parse(Request.Headers["UserGuid"]));
        }
    }
}