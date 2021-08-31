namespace Storage.Common.Repositories
{
    using System.Linq;

    using Microsoft.EntityFrameworkCore;

    using Storage.Common.Entities;
    using Storage.Infrastructure.Context;

    public class Repository<TEntity> where TEntity : Entity
    {
        protected readonly IReadLaterDbContext _readLaterDbContext;

        public Repository(IReadLaterDbContext readLaterDbContext)
        {
            _readLaterDbContext = readLaterDbContext;
        }

        /// <summary>
        /// Returns query that returns entities as no tracked and not deleted.
        /// </summary>
        protected IQueryable<TEntity> AllNoTrackedOf()
        {
            return _readLaterDbContext.Set<TEntity>().Where(x => x.DeletedOn == null).AsNoTracking();
        }

        /// <summary>
        /// Returns query that returns entities which are not deleted.
        /// </summary>
        protected IQueryable<TEntity> AllOf()
        {
            return _readLaterDbContext.Set<TEntity>().Where(x => x.DeletedOn == null);
        }

        /// <summary>
        /// Inserts new entity into storage.
        /// </summary>
        protected void Insert(TEntity entity)
        {
            _readLaterDbContext.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Updates entity.
        /// </summary>
        protected void Update(TEntity entity)
        {
            _readLaterDbContext.Set<TEntity>().Attach(entity);

            _readLaterDbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
