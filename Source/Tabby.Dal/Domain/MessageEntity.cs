using System;


// TODO: попробовать Fluent NHibernate https://github.com/jagregory/fluent-nhibernate/wiki/Getting-started

namespace Tabby.Dal.Domain
{
    public class MessageEntity : BaseEntity
    {
        public virtual DateTime CreateDate { get; set; }
        public virtual string Text { get; set; }
    }
}
