using System;

using Bijuu.ServiceProvider;

using Microsoft.Practices.Unity;

using Tabby.Dal.Repository;
using Tabby.Dal.Repository.Interfaces;
using Tabby.Terminal.Checker;
using Tabby.Terminal.Command.MessageModule;
using Tabby.Terminal.Command.UserModule;
using Tabby.Terminal.Logger;

using Taddy.BusinessLogic.Processor;


namespace Tabby.Terminal
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

            Container.RegisterType<ILogger, UiNlogLogger>();
            Container.RegisterType<IMessageProcessor, MessageProcessor>();
            Container.RegisterType<IUserProcessor, UserProcessor>();
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
