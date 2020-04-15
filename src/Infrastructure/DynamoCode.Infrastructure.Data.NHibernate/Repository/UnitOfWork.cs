using System;
using System.Threading.Tasks;
using NHibernate;

namespace DynamoCode.Infrastructure.Data.NHibernate
{
    public class UnitOfWork : INHUnitOfWork
    {
        protected ISessionFactory _sessionFactory;

        protected ISession _session;
        protected ITransaction _transaction;

        public UnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;            
        }

        public virtual ISession Session
        {
            get
            {
                if (_session == null)
                {
                    _session = _sessionFactory.OpenSession();
                }
                BeginTransaction();
                return _session;
            }
        }

        public void BeginTransaction()
        {
            if (_transaction == null)
            {
                _transaction = _session.BeginTransaction();
            }
        }

        public virtual void Commit()
        {
            if (_transaction != null && _transaction.IsActive)
            {
                try
                {
                    _transaction.Commit();
                }
                catch (Exception e)
                {
                    _transaction.Rollback();
                    throw e;
                }
                finally
                {
                    _transaction.Dispose();
                    _transaction = null;
                }
            }
        }

        public virtual void Rollback()
        {
            if (_transaction != null && _transaction.IsActive)
            {
                _transaction.Rollback();
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public virtual void Dispose()
        {
            if (_session != null)
            {
                try
                {
                    Commit();
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    _session.Close();
                    _session.Dispose();
                    _session = null;
                }
            }
        }

        public Task CommitAsync()
        {
            return _transaction.CommitAsync();
        }
    }
}
