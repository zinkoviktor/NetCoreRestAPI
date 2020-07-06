using System.Collections.Generic;
using System.Linq;

namespace DataLayer.UnitOfWorks
{
    public interface IUnitOfWork<TEntity, TId>
    {
        TEntity GetById(TId id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Create(ICollection<TEntity> entities);
        IQueryable<TEntity> Update(ICollection<TEntity> entities);
        IQueryable<TEntity> Delete(ICollection<TEntity> entities);
        int Save();
    }
}
