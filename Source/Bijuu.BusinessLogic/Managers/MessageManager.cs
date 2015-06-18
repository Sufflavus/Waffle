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
                message.RecipientId = x.Id;
                MessageEntity messageEntity = DoSendMessageToUser(message);
                NotifyAboutSendMessage(messageEntity);
            });

            return message.Text.Length;
        }


        public int SendMessageToUser(MessageInfo message)
        {
            MessageEntity messageEntity = DoSendMessageToUser(message);
            NotifyAboutSendMessage(messageEntity);
            return message.Text.Length;
        }


        private MessageEntity DoSendMessageToUser(MessageInfo message)
        {
            MessageEntity messageEntity = DalConverter.ToMessageEntity(message);
            MessageRepository.AddOrUpdate(messageEntity);
            messageEntity = MessageRepository.GetById(messageEntity.Id);
            return messageEntity;
        }


        private void NotifyAboutSendMessage(MessageEntity messageEntity)
        {
            MessageRecord record = NotifierConverter.ToMessageRecord(messageEntity);
            NotificationSender.NotifySendMessage(record);
        }
    }
}
