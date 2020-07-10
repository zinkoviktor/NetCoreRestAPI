using System.Collections.Generic;
using System.Linq;

namespace DataLayer.UnitOfWorks
{
    public interface IUnitOfWork<TModel, TEntity, TId>
    {
        TEntity GetById(TId id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Create(ICollection<TModel> models);
        IQueryable<TEntity> Update(ICollection<TModel> models);
        IQueryable<TEntity> Delete(ICollection<TModel> models);
        int Save();
    }
}
