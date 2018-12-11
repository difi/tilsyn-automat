using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.Shared.Extensions;

namespace Difi.Sjalvdeklaration.Shared.Classes.Log
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
                    Class = callerFileName.Remove(0, callerFileName.LastIndexOf('\\') + 1)
                        .Replace(".cshtml", string.Empty)
                        .Replace(".cs", string.Empty)
                        .Replace("LogDecorator", string.Empty);
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

        [Display(Name = "User")]
        public Guid UserId { get; set; }

        [Display(Name = "Created date")]
        public DateTime Created { get; set; }

        [Display(Name = "Section")]
        public String Class { get; set; }

        [Display(Name = "Function")]
        public String Function { get; set; }

        [Display(Name = "Call parameter 1")]
        public String CallParameter1 { get; set; }

        [Display(Name = "Call parameter 2")]
        public String CallParameter2 { get; set; }

        [Display(Name = "Result succeeded")]
        public bool ResultSucceeded { get; set; }

        [Display(Name = "Result id")]
        public Guid ResultId { get; set; }

        [Display(Name = "Result text")]
        public String ResultString { get; set; }

        [Display(Name = "Result error")]
        public String ResultException { get; set; }

        [NotMapped]
        public UserItem UserItem { get; set; }
    }
}