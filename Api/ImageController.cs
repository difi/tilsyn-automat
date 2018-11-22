using Difi.Sjalvdeklaration.Shared.Classes;
using Microsoft.AspNetCore.Mvc;
using System;
using Difi.Sjalvdeklaration.Shared.Interface;

namespace Difi.Sjalvdeklaration.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost]
        [Route("Add")]
        public ApiResult Add(ImageItem imageItem)
        {
            HandleRequest();

            return imageRepository.Add(imageItem);
        }

        private void HandleRequest()
        {
            imageRepository.SetCurrentUser(Guid.Parse(Request.Headers["UserGuid"]));
        }
    }
}