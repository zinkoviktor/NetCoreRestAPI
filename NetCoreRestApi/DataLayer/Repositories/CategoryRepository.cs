using DataLayer.Entities;
using System;
using System.Linq;

namespace DataLayer.Repositories
{
    public class CategoryRepository : IRepository<CategoryEntity>
    {
        public void Create(CategoryEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CategoryEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public CategoryEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CategoryEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
