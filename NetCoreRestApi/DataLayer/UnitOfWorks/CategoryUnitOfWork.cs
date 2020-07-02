using DataLayer.Entities;
using DataLayer.Repositories;
using DataLayer.UnitOfWorks.Interfaces;
using System.Linq;

namespace DataLayer.UnitOfWorks
{
    public class CategoryUnitOfWork : ICategoryUnitOfWork
    {
        private ICategoryRepository _categoryRepository;

        public CategoryUnitOfWork(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public CategoryEntity GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<CategoryEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<CategoryEntity> Create(CategoryEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<CategoryEntity> Update(CategoryEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<CategoryEntity> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public int Save()
        {
            throw new System.NotImplementedException();
        }
    }
}
