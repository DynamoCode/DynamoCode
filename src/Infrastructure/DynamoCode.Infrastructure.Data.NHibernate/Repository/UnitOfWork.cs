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

        protected bool _autoCommit = false;

        public UnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;            
        }

        public UnitOfWork(ISessionFactory sessionFactory, bool autoCommit)
        {
            _sessionFactory = sessionFactory;   
            _autoCommit =  autoCommit;       
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
            try
            {
                if (_transaction != null && _transaction.IsActive)
                {
                    _transaction.Commit();
                }
            }
            catch (Exception e)
            {
                _transaction.Rollback();
                throw e;
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
                    if (_autoCommit)
                    {
                        Commit();
                    }else
                    {
                        Rollback();
                    }
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
