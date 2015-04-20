using System;
using System.Collections.Generic;
using System.Linq;

using Bijuu.Contracts;
using Bijuu.Dal.Domain;
using Bijuu.Dal.Repository.Interfaces;

using Ginger.Contracts;
using Ginger.Notifier;

using Microsoft.Practices.Unity;


namespace Bijuu.BusinessLogic.Managers
{
    public class MessageManager : IMessageManager
    {
        [Dependency]
        public IMessageRepository MessageRepository { get; set; }

        [Dependency]
        public INotificationSender NotificationSender { get; set; }

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

                MessageRecord record = NotifierConverter.ToMessageRecord(messageEntity);
                NotificationSender.NotifySendMessage(record);
            });

            return message.Text.Length;
        }
    }
}
