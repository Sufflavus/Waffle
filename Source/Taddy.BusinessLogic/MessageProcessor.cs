using System;
using System.Collections.Generic;

using Tabby.Dal.Domain;
using Tabby.Dal.Repository;


namespace Taddy.BusinessLogic
{
    public class MessageProcessor : IMessageProcessor
    {
        public List<Message> GetAllMessages()
        {
            throw new NotImplementedException();
        }


        public int SendMessage(Message message)
        {
            MessageEntity messageEntity = DalConverter.ToMessageEntity(message);
            new UniversalRepository().AddOrUpdate(messageEntity);
            return message.Text.Length;
        }
    }
}
