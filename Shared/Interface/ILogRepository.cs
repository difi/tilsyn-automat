using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface ILogRepository
    {
        ApiResult Add(LogItem logItem);

        ApiResult<T> Get<T>(Guid id) where T : LogItem;

        ApiResult<T> GetAll<T>() where T : List<LogItem>;
    }
}