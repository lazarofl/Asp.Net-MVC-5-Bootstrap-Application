using NHibernate;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace asp_net_mvc_bootstrap.Infrastructure.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
    {
        private readonly ISession _session;

        public GenericRepository(ISession session)
        {
            _session = session;
        }

        #region IWriteRepository

        public bool Add(TEntity entity)
        {
            _session.Save(entity);
            return true;
        }

        public bool Add(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                _session.Save(entity);
            }
            return true;
        }

        public bool Update(TEntity entity)
        {
            _session.Update(entity);
            return true;
        }

        public bool Update(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                _session.Update(entity);
            }
            return true;
        }

        public bool Delete(TEntity entity)
        {
            _session.Delete(entity);
            return true;
        }

        public bool Delete(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                _session.Delete(entity);
            }
            return true;
        }

        #endregion

        #region IReadRepository

        public IQueryable<TEntity> All()
        {
            return _session.Query<TEntity>();
        }

        public TEntity FindBy(Expression<System.Func<TEntity, bool>> expression)
        {
            return FilterBy(expression).SingleOrDefault();
        }

        public TEntity FindBy(object id)
        {
            return _session.Get<TEntity>(id);
        }

        public IQueryable<TEntity> FilterBy(Expression<System.Func<TEntity, bool>> expression)
        {
            return All().Where(expression).AsQueryable();
        }

        #endregion

    }
}