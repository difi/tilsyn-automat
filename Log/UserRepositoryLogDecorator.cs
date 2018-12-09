﻿using System;
using System.Collections.Generic;
using Difi.Sjalvdeklaration.Shared.Classes;
using Difi.Sjalvdeklaration.Shared.Classes.User;
using Difi.Sjalvdeklaration.Shared.Extensions;
using Difi.Sjalvdeklaration.Shared.Interface;

namespace Difi.Sjalvdeklaration.Log
{
    public class UserRepositoryLogDecorator : IUserRepository
    {
        private Guid userId;
        private readonly IUserRepository inner;
        private readonly ILogRepository logRepository;

        public UserRepositoryLogDecorator(IUserRepository inner, ILogRepository logRepository)
        {
            this.inner = inner;
            this.logRepository = logRepository;
        }

        public ApiResult<T> GetAll<T>() where T : List<UserItem>
        {
            return inner.GetAll<T>();
        }

        public ApiResult<T> GetAllInternal<T>() where T : List<UserItem>
        {
            return inner.GetAllInternal<T>();
        }

        public void SetCurrentUser(Guid id)
        {
            userId = id;
            inner.SetCurrentUser(id);
        }

        public ApiResult<T> Get<T>(Guid id) where T : UserItem
        {
            return inner.Get<T>(id);
        }

        public ApiResult<T> GetByToken<T>(string token) where T : UserItem
        {
            return inner.GetByToken<T>(token);
        }

        public ApiResult<T> Login<T>(string token, string socialSecurityNumber) where T : UserItem
        {
            var result = inner.Login<T>(token, socialSecurityNumber);

            logRepository.Add(new LogItem(userId, result.GetApiResutlt(), token, socialSecurityNumber, result.Data));

            return result;
        }

        public ApiResult Add(UserItem userItem, List<RoleItem> roleList)
        {
            var userItemBefore = userItem.DeepClone();
            var roleListBefore = roleList.DeepClone();

            var result = inner.Add(userItem, roleList);

            logRepository.Add(new LogItem(userId, result, userItemBefore, roleListBefore));

            return result;
        }

        public ApiResult Update(UserItem userItem, List<RoleItem> roleList)
        {
            var userItemBefore = userItem.DeepClone();
            var roleListBefore = roleList.DeepClone();

            var result = inner.Update(userItem, roleList);

            logRepository.Add(new LogItem(userId, result, userItemBefore, roleListBefore));

            return result;
        }

        public ApiResult Remove(Guid id)
        {
            var result = inner.Remove(id);

            logRepository.Add(new LogItem(userId, result, id));

            return result;
        }
    }
}