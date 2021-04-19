using Microsoft.EntityFrameworkCore;
using stock_manager.Models;

namespace stock_manager.Mapping
{
  public class MoveMap : IEntityTypeConfiguration<Move>
  {
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Move> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Description).HasMaxLength(100).IsRequired();
        builder.Property(x => x.MoveDate).IsRequired();
        builder.HasOne(x => x.Product).WithMany(x => x.Moves).HasForeignKey(x => x.ProductId).IsRequired();
        builder.ToTable("Moves");
    }
  }
}