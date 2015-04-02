using System;


// TODO: попробовать Fluent NHibernate https://github.com/jagregory/fluent-nhibernate/wiki/Getting-started

namespace Bijuu.Dal.Domain
{
    public class MessageEntity : BaseEntity
    {
        public virtual DateTime? CreateDate { get; set; }
        public virtual bool IsDelivered { get; set; }
        //public virtual DateTime? DeliveryDate { get; set; }
        public virtual UserEntity Recipient { get; set; }
        public virtual Guid RecipientId { get; set; }
        public virtual UserEntity Sender { get; set; }
        public virtual Guid SenderId { get; set; }
        public virtual string Text { get; set; }
    }
}
