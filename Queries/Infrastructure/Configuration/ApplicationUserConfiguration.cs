namespace Queries.Infrastructure.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Queries.Entities;

    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("AspNetUsers", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Uid).HasColumnName("Uid").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.DeletedOn).HasColumnName("DeletedOn").HasColumnType("datetime2");

            builder.Property(x => x.UserName).HasColumnName("UserName").HasColumnType("nvarchar").HasMaxLength(256);
            builder.Property(x => x.Email).HasColumnName("Email").HasColumnType("nvarchar").HasMaxLength(256);
            builder.Property(x => x.PasswordHash).HasColumnName("PasswordHash").HasColumnType("nvarchar(max)");
            builder.Property(x => x.RefreshToken).HasColumnName("RefreshToken").HasColumnType("nvarchar(max)");
            builder.Property(x => x.RefreshTokenExpiresOn).HasColumnName("RefreshTokenExpiresOn").HasColumnType("datetime2");
        }
    }
}
