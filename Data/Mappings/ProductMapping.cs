using Microsoft.EntityFrameworkCore;
using Poststore.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Poststore.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");

            builder.HasKey(x => x.Id)
            .HasName("pk_product");

            builder.Property(x => x.Id)
            .HasColumnName("id")
            .UseIdentityAlwaysColumn()
            .UseSerialColumn();

            builder.Property(x => x.Title)
                .HasColumnName("title")
                .HasColumnType("varchar")
                .HasMaxLength(160)
                .IsRequired(true);

                builder.Property(x => x.Slug)
                .HasColumnName("slug")
                .HasColumnType("varchar")
                .HasMaxLength(160)
                .IsRequired(true);

                builder.Property( x => x.CreatedAtUtc)
                .HasColumnName("created_at_utc")
                .HasDefaultValueSql("now()")
                .IsRequired(true);

                builder.Property( x => x.UpdatedAtUtc)
                .HasColumnName("updated_at_utc")
                .HasDefaultValueSql("now()")
                .IsRequired(true);

                builder.Property( x => x.IsActive)
                .HasColumnName("is_active")
                .IsRequired(true);

                builder.Property( x => x.CategoryId)
                .HasColumnName("category_id");

                builder.HasOne(x => x.Category);

                builder.HasIndex(x => x.Slug)
                .IsUnique()
                .HasDatabaseName("idx_product_slug");


        }
    }
}