using System;
using System.Collections.Generic;
using System.Linq;

using Bijuu.Contracts;
using Bijuu.Dal.Domain;
using Bijuu.Dal.Repository.Interfaces;

using Ginger.Contracts;
using Ginger.Notifier;

using Microsoft.Practices.Unity;


namespace Bijuu.BusinessLogic.Managers
{
    public class UserManager : IUserManager
    {
        [Dependency]
        public INotificationSender NotificationSender { get; set; }

        [Dependency]
        public IUserRepository Repository { get; set; }


        public UserInfo GetUserByName(string userName)
        {
            UserEntity entity = Repository.GetByName(userName);

            if (entity == null)
            {
                return null;
            }

            return DalConverter.ToUserInfo(entity);
        }


        public List<UserInfo> GetAllUsers()
        {
            return Repository.GetAll()
                .Select(DalConverter.ToUserInfo)
                .ToList();
        }


        public UserInfo LogIn(string userName)
        {
            UserEntity entity = Repository.GetByName(userName);
            if (entity == null)
            {
                entity = new UserEntity { Name = userName };
            }
            entity.IsOnline = true;
            Repository.AddOrUpdate(entity);

            NotifyAboutUpdateUserState(entity);
            return DalConverter.ToUserInfo(entity);
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

            NotifyAboutUpdateUserState(entity);
        }


        private void NotifyAboutUpdateUserState(UserEntity entity)
        {
            UserRecord record = NotifierConverter.ToUserRecord(entity);
            NotificationSender.NotifyUpdateUserState(record);
        }
    }
}
