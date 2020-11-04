using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repositories
{
    public interface IRepository<TModel, TId>
        where TModel : BaseModel<TId>
    {
        TModel GetById(TId id);
        IEnumerable<TModel> GetAll();
        IQueryable<TModel> Create(IEnumerable<TModel> models);
        int Update(IEnumerable<TModel> models);
        int Delete(IEnumerable<TModel> models);
    }
}
