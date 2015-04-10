using System;


namespace Ginger.Contracts
{
    public class MessageRecord
    {
        public DateTime? CreateDate { get; set; }

        public Guid? Id { get; set; }

        public bool IsDelivered { get; set; }

        public UserRecord Recipient { get; set; }

        public Guid? RecipientId { get; set; }

        public UserRecord Sender { get; set; }

        public Guid SenderId { get; set; }

        public string Text { get; set; }
    }
}
