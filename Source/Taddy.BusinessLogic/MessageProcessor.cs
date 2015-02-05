using System;
using System.Collections.Generic;
using System.Linq;

using Tabby.Dal.Domain;
using Tabby.Dal.Repository;
using Tabby.Dal.Repository.Interfaces;

using Taddy.BusinessLogic.Models;


namespace Taddy.BusinessLogic
{
    public class MessageProcessor : IMessageProcessor
    {
        private readonly IMessageRepository _repository;


        public MessageProcessor()
        {
            _repository = new MessageRepository();
        }


        public MessageProcessor(IMessageRepository repository)
        {
            _repository = repository;
        }


        public List<Message> GetAllMessages()
        {
            return _repository.GetAll()
                .Select(DalConverter.ToMessage)
                .ToList();
        }


        public List<Message> GetNewMessages(Guid userId)
        {
            return _repository.Filter(x=>x.RecipientId == userId && !x.DeliveryDate.HasValue).Select(DalConverter.ToMessage).ToList();
        }


        public int SendMessage(Message message)
        {
            MessageEntity messageEntity = DalConverter.ToMessageEntity(message);
            _repository.AddOrUpdate(messageEntity);
            return message.Text.Length;
        }
    }
}
