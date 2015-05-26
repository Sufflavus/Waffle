using System;

using Taddy.BusinessLogic.Models;


namespace Taddy.BusinessLogic.Processor
{
    public interface IUserProcessor
    {
        User GetUserByName(string userName);
        void LogIn(User user);
        void LogOut(Guid userId);
    }
}
