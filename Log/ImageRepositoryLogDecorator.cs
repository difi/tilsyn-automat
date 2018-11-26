using System;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Extensions;
using Difi.Sjalvdeklaration.Shared.Interface;

namespace Difi.Sjalvdeklaration.Log
{
    public class ImageRepositoryLogDecorator : IImageRepository
    {
        private Guid userId;
        private readonly IImageRepository inner;
        private readonly ILogRepository logRepository;

        public ImageRepositoryLogDecorator(IImageRepository inner, ILogRepository logRepository)
        {
            this.inner = inner;
            this.logRepository = logRepository;
        }

        public ApiResult Add(ImageItem imageItem)
        {
            var imageItemBefore = imageItem.DeepClone();

            var result = inner.Add(imageItemBefore);

            logRepository.Add(new LogItem(userId, result, imageItemBefore));

            return result;
        }

        public void SetCurrentUser(Guid id)
        {
            userId = id;
            inner.SetCurrentUser(id);
        }
    }
}