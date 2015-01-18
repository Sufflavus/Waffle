using Tabby.Dal.Domain;


namespace Tabby.Dal.Context
{
    public interface IContext
    {
        void Add(BaseEntity entity);
    }
}