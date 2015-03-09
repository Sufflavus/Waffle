using System;
using System.Linq;

using Tabby.Dal.Context;
using Tabby.Dal.Domain;
using Tabby.Dal.Repository.Interfaces;


namespace Tabby.Dal.Repository
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        public UserRepository(IContext context) : base(context)
        {
        }


        public UserEntity GetByName(string userName)
        {
            return Filter(x => x.Name == userName).FirstOrDefault();
        }
    }
}
