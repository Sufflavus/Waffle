using System;

using Bijuu.Contracts;

using Taddy.BusinessLogic.Models;


namespace Taddy.BusinessLogic
{
    public static class DalConverter
    {
        public static Message ToMessage(MessageInfo messageInfo)
        {
            if (messageInfo == null)
            {
                throw new ArgumentException("Message can't be null");
            }

            return new Message
            {
                Text = messageInfo.Text,
                CreateDate = messageInfo.CreateDate.Value,
                SenderId = messageInfo.SenderId,
                Sender = ToUser(messageInfo.Sender)
            };
        }


        public static User ToUser(UserInfo userInfo)
        {
            if (userInfo == null)
            {
                throw new ArgumentException("User can't be null");
            }

            return new User { Id = userInfo.Id, Name = userInfo.Name };
        }
    }
}
