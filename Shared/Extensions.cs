using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Difi.Sjalvdeklaration.Shared
{
    public static class Extensions
    {
        public static StringContent AsJsonStringContent(this object x) => new StringContent(JsonConvert.SerializeObject(x), Encoding.UTF8, "application/json");

        public static string AsJsonString(this object x) => JsonConvert.SerializeObject(x, Formatting.Indented, new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore});

        public static string AsBase64(this string plainText) => Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
    }
}