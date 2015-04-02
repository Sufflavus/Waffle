﻿using System;

using Bijuu.Contracts;
using Bijuu.Dal.Domain;
using Bijuu.Dal.Repository.Interfaces;

using Microsoft.Practices.Unity;


namespace Bijuu.BusinessLogic.Managers
{
    public class UserManager : IUserManager
    {
        [Dependency]
        public IUserRepository Repository { get; set; }


        public UserInfo LogIn(string userName)
        {
            UserEntity entity = Repository.GetByName(userName);
            if (entity == null)
            {
                entity = new UserEntity { Name = userName };
            }
            entity.IsOnline = true;
            Repository.AddOrUpdate(entity);

            return new UserInfo
            {
                Id = entity.Id,
                IsOnline = entity.IsOnline,
                Name = entity.Name
            };
        }


        public void LogOut(Guid userId)
        {
            UserEntity entity = Repository.GetById(userId);
            if (entity == null)
            {
                throw new ArgumentException("Sender is not exists");
            }
            entity.IsOnline = false;
            Repository.AddOrUpdate(entity);
        }
    }
}
