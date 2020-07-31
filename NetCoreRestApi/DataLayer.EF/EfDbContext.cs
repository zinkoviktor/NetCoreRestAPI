using DataLayer.EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.EF
{
    public class EfDbContext : DbContext, IRepositoryDbContext       
    {
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        {
        }

        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<ProductEntity>()
                    .Property(p => p.Id)                                        
                    .IsRequired();

            modelBuilder.Entity<CategoryEntity>()               
                    .Property(c => c.Id)
                    .IsRequired();
        }

        public int Save()
        {
            return SaveChanges();
        }
    }
}
