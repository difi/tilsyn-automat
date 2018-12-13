using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Company;
using Difi.Sjalvdeklaration.Shared.Classes.Declaration;
using Difi.Sjalvdeklaration.Shared.Classes.Log;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Difi.Sjalvdeklaration.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogRepository logRepository;

        public LogController(ILogRepository logRepository)
        {
            this.logRepository = logRepository;
        }

        [HttpPost]
        [Route("Add")]
        public ApiResult Add(LogItem logItem)
        {
            return logRepository.Add(logItem);
        }

        [HttpGet]
        [Route("Get/{id}")]
        public ApiResult<LogItem> Get(Guid id)
        {
            return logRepository.Get<LogItem>(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public ApiResult<List<LogItem>> GetAll()
        {
            return logRepository.GetAll<List<LogItem>>();
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

            return logRepository.GetByFilter<List<LogItem>>(filterModel);
        }
    }
}