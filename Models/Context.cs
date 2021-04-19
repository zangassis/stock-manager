using Microsoft.EntityFrameworkCore;
using stock_manager.Mapping;

namespace stock_manager.Models
{
    public class Context : DbContext
    {
      public DbSet<Product> Products { get; set; }

      public DbSet<Move> Moves { get; set; }

      public DbSet<Category> Categories { get; set; }

      public Context(DbContextOptions<Context> options) : base(options)
      {

      }

      protected override void OnModelCreating(ModelBuilder builder)
      {
          base.OnModelCreating(builder);
          builder.ApplyConfiguration(new ProductMap());
          builder.ApplyConfiguration(new MoveMap());
          builder.ApplyConfiguration(new CategoryMap());
      }
    }
}