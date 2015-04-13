using System;

using Bijuu.BusinessLogic.Managers;
using Bijuu.Dal.Context;
using Bijuu.Dal.Domain;
using Bijuu.Dal.Repository;
using Bijuu.Dal.Repository.Interfaces;

using Ginger.Notifier;

using Microsoft.Practices.Unity;


namespace Bijuu.Service
{
    internal sealed class Bootstrapper : IDisposable
    {
        static Bootstrapper()
        {
            CreateContainer();
        }


        private static IUnityContainer Container { get; set; }


        public static T Resolve<T>(params ParameterOverride[] overrides)
        {
            return Container.Resolve<T>(overrides);
        }

        public static void Dispose()
        {
            Container.Dispose();
        }
        
        private static void CreateContainer()
        {
            Container = new UnityContainer();
            Container.RegisterType<Repository<BaseEntity>>();

            Container.RegisterType<IMessageManager, MessageManager>();
            Container.RegisterType<IUserManager, UserManager>();

            Container.RegisterType<INotificationService, NotificationService>();

            Container.RegisterType<IContext, NHibernateContext>();
            Container.RegisterType<IUserRepository, UserRepository>();
            Container.RegisterType<IMessageRepository, MessageRepository>();
        }


        void IDisposable.Dispose()
        {
            Dispose();
        }
    }
}
