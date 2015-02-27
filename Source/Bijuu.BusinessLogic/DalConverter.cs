using System;

using Bijuu.Contracts;

using Tabby.Dal.Domain;


namespace Bijuu.BusinessLogic
{
    public static class DalConverter
    {
        public static MessageEntity ToMessageEntity(MessageInfo message)
        {
            if (message == null)
            {
                throw new ArgumentException("Message can't be null");
            }

            return new MessageEntity { Text = message.Text, SenderId = message.SenderId };
        }


        public static MessageInfo ToMessageInfo(MessageEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity can't be null");
            }

            return new MessageInfo
            {
                Id = entity.Id,
                Text = entity.Text,
                CreateDate = entity.CreateDate.Value,
                SenderId = entity.SenderId,
                Sender = ToUserInfo(entity.Sender),
                RecipientId = entity.RecipientId,
                Recipient = ToUserInfo(entity.Recipient),
                IsDelivered = entity.IsDelivered
            };
        }


        public static UserInfo ToUserInfo(UserEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("User can't be null");
            }

            return new UserInfo { Id = entity.Id, Name = entity.Name, IsOnline = entity.IsOnline };
        }
    }
}
