using DataLayer.Models;
using DataLayer.UnitOfWorks;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repositories
{
    public interface IRepository<TModel, TId>
        where TModel : BaseModel<TId>
    {
        TModel GetById(TId id);
        IQueryable<TModel> GetAll(FilterParameters filter);
        IEnumerable<TModel> Create(IEnumerable<TModel> models);
        void Update(IEnumerable<TModel> models);
        void Delete(IEnumerable<TModel> models);
    }
}
