﻿using System;


namespace Bijuu.Dal.Domain
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
    }
}
