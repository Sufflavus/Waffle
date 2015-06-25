using System;

using Ginger.Contracts;

using Taddy.BusinessLogic.Models;


namespace Taddy.BusinessLogic.Converters
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
                RecipientId = record.RecipientId.Value,
                Recipient = ToUser(record.Recipient),
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

            return new User
            {
                Id = record.Id,
                Name = record.Name,
                IsOnline = record.IsOnline
            };
        }
    }
}
