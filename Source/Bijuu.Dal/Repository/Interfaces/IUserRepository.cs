using System;

using Bijuu.Dal.Domain;


namespace Bijuu.Dal.Repository.Interfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        UserEntity GetByName(string userName);
    }
}
