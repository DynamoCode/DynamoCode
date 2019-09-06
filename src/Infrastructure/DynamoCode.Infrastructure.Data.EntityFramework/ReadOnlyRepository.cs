using DynamoCode.Infrastructure.Data.Entities;
using DynamoCode.Infrastructure.Data.EntityFramework.Specifications;
using DynamoCode.Infrastructure.Data.Specifications;
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

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);            
        }

        public virtual IList<T> All()
        {
            return _dbSet.ToList();
        }

        public virtual PagedResult<T> All(int page, int itemsPerPage)
        {
            PagedResult<T> result = new PagedResult<T>
            {
                PageOfItems = _dbSet.ToPage(page, itemsPerPage).ToList(),
                TotalItems = _dbSet.Count()
            };

            return result;
        }

        public Task<T> FindByAsync(TKey id)
        {
            return _dbSet.FindAsync(id);
        }

        public Task<List<T>> AllAsync()
        {
            return _dbSet.ToListAsync();
        }

        public async Task<PagedResult<T>> AllAsync(int page, int itemsPerPage)
        {
            PagedResult<T> result = new PagedResult<T>
            {
                PageOfItems = await _dbSet.ToPage(page, itemsPerPage).ToListAsync(),
                TotalItems = await _dbSet.CountAsync()
            };

            return result;
        }

        protected IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbSet.AsQueryable(), spec);
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
