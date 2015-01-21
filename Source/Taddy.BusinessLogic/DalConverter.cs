using System;

using Tabby.Dal.Domain;


namespace Taddy.BusinessLogic
{
    public static class DalConverter
    {
        public static Message ToMessage(MessageEntity entity)
        {
            return new Message
            {
                Text = entity.Text,
                CreateDate = entity.CreateDate
            };
        }


        public static MessageEntity ToMessageEntity(Message message)
        {
            return new MessageEntity { Text = message.Text };
        }
    }
}
