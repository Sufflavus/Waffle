using System;

using Taddy.BusinessLogic.Models;


namespace Taddy.BusinessLogic.Processor
{
    public interface IUserProcessor
    {
        void LogIn(User user);
        void LogOut(Guid userId);
    }
}
