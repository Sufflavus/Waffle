using System;
using System.Collections.Generic;
using System.Linq;

using Bijuu.Contracts;

using Microsoft.Practices.Unity;

using Tabby.Dal.Domain;
using Tabby.Dal.Repository.Interfaces;


namespace Bijuu.BusinessLogic.Managers
{
    public class MessageManager : IMessageManager
    {
        public MessageManager(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            MessageRepository = messageRepository;
            UserRepository = userRepository;
        }


        [Dependency]
        public IMessageRepository MessageRepository { get; set; }

        [Dependency]
        public IUserRepository UserRepository { get; set; }


        public List<MessageInfo> GetAllMessages()
        {
            return MessageRepository.GetAll()
                .Select(DalConverter.ToMessageInfo)
                .ToList();
        }


        public List<MessageInfo> GetNewMessages(Guid userId)
        {
            List<MessageEntity> newMessages = MessageRepository.Filter(x => x.SenderId != userId && x.RecipientId == userId && !x.IsDelivered);
            List<MessageInfo> result = newMessages.Select(DalConverter.ToMessageInfo).ToList();
            newMessages.ForEach(x =>
            {
                x.IsDelivered = true;
                MessageRepository.AddOrUpdate(x);
            });
            return result;
        }


        public int SendMessage(MessageInfo message)
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
