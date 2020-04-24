using System.Collections.Generic;
using System.Linq;
using DynamoCode.Domain.Data.Interfaces;
using DynamoCode.Infrastructure.Data.EntityFramework.UoW;
using Microsoft.EntityFrameworkCore;

namespace DynamoCode.Infrastructure.Data.EntityFramework.Repositories {
    public class ReadRepository<TKey, T> : IReadRepository<TKey, T> where T : class {
        protected readonly IEFUnitOfWork _unitOfWork;

        protected readonly DbSet<T> _dbSet;

        public ReadRepository (IEFUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
            _dbSet = _unitOfWork.Context.Set<T> ();
        }

        public virtual T FindBy (TKey id) {
            return _dbSet.Find (id);
        }

        public IList<T> All () {
            return _dbSet.ToList ();
        }

        public IList<T> All (int page, int itemsPerPage) {
            return _dbSet.ToPage (page, itemsPerPage).ToList ();
        }

        public int Count () {
            return _dbSet.Count ();
        }
    }

    public class ReadRepository<T> : ReadRepository<int, T>, IReadRepository<T> where T : class {
        public ReadRepository (IEFUnitOfWork unitOfWork) : base (unitOfWork) { }
    }
}