using System.Collections.Generic;
using System.Linq;

namespace DataLayer.UnitOfWorks
{
    public interface IUnitOfWork<TModel, TId>
    {
        TModel GetById(TId id);
        IQueryable<TModel> GetAll();
        IQueryable<TModel> Create(IEnumerable<TModel> models);
        IQueryable<TModel> Update(IEnumerable<TModel> models);
        IQueryable<TModel> Delete(IEnumerable<TModel> models);
        int Save();
    }
}
