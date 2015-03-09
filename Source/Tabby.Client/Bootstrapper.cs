using System;

using Bijuu.ServiceProvider;

using Microsoft.Practices.Unity;

using Tabby.Client.Checker;
using Tabby.Client.Command.Message;
using Tabby.Client.Command.User;
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
            //http://www.wiktorzychla.com/2011/11/unity-application-block-is-lightweight.html
            //http://weblogs.asp.net/podwysocki/ioc-and-unity-configuration-changes-for-the-better
            //https://msdn.microsoft.com/en-us/library/ff660914(v=pandp.20).aspx
            //https://www.youtube.com/watch?v=89hyTXa8aY8
            //https://www.youtube.com/watch?v=FuAhnqSDe-o
        }


        private static IUnityContainer Container { get; set; }

        /*public static void Initialize()
        {
            CreateContainer();
        }*/

        /*public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }*/


        public static T Resolve<T>(params ParameterOverride[] overrides)
        {
            return Container.Resolve<T>(overrides);
        }


        public void Dispose()
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

            //UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            //section.Configure(Container, "Core");
            //section.Containers["default"].Configure(Container);
            //Container.LoadConfiguration(section);
            //Container.RegisterInstance(new NLogLogger());
        }
    }
}
