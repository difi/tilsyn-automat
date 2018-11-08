using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Difi.Sjalvdeklaration.Shared.Extensions
{
    public static class ObjectExtensions
    {
        public static StringContent AsJsonStringContent(this object x) => new StringContent(JsonConvert.SerializeObject(x), Encoding.UTF8, "application/json");

        public static string AsJsonString(this object x) => JsonConvert.SerializeObject(x, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
    }
}