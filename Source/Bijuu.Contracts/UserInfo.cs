using System;
using System.Runtime.Serialization;


namespace Bijuu.Contracts
{
    [DataContract]
    public sealed class UserInfo
    {
        [DataMember(IsRequired = true)]
        public Guid Id { get; set; }

        [DataMember(IsRequired = true)]
        public bool IsOnline { get; set; }

        [DataMember(IsRequired = true)]
        public string Name { get; set; }
    }
}
