using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repositories
{
    public interface IRepository<TModel, TId> where TModel : BaseModel<TId>
    {
        TModel GetById(TId id);
        IQueryable<TModel> GetAll();
        IQueryable<TModel> Create(ICollection<TModel> models);
        void Update(ICollection<TModel> models);
        void Delete(ICollection<TModel> models);
    }
}
