namespace Storage.Infrastructure.Context
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Storage.Bookmark.Entities;
    using Storage.Category.Entities;

    public class ReadLaterDbContext : IdentityDbContext, IReadLaterDbContext

    {
        public ReadLaterDbContext(DbContextOptions<ReadLaterDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Bookmark>().ToTable("Bookmark");
        }
    }
}
