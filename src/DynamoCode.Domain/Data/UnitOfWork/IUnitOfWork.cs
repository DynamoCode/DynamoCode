using System.Threading.Tasks;
using System;

namespace DynamoCode.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        Task CommitAsync();
    }
}
