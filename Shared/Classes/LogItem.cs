using Difi.Sjalvdeklaration.Shared.Extensions;
using System;
using System.Runtime.CompilerServices;

namespace Difi.Sjalvdeklaration.Shared.Classes
{
    public class LogItem
    {
        public LogItem(Guid userId, ApiResult apiResult = null, object callParameter1 = null, object callParameter2 = null, object resultString = null, [CallerMemberName] string callerFunctionName = null, [CallerFilePath] string callerFileName = null)
        {
            Id = Guid.NewGuid();
            Created = DateTime.Now;

            Function = callerFunctionName;

            if (callerFileName != null)
            {
                Class = callerFileName;

                if (callerFileName.Contains("\\"))
                {
                    Class = callerFileName.Remove(0, callerFileName.LastIndexOf('\\') + 1).Replace(".cs", "");
                }
            }

            UserId = userId;

            if (apiResult != null)
            {
                ResultSucceeded = apiResult.Succeeded;
                ResultId = apiResult.Id;
                ResultException = apiResult.Exception?.AsJsonString();
            }

            CallParameter1 = callParameter1?.AsJsonString();
            CallParameter2 = callParameter2?.AsJsonString();
            ResultString = resultString?.AsJsonString();
        }

        public LogItem()
        {
        }

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime Created { get; set; }

        public String Class { get; set; }

        public String Function { get; set; }

        public String CallParameter1 { get; set; }

        public String CallParameter2 { get; set; }

        public bool ResultSucceeded { get; set; }

        public Guid ResultId { get; set; }

        public String ResultString { get; set; }

        public String ResultException { get; set; }
    }
}