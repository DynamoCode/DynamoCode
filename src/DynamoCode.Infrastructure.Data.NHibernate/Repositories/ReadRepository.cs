using System.Collections.Generic;
using System.Linq;
using DynamoCode.Domain.Data.Interfaces;
using DynamoCode.Infrastructure.Data.NHibernate.UoW;

namespace DynamoCode.Infrastructure.Data.NHibernate.Repositories
{
    public class ReadRepository<TKey, T> : IReadRepository<TKey, T> where T : class
    {
        protected readonly INHUnitOfWork _unitOfWork;

        public ReadRepository(INHUnitOfWork unitOfWork)
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

        public IList<T> All(int page, int itemsPerPage)
        {
            return _unitOfWork.Session.Query<T>().ToPage(page, itemsPerPage).ToList();
        }

        public int Count()
        {
            return _unitOfWork.Session.Query<T>().Count();
        }
    }

    public class ReadRepository<T> : ReadRepository<int, T>, IReadRepository<T> where T : class
    {
        public ReadRepository(INHUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}