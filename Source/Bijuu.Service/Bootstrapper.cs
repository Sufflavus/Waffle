using System;

using Bijuu.BusinessLogic.Managers;

using Microsoft.Practices.Unity;

using Tabby.Dal.Context;
using Tabby.Dal.Domain;
using Tabby.Dal.Repository;
using Tabby.Dal.Repository.Interfaces;


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
