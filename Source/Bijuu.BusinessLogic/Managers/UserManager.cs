using System;

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

            return new UserInfo
            {
                Id = entity.Id,
                Name = entity.Name
            };
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

            UserRecord record = NotifierConverter.ToUserRecord(entity);
            NotificationSender.NotifyUpdateUserState(record);

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
