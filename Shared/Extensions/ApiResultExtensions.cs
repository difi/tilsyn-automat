using Difi.Sjalvdeklaration.Shared.Classes;

namespace Difi.Sjalvdeklaration.Shared.Extensions
{
    public static class ApiResultExtensions
    {
        public static ApiResult GetApiResutlt<T>(this ApiResult<T> result) where T : UserItem
        {
            return new ApiResult
            {
                Succeeded = result.Succeeded,
                Exception = result.Exception,
                Id = result.Id
            };
        }
    }
}