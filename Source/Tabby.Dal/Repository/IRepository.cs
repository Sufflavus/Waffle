using System;

using Tabby.Dal.Domain;


namespace Tabby.Dal.Repository
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        void Add(T entity);
    }
}
