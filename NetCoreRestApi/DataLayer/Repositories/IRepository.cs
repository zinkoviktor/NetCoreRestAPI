using DataLayer.Models;
using System.Linq;

namespace DataLayer.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        T GetById(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Create(T entity);
        IQueryable<T> Update(T entity);
        IQueryable<T> Delete(int id);
    }
}
