using DataLayer.UnitOfWorks;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Interfaces
{
    public interface IManager<TModel>
    {
        IQueryable<TModel> GetAll(FilterParameters filter = null);
        IEnumerable<TModel> Create(IEnumerable<TModel> models);
        bool Update(IEnumerable<TModel> models);
        bool Delete(IEnumerable<TModel> models);
    }
}
