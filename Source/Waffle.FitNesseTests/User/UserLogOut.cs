using System;

using Bijuu.ServiceProvider;

using Microsoft.Practices.Unity;

using fit;


namespace Waffle.FitNesseTests.User
{
    public class UserLogOut : ColumnFixture
    {
        [Dependency]
        public IBijuuServiceClient BijuuServiceClient { get; set; }

        public Guid UserId { get; set; }


        public void Login()
        {
            BijuuServiceClient.LogOut(UserId);
        }
    }
}
