using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamoCode.Infrastructure.Data
{
    public interface IAsyncRepository<TKey, TEntity> : IReadAsyncRepository<TKey, TEntity> where TEntity : class
    {
        Task Add(TEntity item);

        Task Add(IEnumerable<TEntity> items);

        Task Update(TEntity item);

        Task Delete(TEntity item);

        Task Delete(TKey id);

        Task Delete(IEnumerable<TEntity> items);
    }

    public interface IAsyncRepository<TEntity> : IAsyncRepository<int, TEntity>, IReadAsyncRepository<TEntity> where TEntity : class
    {
    }
}
