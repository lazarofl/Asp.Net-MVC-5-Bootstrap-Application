using asp_net_mvc_bootstrap.Infrastructure.Repository;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace asp_net_mvc_bootstrap.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ITransaction _transaction;
        private Dictionary<Type, object> _repositories;

        public ISession Session { get; private set; }

        public UnitOfWork(ISession _session)
        {
            Session = _session;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(Session);
        }

        public ITransaction BeginTransaction()
        {
            if (_transaction != null)
            {
                throw new InvalidOperationException("Cannot have more than one transaction per session.");
            }
            _transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted);
            return _transaction;
        }

        public void Commit()
        {
            if (!_transaction.IsActive)
            {
                throw new InvalidOperationException("Cannot commit to inactive transaction.");
            }
            _transaction.Commit();
        }

        public void Rollback()
        {
            if (_transaction.IsActive)
            {
                _transaction.Rollback();
            }
        }

        public void Dispose()
        {
            if (Session != null)
            {
                Session.Dispose();
            }
            if (_transaction != null)
            {
                _transaction.Dispose();
            }
        }

    }
}