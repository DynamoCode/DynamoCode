using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamoCode.Infrastructure.Data.EntityFramework
{
    public class ReadOnlyRepository<TKey, T> :  IReadOnlyRepository<TKey, T> where T : class
    {
        protected readonly IEFUnitOfWork _unitOfWork;

        protected readonly DbSet<T> _dbSet;

        public ReadOnlyRepository(IEFUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = _unitOfWork.Context.Set<T>();
        }

        public virtual T FindBy(TKey id)
        {
            return _dbSet.Find(id);
        }

        public IList<T> All()
        {
            return _dbSet.ToList();
        }

        public List<T> All(int page, int itemsPerPage)
        { 
            return _dbSet.ToPage(page, itemsPerPage).ToList();
        }

        public int Count()
        {
            return _dbSet.Count();
        }

        public ValueTask<T> FindByAsync(TKey id)
        {
            return _dbSet.FindAsync(id);
        }

        public Task<List<T>> AllAsync()
        {
            return _dbSet.ToListAsync();
        }

        public Task<List<T>> AllAsync(int page, int itemsPerPage)
        {
            return _dbSet.ToPage(page, itemsPerPage).ToListAsync();
        }

        public Task<int> CountAsync()
        {
            return _dbSet.CountAsync();
        }
    }

    public class ReadOnlyRepository<T> : ReadOnlyRepository<int, T>, IReadOnlyRepository<T> where T : class
    {
        public ReadOnlyRepository(IEFUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
