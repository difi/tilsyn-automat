using System;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface.Base;

namespace Difi.Sjalvdeklaration.Shared.Interface
{
    public interface IImageRepository : IBaseRepository
    {
        ApiResult Add(ImageItem imageItem);
    }
}