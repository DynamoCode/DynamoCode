using System.Threading.Tasks;
using System;

namespace DynamoCode.Infrastructure.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        Task CommitAsync();
    }
}
