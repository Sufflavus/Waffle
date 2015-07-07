using System;
using System.Collections.Generic;

using Bijuu.Contracts;
using Bijuu.ServiceProvider;

using Microsoft.Practices.Unity;

using Taddy.BusinessLogic.Converters;
using Taddy.BusinessLogic.Models;

using System.Linq;


namespace Taddy.BusinessLogic.Processor
{
    public class UserProcessor : IUserProcessor
    {
        [Dependency]
        public IBijuuServiceClient ServiceClient { get; set; }


        public List<User> GetOnlineUsers()
        {
            List<UserInfo> users = ServiceClient.GetUsers();
            var result = users.Where(x => x.IsOnline)
                .Select(DalConverter.ToUser)
                .ToList();

            return result;
        }


        public User GetUserByName(string userName)
        {
            UserInfo userInfo = ServiceClient.GetUserByName(userName);
            return DalConverter.ToUser(userInfo);
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
