﻿using System;
using System.Collections.Generic;

using Bijuu.Dal.Domain;


namespace Bijuu.Dal.Repository.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        void AddOrUpdate(TEntity entity);
        List<TEntity> Filter(Func<TEntity, bool> condition);
        List<TEntity> GetAll();
        TEntity GetById(Guid id);
    }
}
