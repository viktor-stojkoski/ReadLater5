namespace Queries.Infrastructure.Context
{
    using System;
    using System.Linq;

    using Queries.Common.Entities;

    public interface IReadLaterReadonlyDbContext : IDisposable
    {
        /// <summary>
        /// Returns query that returns entities as no tracked which are not deleted.
        /// </summary>
        IQueryable<TEntity> AllNoTrackedOf<TEntity>() where TEntity : Entity;

        /// <summary>
        /// Returns query that returns entities as no tracked.
        /// </summary>
        IQueryable<TEntity> SetOf<TEntity>() where TEntity : Entity;
    }
}
