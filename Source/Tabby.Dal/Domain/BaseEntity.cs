using System;


namespace Tabby.Dal.Domain
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
    }
}
