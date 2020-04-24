using System.Collections.Generic;
using DynamoCode.Domain.Data.Interfaces;
using DynamoCode.Infrastructure.Data.NHibernate.UoW;

namespace DynamoCode.Infrastructure.Data.NHibernate.Repositories {
    public class Repository<TKey, T> : ReadRepository<TKey, T>, IRepository<TKey, T> where T : class {
        public Repository (INHUnitOfWork unitOfWork) : base (unitOfWork) { }
        public virtual void Add (T entity) {
            _unitOfWork.Session.Save (entity);
        }

        public virtual void Add (IEnumerable<T> items) {
            foreach (T item in items) {
                _unitOfWork.Session.Save (item);
            }
        }
        public virtual void Update (T entity) {
            _unitOfWork.Session.Update (entity);
        }

        public void Delete (T entity) {
            _unitOfWork.Session.Delete (entity);
        }

        public virtual void Delete (TKey id) {
            _unitOfWork.Session.Delete (FindBy (id));
        }

        public void Delete (IEnumerable<T> entities) {
            foreach (T entity in entities) {
                _unitOfWork.Session.Delete (entity);
            }
        }
    }

    public class Repository<T> : Repository<int, T>, IRepository<T> where T : class {
        public Repository (INHUnitOfWork unitOfWork) : base (unitOfWork) { }
    }
}