using System;

namespace Difi.Sjalvdeklaration.Shared.Classes
{
    public class ApiResult
    {
        public bool Succeeded { get; set; }

        public Guid Id { get; set; }

        public Exception Exception { get; set; }
    }
}