using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repositories
{
    public class BaseRepository<TModel, TEntity, TId> : IRepository<TModel, TId>
         where TModel : BaseModel<TId>
    {
        public BaseRepository()
        {

        }

        public IQueryable<TModel> Create(ICollection<TModel> models)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(ICollection<TModel> models)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<TModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public TModel GetById(TId id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ICollection<TModel> models)
        {
            throw new System.NotImplementedException();
        }
    }
}
