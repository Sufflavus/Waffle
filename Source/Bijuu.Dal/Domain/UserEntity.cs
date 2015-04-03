using System;


namespace Bijuu.Dal.Domain
{
    public class UserEntity : BaseEntity
    {
        public virtual bool IsOnline { get; set; }
        public virtual string Name { get; set; }
    }
}
