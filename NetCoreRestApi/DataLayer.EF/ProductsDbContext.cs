using DataLayer.EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.EF
{
    public class ProductsDbContext : DbContext, IDbContext       
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {            
        }

        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>(ep =>
            {
                ep.HasKey(p => p.Id);
                ep.Property(p => p.Id).IsRequired();
                ep.Property(c => c.Name).HasMaxLength(50);
                ep.Property(p => p.Description).HasMaxLength(150);
                ep.HasMany(p => p.Categories).WithOne();
            });

            modelBuilder.Entity<CategoryEntity>(ec =>
            {
                ec.HasKey(c => c.Id);
                ec.Property(c => c.Id).IsRequired();
                ec.Property(c => c.Name).HasMaxLength(50);
                ec.Property(c => c.Description).HasMaxLength(150);                
            });                   
        }

        public int Save()
        {
            return SaveChanges();
        }
    }
}
