using System;

using Tabby.Dal.Domain;


namespace Taddy.BusinessLogic
{
    public static class DalConverter
    {
        public static Message ToMessage(MessageEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity can't be null");
            }

            return new Message
            {
                Text = entity.Text,
                CreateDate = entity.CreateDate.Value
            };
        }


        public static MessageEntity ToMessageEntity(Message message)
        {
            if (message == null)
            {
                throw new ArgumentException("Message can't be null");
            }

            return new MessageEntity { Text = message.Text };
        }
    }
}
