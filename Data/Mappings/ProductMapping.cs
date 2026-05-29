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
            .UseIdentityAlwaysColumn();

            builder.Property(x => x.Title)
                .HasColumnName("title")
                .HasColumnType("nvarchar")
                .HasMaxLength(160)
                .IsRequired(true);

                builder.Property(x => x.Slug)
                .HasColumnType("varchar")
                .HasMaxLength(160)
                .IsRequired(true);

                builder.Property( x => x.CategoryId)
                .HasColumnName("category_id");

                builder.HasOne(x => x.Category);

        }
    }
}