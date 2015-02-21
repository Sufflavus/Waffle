using System;
using System.Runtime.Serialization;


namespace Bijuu.Contracts
{
    [DataContract]
    public class MessageInfo
    {
        [DataMember(IsRequired = false)]
        public DateTime? CreateDate { get; set; }

        [DataMember(IsRequired = true)]
        public bool IsDelivered { get; set; }

        [DataMember(IsRequired = true)]
        public Guid RecipientId { get; set; }

        [DataMember(IsRequired = true)]
        public Guid SenderId { get; set; }

        [DataMember(IsRequired = true)]
        public string Text { get; set; }
    }
}
