using DataLayer.EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.EF
{
    public class EfDbContextMock<TEntity> : IRepositoryDbContext<TEntity>
        where TEntity : BaseEntity<int>
    {      

        public DbSet<TEntity> GetDbSet()
        {
            return new DbSetMock<TEntity>();
        }

        public int Save()
        {
            return 0;
        }
    }
}
