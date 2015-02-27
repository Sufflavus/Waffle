using System;
using System.Collections.Generic;
using System.Linq;

using Bijuu.Contracts;

using Tabby.Dal.Domain;
using Tabby.Dal.Repository;
using Tabby.Dal.Repository.Interfaces;


namespace Bijuu.BusinessLogic.Managers
{
    public class MessageManager : IMessageManager
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;


        public MessageManager()
        {
            _messageRepository = new MessageRepository();
            _userRepository = new UserRepository();
        }


        public MessageManager(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
        }


        public List<MessageInfo> GetAllMessages()
        {
            return _messageRepository.GetAll()
                .Select(DalConverter.ToMessageInfo)
                .ToList();
        }


        public List<MessageInfo> GetNewMessages(Guid userId)
        {
            List<MessageEntity> newMessages = _messageRepository.Filter(x => x.SenderId != userId && x.RecipientId == userId && !x.IsDelivered);
            List<MessageInfo> result = newMessages.Select(DalConverter.ToMessageInfo).ToList();
            newMessages.ForEach(x =>
            {
                x.IsDelivered = true;
                _messageRepository.AddOrUpdate(x);
            });
            return result;
        }


        public int SendMessage(MessageInfo message)
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
