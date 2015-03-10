using System;

using Bijuu.ServiceProvider;

using Microsoft.Practices.Unity;

using Tabby.Client.Checker;
using Tabby.Client.Command.MessageModule;
using Tabby.Client.Command.UserModule;
using Tabby.Client.Logger;
using Tabby.Dal.Repository;
using Tabby.Dal.Repository.Interfaces;

using Taddy.BusinessLogic.Processor;


namespace Tabby.Client
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
            Container.RegisterType<Chatter>();
            Container.RegisterType<MessageChecker>();
            Container.RegisterType<UserCommand>();
            Container.RegisterType<MessageCommand>();

            Container.RegisterType<ILogger, NLogLogger>();
            Container.RegisterType<IMessageProcessor, MessageProcessor1>();
            Container.RegisterType<IUserProcessor, UserProcessor1>();
            Container.RegisterType<IBijuuServiceClient, BijuuServiceClient>();
            Container.RegisterType<IUserRepository, UserRepository>();
            Container.RegisterType<IMessageRepository, MessageRepository>();
        }


        void IDisposable.Dispose()
        {
            Dispose();
        }
    }
}
