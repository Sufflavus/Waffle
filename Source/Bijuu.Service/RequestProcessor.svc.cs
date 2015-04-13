using System;
using System.Collections.Generic;
using System.ServiceModel;

using Bijuu.BusinessLogic.Managers;
using Bijuu.Contracts;

using Ginger.Contracts;
using Ginger.Notifier;


namespace Bijuu.Service
{
    //https://www.safaribooksonline.com/library/view/programming-wcf-services/0596526997/ch04s02.html

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class RequestProcessor : IRequestProcessor, IDisposable
    {
        private readonly IMessageManager _messageManager;
        private readonly IUserManager _userManager;
        

        public RequestProcessor(IMessageManager messageManager, IUserManager userManager)
        {
            _messageManager = messageManager;
            _userManager = userManager;
        }


        private RequestProcessor()
        {
            _messageManager = Bootstrapper.Resolve<IMessageManager>();
            _userManager = Bootstrapper.Resolve<IUserManager>();
        }


        public void Dispose()
        {
            Bootstrapper.Dispose();
        }


        public List<MessageInfo> GetAllMessages()
        {
            return _messageManager.GetAllMessages();
        }


        public List<MessageInfo> GetNewMessages(Guid userId)
        {
            return _messageManager.GetNewMessages(userId);
        }


        public UserInfo LogIn(string userName)
        {
            return _userManager.LogIn(userName);
        }


        public void LogOut(UserInfo user)
        {
            _userManager.LogOut(user.Id);
        }


        public void SendMessage(MessageInfo message)
        {
            _messageManager.SendMessage(message);
        }
    }
}
