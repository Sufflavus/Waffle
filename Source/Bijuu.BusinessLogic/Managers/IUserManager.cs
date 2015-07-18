using System;
using System.Collections.Generic;

using Bijuu.Contracts;


namespace Bijuu.BusinessLogic.Managers
{
    public interface IUserManager
    {
        UserInfo GetUserByName(string userName);
        List<UserInfo> GetAllUsers();
        UserInfo LogIn(string userName);
        void LogOut(Guid userId);
    }
}
