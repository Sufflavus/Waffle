using System;
using System.Collections.Generic;


// TODO: попробовать Fluent NHibernate https://github.com/jagregory/fluent-nhibernate/wiki/Getting-started

namespace Tabby.Dal.Domain
{
    public class MessageEntity : BaseEntity
    {
        public MessageEntity()
        {
            Recipients = new List<UserEntity>();
        }


        public virtual DateTime? CreateDate { get; set; }
        public virtual IList<UserEntity> Recipients { get; set; }
        public virtual string Text { get; set; }
        public virtual UserEntity User { get; set; } // Sender
        public virtual Guid UserId { get; set; }
    }
}
