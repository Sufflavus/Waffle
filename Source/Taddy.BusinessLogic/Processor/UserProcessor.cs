using System;

using Microsoft.Practices.Unity;

using Tabby.Dal.Domain;
using Tabby.Dal.Repository.Interfaces;

using Taddy.BusinessLogic.Models;


namespace Taddy.BusinessLogic.Processor
{
    public class UserProcessor : IUserProcessor
    {
        public UserProcessor(IUserRepository repository)
        {
            Repository = repository;
        }


        [Dependency]
        public IUserRepository Repository { get; set; }


        public void LogIn(User user)
        {
            UserEntity entity = Repository.GetByName(user.Name);
            if (entity == null)
            {
                entity = new UserEntity { Name = user.Name };
            }
            entity.IsOnline = true;
            Repository.AddOrUpdate(entity);
            user.Id = entity.Id;
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
