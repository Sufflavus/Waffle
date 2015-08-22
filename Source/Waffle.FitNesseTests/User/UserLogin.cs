using System;

using Bijuu.Contracts;
using Bijuu.ServiceProvider;

using Microsoft.Practices.Unity;

using fit;


namespace Waffle.FitNesseTests.User
{
    public class UserLogin : ColumnFixture
    {
        [Dependency]
        public IBijuuServiceClient BijuuServiceClient { get; set; }

        public Guid UserId { get; set; }
        public string UserName { get; set; }


        public void Login()
        {
            UserInfo user = BijuuServiceClient.LogIn(UserName);
            UserId = user.Id;
        }
    }
}
