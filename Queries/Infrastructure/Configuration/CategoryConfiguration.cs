namespace Queries.Infrastructure.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Queries.Entities;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Uid).HasColumnName("Uid").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName("DeletedOn").HasColumnType("datetime2");

            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(x => x.UserId).HasColumnName("UserId").HasColumnType("nvarchar").IsRequired();

            builder.HasOne(x => x.User).WithMany(x => x.Categories).HasForeignKey(x => x.UserId);
        }
    }
}
