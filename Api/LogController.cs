using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.Log;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Difi.Sjalvdeklaration.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogRepository logRepository;
        private readonly IConfiguration configuration;

        public LogController(ILogRepository logRepository, IConfiguration configuration)
        {
            this.logRepository = logRepository;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("Add")]
        public ApiResult Add(LogItem logItem)
        {
            HandleRequest();

            return logRepository.Add(logItem);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public ApiResult<LogItem> Get(Guid id)
        {
            HandleRequest();

            return logRepository.Get<LogItem>(id);
        }

        [HttpGet]
        [Route("GetByFilter/{fromDate}/{toDate}/{succeeded}")]
        public ApiResult<List<LogItem>> GetByFilter(long fromDate, long toDate, int succeeded)
        {
            HandleRequest();

            var filterModel = new FilterModel
            {
                FromDate = new DateTime(fromDate),
                ToDate = new DateTime(toDate),
                Succeeded = succeeded,
            };

            return logRepository.GetByFilter<List<LogItem>>(filterModel);
        }

        private void HandleRequest()
        {
            if (Request.Headers["ApiKey"] != configuration["Api:Key"])
            {
                throw new Exception("Wrong ApiKey!");
            }
        }
    }
}