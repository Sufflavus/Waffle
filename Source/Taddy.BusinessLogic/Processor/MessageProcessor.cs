using System;
using System.Collections.Generic;
using System.Linq;

using Tabby.Dal.Domain;
using Tabby.Dal.Repository;
using Tabby.Dal.Repository.Interfaces;

using Taddy.BusinessLogic.Models;


namespace Taddy.BusinessLogic.Processor
{
    public class MessageProcessor : IMessageProcessor
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;


        public MessageProcessor()
        {
            _messageRepository = new MessageRepository();
            _userRepository = new UserRepository();
        }


        public MessageProcessor(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
        }


        public List<Message> GetAllMessages()
        {
            return _messageRepository.GetAll()
                .Select(DalConverter.ToMessage)
                .ToList();
        }


        public List<Message> GetNewMessages(Guid userId)
        {
            List<MessageEntity> newMessages = _messageRepository.Filter(x => x.SenderId != userId && x.RecipientId == userId && !x.IsDelivered);
            List<Message> result = newMessages.Select(DalConverter.ToMessage).ToList();
            newMessages.ForEach(x =>
            {
                x.IsDelivered = true;
                _messageRepository.AddOrUpdate(x);
            });
            return result;
        }


        public int SendMessage(Message message)
        {
            List<UserEntity> recipients = _userRepository.Filter(x => x.Id != message.SenderId);
            recipients.ForEach(x =>
            {
                MessageEntity messageEntity = DalConverter.ToMessageEntity(message);
                messageEntity.RecipientId = x.Id;
                _messageRepository.AddOrUpdate(messageEntity);
            });

            return message.Text.Length;
        }
    }
}
