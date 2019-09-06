using DynamoCode.Infrastructure.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DynamoCode.Infrastructure.Data
{
    public interface IReadOnlyRepository<TKey, TEntity> where TEntity : class
    {
        TEntity FindBy(TKey id);

        IList<TEntity> All();

        PagedResult<TEntity> All(int page, int itemsPerPage);

        Task<TEntity> FindByAsync(TKey id);

        Task<List<TEntity>> AllAsync();

        Task<PagedResult<TEntity>> AllAsync(int page, int itemsPerPage);
    }

    public interface IReadOnlyRepository<TEntity> : IReadOnlyRepository<int, TEntity> where TEntity : class
    {

    }
}
