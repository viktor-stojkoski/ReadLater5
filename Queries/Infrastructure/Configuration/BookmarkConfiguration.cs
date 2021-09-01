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

            builder.Property(x => x.URL).HasColumnName("URL").HasColumnType("nvarchar").HasMaxLength(500);
            builder.Property(x => x.ShortDescription).HasColumnName("ShortDescription").HasColumnType("nvarchar(max)");
            builder.Property(x => x.CategoryId).HasColumnName("CategoryId").HasColumnType("int");

            builder.HasOne(x => x.Category).WithMany(x => x.Bookmarks).HasForeignKey(x => x.CategoryId);
        }
    }
}
