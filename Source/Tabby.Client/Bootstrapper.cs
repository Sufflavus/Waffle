using System;
using System.Configuration;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

using Tabby.Client.Command.User;
using Tabby.Client.Logger;


namespace Tabby.Client
{
    public sealed class Bootstrapper : IDisposable
    {
        private static IUnityContainer Container { get; set; }


        static Bootstrapper()
        {
            CreateContainer();
            //http://www.wiktorzychla.com/2011/11/unity-application-block-is-lightweight.html
            //http://weblogs.asp.net/podwysocki/ioc-and-unity-configuration-changes-for-the-better
            //https://msdn.microsoft.com/en-us/library/ff660914(v=pandp.20).aspx
            //https://www.youtube.com/watch?v=89hyTXa8aY8
        }


        /*public static void Initialize()
        {
            CreateContainer();
        }*/


        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }


        public void Dispose()
        {
            Container.Dispose();
        }


        private static void CreateContainer()
        {
            Container = new UnityContainer();
            //Container.RegisterType<ILogger, NLogLogger>();
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(Container, "Core");
            Container.RegisterType<UserCommand>(new InjectionProperty("Logger"));
            //section.Containers["default"].Configure(Container);
            //Container.LoadConfiguration(section);
            //Container.RegisterInstance(new NLogLogger());
        }
    }
}
