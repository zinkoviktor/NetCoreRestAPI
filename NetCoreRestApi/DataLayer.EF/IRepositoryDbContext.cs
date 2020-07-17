using DataLayer.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.EF
{
    public interface IRepositoryDbContext<TEntity> : IDbContext  
        where TEntity: class
    {
        DbSet<TEntity> GetDbSet();
    }
}
