using System;
using System.Text;

namespace Difi.Sjalvdeklaration.Shared.Extensions
{
    public static class StringExtensions
    {
        public static string AsBase64(this string plainText) => Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
    }
}