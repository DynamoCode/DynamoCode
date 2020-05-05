using System;
using System.Threading.Tasks;
using NHibernate;

namespace DynamoCode.Infrastructure.Data.NHibernate.UoW
{
    public class UnitOfWork : INHUnitOfWork
    {
        protected ISessionFactory _sessionFactory;

        protected ISession _session;
        protected ITransaction _transaction;

        protected bool _autoCommit = false;

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

        private void CommitTransaction()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                {
                    _transaction.Commit();
                }
            }
            catch (Exception)
            {
                _transaction.Rollback();
            }
            finally
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                    _transaction = null;
                }
            }
        }

        public virtual void Commit()
        {
            if (_session != null)
            {
                try
                {
                    CommitTransaction();
                }
                finally
                {
                    _session.Close();
                    _session.Dispose();
                    _session = null;
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
            if (_transaction != null)
            {
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
                   CommitTransaction();
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