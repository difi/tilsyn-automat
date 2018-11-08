using System;
using System.Runtime.CompilerServices;

namespace Difi.Sjalvdeklaration.Shared.Classes
{
    public class LogItem
    {
        public LogItem(ApiResult apiResult = null, object callParameter1 = null, object callParameter2 = null, object resultString = null, [CallerMemberName] string callerFunctionName = null)
        {
            Id = Guid.NewGuid();
            Created = DateTime.Now;

            Function = callerFunctionName;

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

        public String Function { get; set; }

        public DateTime Created { get; set; }

        public bool ResultSucceeded { get; set; }

        public Guid ResultId { get; set; }

        public String ResultException { get; set; }

        public String CallParameter1 { get; set; }

        public String CallParameter2 { get; set; }

        public String ResultString { get; set; }
    }
}