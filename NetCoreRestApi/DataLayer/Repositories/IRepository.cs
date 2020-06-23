using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        T GetById(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Create(ICollection<T> entities);
        void Update(ICollection<T> entities);
        void Delete(ICollection<T> entities);
    }
}
