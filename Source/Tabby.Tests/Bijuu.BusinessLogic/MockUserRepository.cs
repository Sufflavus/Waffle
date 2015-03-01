using System;
using System.Collections.Generic;
using System.Linq;

using Tabby.Dal.Domain;
using Tabby.Dal.Repository.Interfaces;


namespace Waffle.Tests.Bijuu.BusinessLogic
{
    public class MockUserRepository : IUserRepository
    {
        public MockUserRepository()
        {
            Storage = new List<UserEntity>();
        }


        public List<UserEntity> Storage { get; private set; }


        public void AddOrUpdate(UserEntity entity)
        {
            UserEntity user = Storage.FirstOrDefault(x => x.Id == entity.Id);
            if (user != null)
            {
                Storage.Remove(entity);
            }
            Storage.Add(entity);
        }


        public List<UserEntity> Filter(Func<UserEntity, bool> condition)
        {
            return Storage.Where(condition).ToList();
        }


        public List<UserEntity> GetAll()
        {
            return Storage;
        }


        public UserEntity GetById(Guid id)
        {
            return Storage.FirstOrDefault(x => x.Id == id);
        }


        public UserEntity GetByName(string userName)
        {
            return Storage.FirstOrDefault(x => x.Name == userName);
        }
    }
}
