﻿using System;

using Tabby.Dal.Context;
using Tabby.Dal.Domain;


namespace Tabby.Dal.Repository
{
    public class UniversalRepository : IUniversalRepository
    {
        //TODO: добавить IoC
        private readonly IContext Context;


        public UniversalRepository()
        {
            Context = new NHibernateContext();
        }


        public UniversalRepository(IContext context)
        {
            Context = context;
        }


        public void AddOrUpdate<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            Context.AddOrUpdate(entity);
        }


        public TEntity GetById<TEntity>(Guid id) where TEntity : BaseEntity
        {
            return Context.GetById<TEntity>(id);
        }
    }
}
