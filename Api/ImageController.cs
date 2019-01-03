using Difi.Sjalvdeklaration.Shared.Classes;
using Microsoft.AspNetCore.Mvc;
using System;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.Extensions.Configuration;

namespace Difi.Sjalvdeklaration.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository imageRepository;
        private readonly IConfiguration configuration;

        public ImageController(IImageRepository imageRepository, IConfiguration configuration)
        {
            this.imageRepository = imageRepository;
            this.configuration = configuration;
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
            if (Request.Headers["ApiKey"] != configuration["Api:Key"])
            {
                throw new Exception("Wrong ApiKey!");
            }

            imageRepository.SetCurrentUser(Guid.Parse(Request.Headers["UserGuid"]));
        }
    }
}