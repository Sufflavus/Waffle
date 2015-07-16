using System;


namespace Taddy.BusinessLogic.Models
{
    public sealed class Message
    {
        public DateTime CreateDate { get; set; }
        public User Recipient { get; set; }
        public Guid RecipientId { get; set; }
        public User Sender { get; set; }
        public Guid SenderId { get; set; }
        public string Text { get; set; }


        public override string ToString()
        {
            return string.Format("[{0}] {1}: {2}", CreateDate.ToString("yyyy.MM.dd"), Sender.Name, Text);
        }
    }
}
