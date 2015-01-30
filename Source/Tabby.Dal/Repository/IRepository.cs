using System;
using System.Collections.Generic;

using Tabby.Dal.Domain;


namespace Tabby.Dal.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        void AddOrUpdate(TEntity entity);
        List<TEntity> Filter(Func<TEntity, bool> condition);
        List<TEntity> GetAll();
        TEntity GetById(Guid id);
    }
}
