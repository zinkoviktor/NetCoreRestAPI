using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataLayerEF
{
    public interface IDbContext<TEntity> where TEntity: class
    {
        DbSet<TEntity> GetDbSet();
        ICollection<TEntity> Save();
    }
}
