using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Poststore.Models;

namespace Poststore.Data.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categories");

            builder.HasKey(x => x.Id)
            .HasName("pk_category");

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn()
                .UseSerialColumn();

            builder.Property(x => x.Title)
            .HasColumnName("title")
                .HasColumnType("varchar")
                .HasMaxLength(160)
                .IsRequired(true);

            builder.HasMany( x=> x.Products);
        }
    }
}