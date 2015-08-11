using System;

using Bijuu.BusinessLogic.Managers;
using Bijuu.Dal.Context;
using Bijuu.Dal.Repository;

using fit;


namespace Waffle.FitNesseTests
{
    public class SetUpTestEnvironment : Fixture
    {
        internal static IUserManager UserManager;


        public SetUpTestEnvironment()
        {
            UserManager = new UserManager
            {
                NotificationSender = new MockNotificationSender(),
                Repository = new UserRepository
                {
                    Context = new NHibernateContext()
                }
            };
        }
    }
}
