using System.Linq;

namespace DataLayer.UnitOfWorks
{
    public interface IUnitOfWork<T>
    {
        T GetById(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Create(T entity);
        IQueryable<T> Update(T entity);
        IQueryable<T> Delete(int id);
        int Save();
    }
}
