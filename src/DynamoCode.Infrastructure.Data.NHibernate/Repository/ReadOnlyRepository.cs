using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate.Linq;

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

        public IList<T> All(int page, int itemsPerPage)
        {
            return _unitOfWork.Session.Query<T>().ToPage(page, itemsPerPage).ToList();
        }

        public int Count()
        {
            return _unitOfWork.Session.Query<T>().Count();
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
