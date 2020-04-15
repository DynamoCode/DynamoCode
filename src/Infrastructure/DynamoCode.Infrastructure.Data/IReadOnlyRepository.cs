using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamoCode.Infrastructure.Data
{
    public interface IReadOnlyRepository<TKey, TEntity> where TEntity : class
    {
        TEntity FindBy(TKey id);

        IList<TEntity> All();

        List<TEntity> All(int page, int itemsPerPage);

        int Count();

        ValueTask<TEntity> FindByAsync(TKey id);

        Task<List<TEntity>> AllAsync();

        Task<List<TEntity>> AllAsync(int page, int itemsPerPage);

        Task<int> CountAsync();
    }

    public interface IReadOnlyRepository<TEntity> : IReadOnlyRepository<int, TEntity> where TEntity : class
    {

    }
}
