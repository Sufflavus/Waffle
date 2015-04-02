﻿using System;
using System.Collections.Generic;
using System.Linq;

using Bijuu.Dal.Domain;

using NHibernate;
using NHibernate.Linq;


namespace Bijuu.Dal.Context
{
    public class NHibernateContext : IContext
    {
        public void AddOrUpdate<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            using (ISession session = FluentNHibertnateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(entity);
                    transaction.Commit();
                }
            }
        }


        public List<TEntity> Filter<TEntity>(Func<TEntity, bool> condition) where TEntity : BaseEntity
        {
            using (ISession session = FluentNHibertnateSession.OpenSession())
            {
                return session.Query<TEntity>()
                    .Where(condition)
                    .ToList();
            }
        }


        public List<TEntity> GetAll<TEntity>() where TEntity : BaseEntity
        {
            using (ISession session = FluentNHibertnateSession.OpenSession())
            {
                return session.Query<TEntity>().ToList();
            }
        }


        public TEntity GetById<TEntity>(Guid id) where TEntity : BaseEntity
        {
            using (ISession session = FluentNHibertnateSession.OpenSession())
            {
                return session.Get<TEntity>(id);
            }
        }
    }
}
