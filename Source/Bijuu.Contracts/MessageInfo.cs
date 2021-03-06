﻿using System;
using System.Runtime.Serialization;


namespace Bijuu.Contracts
{
    [DataContract]
    public class MessageInfo
    {
        [DataMember(IsRequired = false)]
        public DateTime? CreateDate { get; set; }

        [DataMember(IsRequired = false)]
        public Guid? Id { get; set; }

        [DataMember(IsRequired = true)]
        public bool IsDelivered { get; set; }

        [DataMember(IsRequired = false)]
        public UserInfo Recipient { get; set; }

        [DataMember(IsRequired = false)]
        public Guid? RecipientId { get; set; }

        [DataMember(IsRequired = false)]
        public UserInfo Sender { get; set; }

        [DataMember(IsRequired = true)]
        public Guid SenderId { get; set; }

        [DataMember(IsRequired = true)]
        public string Text { get; set; }
    }
}
