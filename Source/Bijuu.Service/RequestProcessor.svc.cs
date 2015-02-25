using System;
using System.Collections.Generic;

using Bijuu.Contracts;


namespace Bijuu.Service
{
    public class RequestProcessor : IRequestProcessor
    {
        public List<MessageInfo> GetAllMessages()
        {
            var message = new MessageInfo
            {
                Id = Guid.NewGuid(),
                Text = "text",
                IsDelivered = false,
                CreateDate = DateTime.Now,
                SenderId = Guid.NewGuid(),
                RecipientId = Guid.NewGuid()
            };
            return new List<MessageInfo> { message };
        }


        public List<MessageInfo> GetNewMessages(Guid userId)
        {
            var message = new MessageInfo
            {
                Id = Guid.NewGuid(),
                Text = "text",
                IsDelivered = false,
                CreateDate = DateTime.Now,
                SenderId = userId,
                RecipientId = Guid.NewGuid()
            };
            return new List<MessageInfo> { message };
        }


        public Guid LogIn(string userName)
        {
            return Guid.NewGuid();
        }


        public void LogOut(Guid userId)
        {
        }


        public void SendMessage(MessageInfo message)
        {
        }
    }
}
