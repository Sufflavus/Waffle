using System;
using System.Collections.Generic;

using Bijuu.Dal.Context;
using Bijuu.Dal.Domain;
using Bijuu.Dal.Repository.Interfaces;

using Microsoft.Practices.Unity;


namespace Bijuu.Dal.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        [Dependency]
        public IContext Context { get; set; }


        public void AddOrUpdate(TEntity entity)
        {
            Context.AddOrUpdate(entity);
        }


        public List<TEntity> Filter(Func<TEntity, bool> condition)
        {
            return Context.Filter(condition);
        }


        public List<TEntity> GetAll()
        {
            return Context.GetAll<TEntity>();
        }


        public TEntity GetById(Guid id)
        {
            return Context.GetById<TEntity>(id);
        }
    }
}
