using System;
using System.Collections.Generic;
using System.Linq;

using Bijuu.ServiceProvider;

using Taddy.BusinessLogic.Models;


namespace Taddy.BusinessLogic.Processor
{
    public class MessageProcessor1 : IMessageProcessor
    {
        private readonly IBijuuServiceClient _serviceClient;


        public MessageProcessor1()
        {
            _serviceClient = new BijuuServiceClient();
        }


        public MessageProcessor1(IBijuuServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }


        public List<Message> GetAllMessages()
        {
            return _serviceClient.GetAllMessages()
                .Select(DalConverter.ToMessage)
                .ToList();
        }


        public List<Message> GetNewMessages(Guid userId)
        {
            return _serviceClient.GetNewMessages(userId)
                .Select(DalConverter.ToMessage)
                .ToList();
        }


        public int SendMessage(Message message)
        {
            return _serviceClient.SendMessage(message.Text, message.SenderId);
        }
    }
}
