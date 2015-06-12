using System;

using Ginger.Contracts;

using Taddy.BusinessLogic.Models;


namespace Tabby.Terminal.Converters
{
    public sealed class NotifierConverter
    {
        public static Message ToMessage(MessageRecord record)
        {
            if (record == null)
            {
                return null;
            }

            return new Message
            {
                SenderId = record.SenderId,
                Sender = ToUser(record.Sender),
                Text = record.Text,
                CreateDate = record.CreateDate.Value
            };
        }


        public static User ToUser(UserRecord record)
        {
            if (record == null)
            {
                return null;
            }

            return new User { Id = record.Id, Name = record.Name };
        }
    }
}
