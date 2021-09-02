namespace Queries.Infrastructure.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Queries.Entities;

    public class BookmarkConfiguration : IEntityTypeConfiguration<Bookmark>
    {
        public void Configure(EntityTypeBuilder<Bookmark> builder)
        {
            builder.ToTable("Bookmark", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Uid).HasColumnName("Uid").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName("DeletedOn").HasColumnType("datetime2");

            builder.Property(x => x.Url).HasColumnName("Url").HasColumnType("nvarchar").HasMaxLength(500);
            builder.Property(x => x.ShortDescription).HasColumnName("ShortDescription").HasColumnType("nvarchar(max)");
            builder.Property(x => x.CategoryId).HasColumnName("CategoryId").HasColumnType("int");
            builder.Property(x => x.UserId).HasColumnName("UserId").HasColumnType("nvarchar").IsRequired();

            builder.HasOne(x => x.Category).WithMany(x => x.Bookmarks).HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.User).WithMany(x => x.Bookmarks).HasForeignKey(x => x.UserId);
        }
    }
}
