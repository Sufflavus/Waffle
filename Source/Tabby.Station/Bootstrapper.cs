using System;

using Bijuu.ServiceProvider;

using Ginger.Notifier;

using Microsoft.Practices.Unity;

using Tabby.Station.ViewModels;

using Taddy.BusinessLogic;
using Taddy.BusinessLogic.Processor;


namespace Tabby.Station
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

            Container.RegisterType<LoginWindowViewModel>();

            Container.RegisterType<IMessageProcessor, MessageProcessor>();
            Container.RegisterType<IUserProcessor, UserProcessor>();
            Container.RegisterType<IBijuuServiceClient, BijuuServiceClient>();

            Container.RegisterType<INotificationReceiver, NotificationReceiver>();

            Container.RegisterType<NotificationReceiverWrapper>();
        }


        void IDisposable.Dispose()
        {
            Dispose();
        }
    }
}