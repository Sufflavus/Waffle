using System;
using System.Collections.Generic;
using System.Linq;

using Tabby.Dal.Domain;
using Tabby.Dal.Repository;


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


        public List<Message> GetNewMessages()
        {
            /*return _repository.Filter<MessageEntity>(x=>x.CreateDate >= DateTime.Now.AddDays(-1))
                .Select(DalConverter.ToMessage)
                .ToList();*/

            throw new NotImplementedException();
        }


        public int SendMessage(Message message)
        {
            MessageEntity messageEntity = DalConverter.ToMessageEntity(message);
            _repository.AddOrUpdate(messageEntity);
            return message.Text.Length;
        }
    }
}
