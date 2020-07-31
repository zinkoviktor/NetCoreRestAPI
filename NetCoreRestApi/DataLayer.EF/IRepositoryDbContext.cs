using DataLayer.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.EF
{
    public interface IRepositoryDbContext : IDbContext          
    {
        DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class;
    }
}
