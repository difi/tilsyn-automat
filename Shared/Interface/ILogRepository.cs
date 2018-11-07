using Difi.Sjalvdeklaration.Shared.Classes;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface ILogRepository
    {
        bool Add(LogItem logItem);
    }
}