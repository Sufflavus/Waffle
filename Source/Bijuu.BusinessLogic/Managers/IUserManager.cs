using System;

using Bijuu.Contracts;


namespace Bijuu.BusinessLogic.Managers
{
    public interface IUserManager
    {
        UserInfo LogIn(string userName);
        void LogOut(Guid userId);
    }
}
