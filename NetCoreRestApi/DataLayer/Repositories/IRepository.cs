using DataLayer.Models;
using System.Linq;

namespace DataLayer.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
