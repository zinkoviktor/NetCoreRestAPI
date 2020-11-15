using System.Collections.Generic;
using System.Linq;

namespace DataLayer.UnitOfWorks
{
    public interface IUnitOfWork<TModel, TId>
    {
        TModel GetById(TId id);
        IQueryable<TModel> GetAll(int pageIndex, int pageSize);
        IEnumerable<TModel> Create(IEnumerable<TModel> models);
        void Update(IEnumerable<TModel> models);
        void Delete(IEnumerable<TModel> models);
        int Save();
    }
}
