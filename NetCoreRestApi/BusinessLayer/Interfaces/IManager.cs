using DataLayer.UnitOfWorks;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Interfaces
{
    public interface IManager<TModel>
    {
        IQueryable<TModel> GetAll(FilterParameters filter);
        IEnumerable<TModel> Create(IEnumerable<TModel> models);
        void Update(IEnumerable<TModel> models);
        void Delete(IEnumerable<TModel> models);
        int Save();
    }
}
