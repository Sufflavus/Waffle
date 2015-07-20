using System;
using System.Collections.Generic;
using System.Linq;

using Bijuu.Contracts;
using Bijuu.ServiceProvider;

using Microsoft.Practices.Unity;

using Taddy.BusinessLogic.Converters;
using Taddy.BusinessLogic.Models;


namespace Taddy.BusinessLogic.Processor
{
    public class MessageProcessor : IMessageProcessor
    {
        [Dependency]
        public IBijuuServiceClient ServiceClient { get; set; }


        public List<Message> GetAllMessages()
        {
            return ServiceClient.GetAllMessages()
                .Select(DalConverter.ToMessage)
                .ToList();
        }


        public List<Message> GetNewMessages(Guid userId)
        {
            return ServiceClient.GetNewMessages(userId)
                .Select(DalConverter.ToMessage)
                .ToList();
        }


        public List<Message> GetUserMessages(Guid userId)
        {
            return ServiceClient.GetUserMessages(userId)
                .Select(DalConverter.ToMessage)
                .ToList();
        }


        public int SendMessage(Message message)
        {
            return ServiceClient.SendMessage(message.Text, message.SenderId);
        }


        public int SendMessageToUser(Message message)
        {
            MessageInfo messageInfo = DalConverter.ToMessageInfo(message);
            return ServiceClient.SendMessageToUser(messageInfo);
        }
    }
}
