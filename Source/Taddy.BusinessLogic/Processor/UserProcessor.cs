using System;

using Bijuu.Contracts;
using Bijuu.ServiceProvider;

using Microsoft.Practices.Unity;

using Taddy.BusinessLogic.Models;


namespace Taddy.BusinessLogic.Processor
{
    public class UserProcessor : IUserProcessor
    {
        [Dependency]
        public IBijuuServiceClient ServiceClient { get; set; }


        public User GetUserByName(string userName)
        {
            throw new NotImplementedException();
        }


        public void LogIn(User user)
        {
            UserInfo userInfo = ServiceClient.LogIn(user.Name);
            user.Id = userInfo.Id;
        }


        public void LogOut(Guid userId)
        {
            ServiceClient.LogOut(userId);
        }
    }
}
