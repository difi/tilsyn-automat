using Difi.Sjalvdeklaration.Api.Base;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.Log;
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
    public class LogController : ApiControllerBase
    {
        private readonly ILogRepository logRepository;

        public LogController(ILogRepository logRepository, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(logRepository, configuration, httpContextAccessor)
        {
            this.logRepository = logRepository;
        }

        [HttpGet]
        [Route("Get/{id}")]
        public ApiResult<LogItem> Get(Guid id)
        {
            return HandleRequest<LogItem>() ?? logRepository.Get<LogItem>(id);
        }

        [HttpGet]
        [Route("GetByFilter/{fromDate}/{toDate}/{succeeded}")]
        public ApiResult<List<LogItem>> GetByFilter(long fromDate, long toDate, int succeeded)
        {
            var filterModel = new FilterModel
            {
                FromDate = new DateTime(fromDate),
                ToDate = new DateTime(toDate),
                Succeeded = succeeded,
            };

            return HandleRequest<List<LogItem>>() ?? logRepository.GetByFilter<List<LogItem>>(filterModel);
        }

        [HttpPost]
        [Route("Add")]
        public ApiResult Add(LogItem logItem)
        {
            return HandleRequest() ?? logRepository.Add(logItem);
        }
    }
}