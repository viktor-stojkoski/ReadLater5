namespace Storage
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Storage.Infrastructure.Context;

    public class ReadLaterDbContext : IdentityDbContext, IReadLaterDbContext

    {
        public ReadLaterDbContext(DbContextOptions<ReadLaterDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Storage.Category.Entities.Category>()
                .ToTable("Category");
            modelBuilder.Entity<Storage.Bookmark.Entities.Bookmark>()
                .ToTable("Bookmark");
        }
    }
}
