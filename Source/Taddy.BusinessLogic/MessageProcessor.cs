using System;
using System.Collections.Generic;
using System.Linq;

using Tabby.Dal.Domain;
using Tabby.Dal.Repository;


namespace Taddy.BusinessLogic
{
    public class MessageProcessor : IMessageProcessor
    {
        private readonly IUniversalRepository repository = new UniversalRepository();


        public List<Message> GetAllMessages()
        {
            return repository.GetAll<MessageEntity>()
                .Select(DalConverter.ToMessage)
                .ToList();
        }


        public int SendMessage(Message message)
        {
            MessageEntity messageEntity = DalConverter.ToMessageEntity(message);
            repository.AddOrUpdate(messageEntity);
            return message.Text.Length;
        }
    }
}
