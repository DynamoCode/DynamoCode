using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DynamoCode.Infrastructure.Data.NHibernate
{
    public class ReadOnlyRepository<TKey, T> : IReadOnlyRepository<TKey, T> where T : class
    {
        protected readonly INHUnitOfWork _unitOfWork;

        public ReadOnlyRepository(INHUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual T FindBy(TKey id)
        {
            return _unitOfWork.Session.Get<T>(id);
        }

        public virtual IList<T> All()
        {
            return _unitOfWork.Session.Query<T>().ToList();
        }

        ValueTask<T> IReadOnlyRepository<TKey, T>.FindByAsync(TKey id)
        {
            return new ValueTask<T>(task: _unitOfWork.Session.GetAsync<T>(id));
        }

        public Task<List<T>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public List<T> All(int page, int itemsPerPage)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> AllAsync(int page, int itemsPerPage)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }
    }

    public class ReadOnlyRepository<T> : ReadOnlyRepository<int, T>, IReadOnlyRepository<T> where T : class
    {
        public ReadOnlyRepository(INHUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
