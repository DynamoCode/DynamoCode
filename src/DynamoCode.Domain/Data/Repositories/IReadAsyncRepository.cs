using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamoCode.Infrastructure.Data
{
    public interface IReadAsyncRepository<TKey, TEntity> where TEntity : class
    {
        Task<TEntity> FindByAsync(TKey id);

        Task<List<TEntity>> AllAsync();

        Task<List<TEntity>> AllAsync(int page, int itemsPerPage);

        Task<int> CountAsync();
    }

    public interface IReadAsyncRepository<TEntity> : IReadAsyncRepository<int, TEntity> where TEntity : class
    {

    }
}
