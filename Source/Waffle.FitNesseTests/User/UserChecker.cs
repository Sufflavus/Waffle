using System;
using System.Linq;

using Bijuu.Contracts;
using Bijuu.ServiceProvider;

using Microsoft.Practices.Unity;

using fit;


namespace Waffle.FitNesseTests.User
{
    public class UserChecker : ColumnFixture
    {
        [Dependency]
        public IBijuuServiceClient BijuuServiceClient { get; set; }

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
            return BijuuServiceClient.GetUsers().FirstOrDefault(x => x.Id == UserId);
        }
    }
}
