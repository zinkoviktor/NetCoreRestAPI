using DataLayer.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.EF
{
    public interface IDbContext : IUnitOfWorkContext          
    {
        DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class;
    }
}
