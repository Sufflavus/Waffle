using System;

using Bijuu.BusinessLogic.Managers;
using Bijuu.Service;

using fitlibrary;


namespace Waffle.FitNesseTests
{
    public class StartServer : DoFixture
    {
        //http://stackoverflow.com/questions/9997163/is-it-possible-to-instantiate-a-webservicehost-via-an-instance-of-the-sevice-typ
        private IRequestProcessor _processor;


        public StartServer()
        {
            var messageManager = Bootstrapper.Resolve<IMessageManager>();
            var userManager = Bootstrapper.Resolve<IUserManager>();

            _processor = new RequestProcessor(messageManager, userManager);
        }
    }
}
