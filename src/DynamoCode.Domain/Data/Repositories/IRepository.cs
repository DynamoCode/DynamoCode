using System.Collections.Generic;

namespace DynamoCode.Infrastructure.Data
{
    public interface IRepository<TKey, TEntity> : IReadOnlyRepository<TKey, TEntity> where TEntity : class
    {
        void Add(TEntity item);

        void Add(IEnumerable<TEntity> items);

        void Update(TEntity item);

        void Delete(TEntity item);

        void Delete(TKey id);

        void Delete(IEnumerable<TEntity> items);
    }

    public interface IRepository<TEntity> : IRepository<int, TEntity>, IReadOnlyRepository<TEntity> where TEntity : class
    {
    }
}
