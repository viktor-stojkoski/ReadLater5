namespace Storage.Infrastructure.Context
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Storage.Bookmark.Entities;
    using Storage.Category.Entities;
    using Storage.User.Entities;

    public class ReadLaterDbContext : IdentityDbContext, IReadLaterDbContext
    {
        public ReadLaterDbContext(DbContextOptions<ReadLaterDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Bookmark>().ToTable("Bookmark");

            modelBuilder.Entity<ApplicationUser>().Property(x => x.Uid).HasColumnName("Uid").HasColumnType("uniqueidentifier").IsRequired();
            modelBuilder.Entity<ApplicationUser>().Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2").IsRequired();
            modelBuilder.Entity<ApplicationUser>().Property(x => x.DeletedOn).HasColumnName("DeletedOn").HasColumnType("datetime2");

            // TODO: Remove if not needed.
            //modelBuilder.Entity<Category>().HasOne(x => x.User).WithMany(x => x.Categories).HasForeignKey(x => x.UserId);
            //modelBuilder.Entity<Bookmark>().HasOne(x => x.User).WithMany(x => x.Bookmarks).HasForeignKey(x => x.UserId);
        }
    }
}
