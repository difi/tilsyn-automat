using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.Shared.Extensions;

namespace Difi.Sjalvdeklaration.Shared.Classes.Log
{
    public class LogItem
    {
        public LogItem(Stopwatch stopwatch, Guid userId, ApiResult apiResult = null, object callParameter1 = null, object callParameter2 = null, object resultString = null, [CallerMemberName] string callerFunctionName = null, [CallerFilePath] string callerFileName = null)
        {
            try
            {
                stopwatch.Stop();

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

                Time = stopwatch.ElapsedMilliseconds;
            }
            catch (Exception exception)
            {
                Id = Guid.NewGuid();
                Created = DateTime.Now;

                Function = "LogItem";
                Class = "LogItem";

                UserId = Guid.Empty;

                ResultSucceeded = false;
                ResultId = Guid.Empty;
                ResultException = exception.AsJsonString();

                Time = stopwatch.ElapsedMilliseconds;
            }
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
        public string Class { get; set; }

        [Display(Name = "Function")]
        public string Function { get; set; }

        [Display(Name = "Call parameter 1")]
        public string CallParameter1 { get; set; }

        [Display(Name = "Call parameter 2")]
        public string CallParameter2 { get; set; }

        [Display(Name = "Result succeeded")]
        public bool ResultSucceeded { get; set; }

        [Display(Name = "Result id")]
        public Guid ResultId { get; set; }

        [Display(Name = "Result text")]
        public string ResultString { get; set; }

        [Display(Name = "Result error")]
        public string ResultException { get; set; }

        [Display(Name = "Time")]
        public long Time { get; set; }

        [NotMapped]
        public UserItem UserItem { get; set; }
    }
}