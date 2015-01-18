using System;

using Tabby.Dal.Context;
using Tabby.Dal.Domain;


namespace Tabby.Dal.Repository
{
    public class Repository<T> : IRepository<T> 
        where T : BaseEntity
    {
        private readonly IContext Context = new NHibernateContext();

        public void Add(T entity)
        {
            Context.Add(entity);
        }
    }
}