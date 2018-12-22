using System;
using System.Diagnostics;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.Log;
using Difi.Sjalvdeklaration.Shared.Extensions;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.Extensions.Configuration;

namespace Difi.Sjalvdeklaration.Log
{
    public class ImageRepositoryLogDecorator : IImageRepository
    {
        private Guid userId;
        private readonly IImageRepository inner;
        private readonly ILogRepository logRepository;
        private readonly IConfiguration configuration;
        private readonly Stopwatch stopwatch = new Stopwatch();

        private bool LogGetSucceeded => Convert.ToBoolean(configuration["Log:LogGetSucceeded"]);
        private bool LogChangeSucceeded => Convert.ToBoolean(configuration["Log:LogChangeSucceeded"]);
        private bool LogError => Convert.ToBoolean(configuration["Log:LogError"]);
        private int LogLongTime => Convert.ToInt32(configuration["Log:LogLongTime"]);

        public ImageRepositoryLogDecorator(IImageRepository inner, ILogRepository logRepository, IConfiguration configuration)
        {
            this.inner = inner;
            this.logRepository = logRepository;
            this.configuration = configuration;

            stopwatch.Start();
        }

        public ApiResult Add(ImageItem imageItem)
        {
            var imageItemBefore = imageItem.DeepClone();

            var result = inner.Add(imageItemBefore);

            if (!result.Succeeded && LogError || result.Succeeded && LogChangeSucceeded || stopwatch.ElapsedMilliseconds > LogLongTime)
            {
                logRepository.Add(new LogItem(stopwatch, userId, result, imageItemBefore));
            }

            return result;
        }

        public void SetCurrentUser(Guid id)
        {
            userId = id;
            inner.SetCurrentUser(id);
        }
    }
}