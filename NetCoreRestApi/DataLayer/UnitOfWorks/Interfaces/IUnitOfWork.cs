using System.Collections.Generic;
using System.Linq;

namespace DataLayer.UnitOfWorks
{
    public interface IUnitOfWork<TModel, TId>
    {
        TModel GetById(TId id);
        IQueryable<TModel> GetAll();
        IQueryable<TModel> Create(ICollection<TModel> models);
        IQueryable<TModel> Update(ICollection<TModel> models);
        IQueryable<TModel> Delete(ICollection<TModel> models);
        int Save();
    }
}
