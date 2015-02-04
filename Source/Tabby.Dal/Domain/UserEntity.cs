using System;
using System.Collections.Generic;


namespace Tabby.Dal.Domain
{
    public class UserEntity : BaseEntity
    {
        public virtual bool IsOnline { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<MessageEntity> DeliveredMessages { get; set; }
    }
}
