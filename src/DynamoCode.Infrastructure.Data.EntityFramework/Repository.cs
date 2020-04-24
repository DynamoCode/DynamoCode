using System.Collections.Generic;

namespace DynamoCode.Infrastructure.Data.EntityFramework
{
    public class Repository<TKey, T> : ReadOnlyRepository<TKey, T> , IRepository<TKey, T> where T : class
    {
        public Repository(IEFUnitOfWork unitOfWork)
        :base(unitOfWork)
        {
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Add(IEnumerable<T> items)
        {
            _dbSet.AddRange(items);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T item)
        {
            _dbSet.Remove(item);
        }

        public void Delete(TKey id)
        {
            T item = FindBy(id);
            if (item != null)
            {
                _dbSet.Remove(item);
            }
        }

        public void Delete(IEnumerable<T> items)
        {
            _dbSet.RemoveRange(items);
        }
    }

    public class Repository<T> : Repository<int, T>, IRepository<T> where T : class
    {
        public Repository(IEFUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
