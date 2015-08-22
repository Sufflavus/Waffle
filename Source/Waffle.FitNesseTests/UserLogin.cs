using System;
using System.Linq;

using Bijuu.Contracts;

using fit;


namespace Waffle.FitNesseTests
{
    /*public class UserLogin : ColumnFixture
    {
        public string Username { get; set; }


        public Guid UserId()
        {
            return SetUpTestEnvironment.UserManager.LogIn(Username).Id;
        }
    }


    public class UserLoginOut : ColumnFixture
    {
        public Guid UserId { get; set; }

        public string Username { get; set; }


        public void LogOut()
        {
            SetUpTestEnvironment.UserManager.LogOut(UserId);
        }
    }


    public class UserDetails : ColumnFixture
    {
        public bool IsOnline
        {
            get { return GetUser().IsOnline; }
        }

        public Guid UserId { get; set; }

        public string UserName
        {
            get { return GetUser().Name; }
        }


        private UserInfo GetUser()
        {
            return SetUpTestEnvironment.UserManager.GetAllUsers().FirstOrDefault(x => x.Id == UserId);
        }
    }*/
}
