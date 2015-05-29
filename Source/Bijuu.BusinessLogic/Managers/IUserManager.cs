using System;

using Bijuu.Contracts;


namespace Bijuu.BusinessLogic.Managers
{
    public interface IUserManager
    {
        UserInfo GetUserByName(string userName);
        UserInfo LogIn(string userName);
        void LogOut(Guid userId);
    }
}
