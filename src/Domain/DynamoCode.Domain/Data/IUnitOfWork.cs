using System.Threading.Tasks;

namespace DynamoCode.Infrastructure.Data
{
    public interface IUnitOfWork
    {
        void Commit();

        Task<int> CommitAsync();
    }
}
