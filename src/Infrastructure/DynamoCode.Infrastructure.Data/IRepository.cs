using System.Collections.Generic;

namespace DynamoCode.Infrastructure.Data
{
    public interface IRepository<TKey, TEntity> : IReadOnlyRepository<TKey, TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void Add(IEnumerable<TEntity> items);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(TKey id);

        void Delete(IEnumerable<TEntity> entities);
    }

    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void Add(IEnumerable<TEntity> items);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(int id);

        void Delete(IEnumerable<TEntity> entities);
    }
}
