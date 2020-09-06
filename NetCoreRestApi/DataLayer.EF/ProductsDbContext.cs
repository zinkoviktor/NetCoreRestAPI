using DataLayer.EF.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataLayer.EF
{
    public class ProductsDbContext : DbContext, IDbContext       
    {
        public ProductsDbContext(DbContextOptions options) : base(options)
        {            
        }

        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public int Save()
        {
            return SaveChanges();
        }
    }
}
