using System.Threading.Tasks;
using Difi.Sjalvdeklaration.Shared.Classes;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface ILogRepository
    {
        Task<bool> Add(LogItem logItem);
    }
}