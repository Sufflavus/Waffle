using System;
using System.Linq;

using Bijuu.Dal.Domain;
using Bijuu.Dal.Repository.Interfaces;


namespace Bijuu.Dal.Repository
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        public UserEntity GetByName(string userName)
        {
            return Filter(x => x.Name == userName).FirstOrDefault();
        }
    }
}
