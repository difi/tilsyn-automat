using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Newtonsoft.Json;

namespace Difi.Sjalvdeklaration.Shared.Extensions
{
    public static class ObjectExtensions
    {
        public static StringContent AsJsonStringContent(this object x) => new StringContent(JsonConvert.SerializeObject(x, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }), Encoding.UTF8, "application/json");

        public static string AsJsonString(this object x) => JsonConvert.SerializeObject(x, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

        public static T DeepClone<T>(this T currentObject)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, currentObject);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}