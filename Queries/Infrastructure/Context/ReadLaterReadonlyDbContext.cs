namespace Queries.Infrastructure.Context
{
    using System.Linq;

    using Microsoft.EntityFrameworkCore;

    using Queries.Common.Entities;
    using Queries.Infrastructure.Configuration;

    public class ReadLaterReadonlyDbContext : DbContext, IReadLaterReadonlyDbContext
    {
        public ReadLaterReadonlyDbContext(DbContextOptions<ReadLaterReadonlyDbContext> options)
            : base(options) { }

        public IQueryable<TEntity> AllNoTrackedOf<TEntity>() where TEntity : Entity
        {
            return Set<TEntity>().AsNoTracking().Where(x => x.DeletedOn == null);
        }

        public IQueryable<TEntity> SetOf<TEntity>() where TEntity : Entity
        {
            return Set<TEntity>().AsNoTracking();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }
    }
}
