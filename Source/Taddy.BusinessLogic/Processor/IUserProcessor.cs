using System;
using System.Collections.Generic;

using Taddy.BusinessLogic.Models;


namespace Taddy.BusinessLogic.Processor
{
    public interface IUserProcessor
    {
        List<User> GetOnlineUsers();
        User GetUserByName(string userName);
        void LogIn(User user);
        void LogOut(Guid userId);
    }
}
