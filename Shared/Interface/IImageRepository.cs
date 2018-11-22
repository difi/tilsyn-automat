using System;
using Difi.Sjalvdeklaration.Shared.Classes;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface IImageRepository
    {
        ApiResult Add(ImageItem imageItem);

        void SetCurrentUser(Guid parse);
    }
}