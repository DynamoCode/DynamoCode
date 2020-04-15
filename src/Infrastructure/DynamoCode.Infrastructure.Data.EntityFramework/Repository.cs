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
            _unitOfWork.Context.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(TKey id)
        {
            T entity = FindBy(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public void Delete(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
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
