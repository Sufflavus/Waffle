using System;

using Bijuu.Dal.Domain;

using Ginger.Contracts;


namespace Bijuu.BusinessLogic
{
    public class NotifierConverter
    {
        public static MessageRecord ToMessageRecord(MessageEntity message)
        {
            if (message == null)
            {
                throw new ArgumentException("Message can't be null");
            }

            return new MessageRecord
            {
                Text = message.Text,
                SenderId = message.SenderId,
                Sender = message.Sender == null ? null : ToUserRecord(message.Sender),
                CreateDate = message.CreateDate,
                RecipientId = message.RecipientId,
                Recipient = message.Recipient == null ? null : ToUserRecord(message.Recipient)
            };
        }


        public static UserRecord ToUserRecord(UserEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("User can't be null");
            }

            return new UserRecord { Id = entity.Id, Name = entity.Name, IsOnline = entity.IsOnline };
        }
    }
}
