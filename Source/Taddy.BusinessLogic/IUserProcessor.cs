using System;


namespace Taddy.BusinessLogic
{
    public interface IUserProcessor
    {
        void LogIn(User user);
        void LogOut(Guid userId);
    }
}
