using System;

using Tabby.Dal.Domain;

using Taddy.BusinessLogic.Models;


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
                CreateDate = entity.CreateDate.Value,
                SenderId = entity.SenderId,
                Sender = ToUser(entity.Sender)
            };
        }


        public static MessageEntity ToMessageEntity(Message message)
        {
            if (message == null)
            {
                throw new ArgumentException("Message can't be null");
            }

            return new MessageEntity { Text = message.Text, SenderId = message.SenderId };
        }


        public static User ToUser(UserEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Sender can't be null");
            }

            return new User { Id = entity.Id, Name = entity.Name };
        }


        public static UserEntity ToUserEntity(User user)
        {
            if (user == null)
            {
                throw new ArgumentException("Sender can't be null");
            }

            return new UserEntity { Name = user.Name };
        }
    }
}
