using System;
using System.Collections.Generic;

using Bijuu.BusinessLogic.Managers;
using Bijuu.Contracts;


namespace Bijuu.Service
{
    public class RequestProcessor : IRequestProcessor, IDisposable
    {
        // TODO: multi-thread support

        private readonly IMessageManager _messageManager;
        private readonly IUserManager _userManager;


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
