using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace Difi.Sjalvdeklaration.Api.Base
{
    public class ApiControllerBase : ControllerBase
    {
        private readonly IBaseRepository baseRepository;
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ApiControllerBase(IBaseRepository baseRepository, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            this.baseRepository = baseRepository;
            this.configuration = configuration;
            this.httpContextAccessor = httpContextAccessor;
        }

        protected ApiResult HandleRequest()
        {
            if (Request.Headers["ApiKey"] != configuration["Api:Key"])
            {
                return new ApiResult { Succeeded = false, Exception = new Exception("Wrong ApiKey!") };
            }

            if (!configuration["Api:IpList"].Contains(httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString()))
            {
                return new ApiResult { Succeeded = false, Exception = new Exception("Wrong IP!") };
            };

            baseRepository.SetCurrentUser(Guid.Parse(Request.Headers["UserGuid"]));
            baseRepository.SetCurrentLang(Request.Headers["Lang"]);

            return null;
        }

        protected ApiResult<T> HandleRequest<T>()
        {
            if (Request.Headers["ApiKey"] != configuration["Api:Key"])
            {
                return new ApiResult<T> { Succeeded = false, Exception = new Exception("Access denied to API (incorrect or missing ApiKey).") };
            }

            if (!configuration["Api:IpList"].Contains(httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString()))
            {
                return new ApiResult<T> { Succeeded = false, Exception = new Exception($"Access denied to API (IP-address ({httpContextAccessor.HttpContext.Connection.RemoteIpAddress}) is not in the access list).") };
            };

            baseRepository.SetCurrentUser(Guid.Parse(Request.Headers["UserGuid"]));
            baseRepository.SetCurrentLang(Request.Headers["Lang"]);

            return null;
        }

        protected ApiResult<T> HandleRequestWithoutIpCheck<T>()
        {
            if (Request.Headers["ApiKey"] != configuration["Api:Key"])
            {
                return new ApiResult<T> { Succeeded = false, Exception = new Exception("Access denied to API (incorrect or missing ApiKey).") };
            }

            baseRepository.SetCurrentUser(Guid.Parse(Request.Headers["UserGuid"]));
            baseRepository.SetCurrentLang(Request.Headers["Lang"]);

            return null;
        }
    }
}