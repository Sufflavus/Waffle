using System;
using System.Collections.Generic;

using Bijuu.BusinessLogic.Managers;
using Bijuu.Contracts;


namespace Bijuu.Service
{
    public class RequestProcessor : IRequestProcessor
    {
        private readonly IMessageManager _messageManager = new MessageManager();
        private readonly IUserManager _userManager = new UserManager();


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
