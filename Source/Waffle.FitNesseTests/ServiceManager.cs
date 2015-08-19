using System;
using System.ServiceModel.Web;

using Bijuu.BusinessLogic.Managers;
using Bijuu.Service;

using dbfit;


namespace Waffle.FitNesseTests
{
    public class ServiceManager : SqlServerTest
    {
        private readonly WebServiceHost _serviceInstance;


        public ServiceManager()
        {
            var messageManager = Bootstrapper.Resolve<IMessageManager>();
            var userManager = Bootstrapper.Resolve<IUserManager>();

            IRequestProcessor _processor = new RequestProcessor(messageManager, userManager);

            Uri[] uris = { new Uri("http://localhost:8083/BijuuService") };
            _serviceInstance = new WebServiceHost(_processor, uris);
        }


        public void StartService()
        {
            _serviceInstance.Open();
        }


        public void StopService()
        {
            _serviceInstance.Close();
        }
    }
}
