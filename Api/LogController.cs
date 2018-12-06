using Difi.Sjalvdeklaration.Shared.Classes;
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
    }
}