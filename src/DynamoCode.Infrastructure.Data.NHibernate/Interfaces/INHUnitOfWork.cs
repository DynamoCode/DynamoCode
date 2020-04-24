using NHibernate;

namespace DynamoCode.Infrastructure.Data.NHibernate
{
    public interface INHUnitOfWork : IUnitOfWork
    {
        ISession Session { get; }
    }
}
