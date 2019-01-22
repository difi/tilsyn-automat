using System;
using Difi.Sjalvdeklaration.Database.DbContext;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;

namespace Difi.Sjalvdeklaration.Database
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ImageRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ApiResult Add(ImageItem imageItem)
        {
            var result = new ApiResult();

            try
            {
                imageItem.Id = Guid.NewGuid();

                dbContext.ImageList.Add(imageItem);
                dbContext.SaveChanges();

                result.Succeeded = true;
                result.Id = imageItem.Id;
            }
            catch (Exception exception)
            {
                result.Succeeded = false;
                result.Exception = exception;
            }

            return result;
        }

        public void SetCurrentUser(Guid parse)
        {
            
        }

        public void SetCurrentLang(string lang)
        {
         
        }
    }
}