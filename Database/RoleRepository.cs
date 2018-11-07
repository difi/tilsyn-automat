using System;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Difi.Sjalvdeklaration.Database
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext dbContext;

        public RoleRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ApiResult<T> GetAll<T>() where T : IEnumerable<RoleItem>
        {
            var result = new ApiResult<T>();

            try
            {
                var list = dbContext.RoleList.AsNoTracking().OrderBy(x => x.Name);

                result.Data = (T)list;
                result.Succeeded = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
            }

            return result;
        }
    }
}