using DataLayer.Entities;
using System.Collections.Generic;

namespace DataLayer.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        ICollection<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
