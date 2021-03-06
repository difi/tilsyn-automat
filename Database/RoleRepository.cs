﻿using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Difi.Sjalvdeklaration.Database.DbContext;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Z.EntityFramework.Plus;

namespace Difi.Sjalvdeklaration.Database
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext dbContext;

        public RoleRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SetCurrentUser(Guid parse)
        {
        }

        public void SetCurrentLang(string lang)
        {
        }

        public ApiResult<T> GetAll<T>() where T : List<RoleItem>
        {
            var result = new ApiResult<T>();

            try
            {
                var list = dbContext.RoleList.Include(x => x.UserList).OrderBy(x => x.Name).AsNoTracking().FromCache().ToList();

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