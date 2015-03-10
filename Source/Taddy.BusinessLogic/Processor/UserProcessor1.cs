using System;

using Bijuu.Contracts;
using Bijuu.ServiceProvider;

using Microsoft.Practices.Unity;

using Taddy.BusinessLogic.Models;


namespace Taddy.BusinessLogic.Processor
{
    public class UserProcessor1 : IUserProcessor
    {
        [Dependency]
        public IBijuuServiceClient ServiceClient { get; set; }


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
