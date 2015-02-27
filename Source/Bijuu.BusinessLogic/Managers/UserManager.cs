using System;

using Bijuu.Contracts;

using Tabby.Dal.Domain;
using Tabby.Dal.Repository;
using Tabby.Dal.Repository.Interfaces;


namespace Bijuu.BusinessLogic.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _repository;


        public UserManager()
        {
            _repository = new UserRepository();
        }


        public UserManager(IUserRepository repository)
        {
            _repository = repository;
        }


        public UserInfo LogIn(string userName)
        {
            UserEntity entity = _repository.GetByName(userName);
            if (entity == null)
            {
                entity = new UserEntity { Name = userName };
            }
            entity.IsOnline = true;
            _repository.AddOrUpdate(entity);
            return new UserInfo
            {
                Id = entity.Id,
                IsOnline = entity.IsOnline,
                Name = entity.Name
            };
        }


        public void LogOut(Guid userId)
        {
            UserEntity entity = _repository.GetById(userId);
            if (entity == null)
            {
                throw new ArgumentException("Sender is not exists");
            }
            entity.IsOnline = false;
            _repository.AddOrUpdate(entity);
        }
    }
}
