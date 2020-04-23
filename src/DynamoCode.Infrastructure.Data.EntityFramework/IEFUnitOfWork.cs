using Microsoft.EntityFrameworkCore;

namespace DynamoCode.Infrastructure.Data.EntityFramework
{
    public interface IEFUnitOfWork : IUnitOfWork
    {
        DbContext Context { get; }
    }
}
