using System;

using Tabby.Dal.Domain;
using Tabby.Dal.Repository;


namespace Taddy.BusinessLogic
{
    public class MessageProcessor : IMessageProcessor
    {
        public int SendMessage(Message message)
        {
            MessageEntity messageEntity = DalAdapter.CreateMessageEntity(message);
            new Repository<MessageEntity>().Add(messageEntity);
            return message.Text.Length;
        }
    }
}
