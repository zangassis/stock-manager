using Microsoft.EntityFrameworkCore;
using stock_manager.Models;

namespace stock_manager.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId).IsRequired();
            builder.HasMany(x => x.Moves).WithOne(x => x.Product);
            builder.ToTable("Products");
        }
    }
}