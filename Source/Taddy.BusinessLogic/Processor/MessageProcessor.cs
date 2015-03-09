using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Practices.Unity;

using Tabby.Dal.Domain;
using Tabby.Dal.Repository.Interfaces;

using Taddy.BusinessLogic.Models;


namespace Taddy.BusinessLogic.Processor
{
    public class MessageProcessor : IMessageProcessor
    {
        public MessageProcessor(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            MessageRepository = messageRepository;
            UserRepository = userRepository;
        }


        [Dependency]
        public IMessageRepository MessageRepository { get; set; }

        [Dependency]
        public IUserRepository UserRepository { get; set; }


        public List<Message> GetAllMessages()
        {
            return MessageRepository.GetAll()
                .Select(DalConverter.ToMessage)
                .ToList();
        }


        public List<Message> GetNewMessages(Guid userId)
        {
            List<MessageEntity> newMessages = MessageRepository.Filter(x => x.SenderId != userId && x.RecipientId == userId && !x.IsDelivered);
            List<Message> result = newMessages.Select(DalConverter.ToMessage).ToList();
            newMessages.ForEach(x =>
            {
                x.IsDelivered = true;
                MessageRepository.AddOrUpdate(x);
            });
            return result;
        }


        public int SendMessage(Message message)
        {
            List<UserEntity> recipients = UserRepository.Filter(x => x.Id != message.SenderId);
            recipients.ForEach(x =>
            {
                MessageEntity messageEntity = DalConverter.ToMessageEntity(message);
                messageEntity.RecipientId = x.Id;
                MessageRepository.AddOrUpdate(messageEntity);
            });

            return message.Text.Length;
        }
    }
}
