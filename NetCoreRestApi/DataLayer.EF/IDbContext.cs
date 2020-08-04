using DataLayer.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.EF
{
    public interface IDbContext : IUnitOfWorkDbContext          
    {
        DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class;
    }
}
