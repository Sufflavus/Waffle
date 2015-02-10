using System;

using Tabby.Dal.Domain;
using Tabby.Dal.Repository;
using Tabby.Dal.Repository.Interfaces;

using Taddy.BusinessLogic.Models;


namespace Taddy.BusinessLogic.Processor
{
    public class UserProcessor : IUserProcessor
    {
        private readonly IUserRepository _repository;


        public UserProcessor()
        {
            _repository = new UserRepository();
        }


        public UserProcessor(IUserRepository repository)
        {
            _repository = repository;
        }


        public void LogIn(User user)
        {
            UserEntity entity = _repository.GetByName(user.Name);
            if (entity == null)
            {
                entity = new UserEntity { Name = user.Name };
            }
            entity.IsOnline = true;
            _repository.AddOrUpdate(entity);
            user.Id = entity.Id;
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
