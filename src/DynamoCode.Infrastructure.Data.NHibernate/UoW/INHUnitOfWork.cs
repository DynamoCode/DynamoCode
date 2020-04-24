using DynamoCode.Infrastructure.Interfaces;
using NHibernate;

namespace DynamoCode.Infrastructure.Data.NHibernate.UoW {
    public interface INHUnitOfWork : IUnitOfWork {
        ISession Session { get; }
    }
}