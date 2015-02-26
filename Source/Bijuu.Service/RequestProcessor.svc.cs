using System;
using System.Collections.Generic;

using Bijuu.Contracts;


namespace Bijuu.Service
{
    public class RequestProcessor : IRequestProcessor
    {
        public List<MessageInfo> GetAllMessages()
        {
            Guid recipientId = Guid.NewGuid();
            Guid senderId = Guid.NewGuid();
            var message = new MessageInfo
            {
                Id = Guid.NewGuid(),
                Text = "text",
                IsDelivered = false,
                CreateDate = DateTime.Now,
                SenderId = senderId,
                Sender = new UserInfo
                {
                    Id = recipientId,
                    IsOnline = true,
                    Name = "Bijuu"
                },
                RecipientId = recipientId,
                Recipient = new UserInfo
                {
                    Id = recipientId,
                    IsOnline = true,
                    Name = "Tabby"
                }
            };
            return new List<MessageInfo> { message };
        }


        public List<MessageInfo> GetNewMessages(Guid userId)
        {
            Guid recipientId = Guid.NewGuid();
            var message = new MessageInfo
            {
                Id = Guid.NewGuid(),
                Text = "text",
                IsDelivered = false,
                CreateDate = DateTime.Now,
                SenderId = userId,
                Sender = new UserInfo
                {
                    Id = userId,
                    IsOnline = true,
                    Name = "Tabby"
                },
                RecipientId = recipientId,
                Recipient = new UserInfo
                {
                    Id = recipientId,
                    IsOnline = true,
                    Name = "Bijuu"
                }
            };
            return new List<MessageInfo> { message };
        }


        public UserInfo LogIn(string userName)
        {
            return new UserInfo { Id = Guid.NewGuid(), IsOnline = true, Name = "Bijuu" };
        }


        public void LogOut(UserInfo user)
        {
        }


        public void SendMessage(MessageInfo message)
        {
        }
    }
}
