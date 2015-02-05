using System;

using Tabby.Dal.Domain;


namespace Tabby.Dal.Repository.Interfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        UserEntity GetByName(string userName);
    }
}
