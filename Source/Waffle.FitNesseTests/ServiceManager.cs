using System;
using System.ServiceModel.Web;

using Bijuu.BusinessLogic.Managers;
using Bijuu.Service;

using Waffle.FitNesseTests.Message;
using Waffle.FitNesseTests.User;

using dbfit;

using fit;


namespace Waffle.FitNesseTests
{
    public class ServiceManager : SqlServerTest
    {
        private const string BijuuHost = "http://localhost:8085/BijuuService";
        private readonly WebServiceHost _serviceInstance;


        public ServiceManager()
        {
            var messageManager = Bootstrapper.Resolve<IMessageManager>();
            var userManager = Bootstrapper.Resolve<IUserManager>();

            IRequestProcessor _processor = new RequestProcessor(messageManager, userManager);

            Uri[] host = { new Uri(BijuuHost) };
            _serviceInstance = new WebServiceHost(_processor, host);
        }


        public Fixture CheckMessage()
        {
            return Bootstrapper.Resolve<MessageChecker>();
        }


        public Fixture CheckUser()
        {
            return Bootstrapper.Resolve<UserChecker>();
        }


        public Fixture SendMessage()
        {
            return Bootstrapper.Resolve<SendMessage>();
        }


        public void StartService()
        {
            _serviceInstance.Open();
        }


        public void StopService()
        {
            _serviceInstance.Close();
        }


        public Fixture UserLogOut()
        {
            return Bootstrapper.Resolve<UserLogOut>();
        }


        public Fixture UserLogin()
        {
            return Bootstrapper.Resolve<UserLogin>();
        }
    }
}
