using System;


namespace Tabby.Dal.Domain
{
    public class UserEntity : BaseEntity
    {
        public virtual bool IsOnline { get; set; }
        public virtual string Name { get; set; }
    }
}
