using Difi.Sjalvdeklaration.Api.Base;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Difi.Sjalvdeklaration.Api
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ImageController : ApiControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImageController(IImageRepository imageRepository, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(imageRepository, configuration, httpContextAccessor)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost]
        [Route("Add")]
        public ApiResult Add(ImageItem imageItem)
        {
            return HandleRequest() ?? imageRepository.Add(imageItem);
        }
    }
}