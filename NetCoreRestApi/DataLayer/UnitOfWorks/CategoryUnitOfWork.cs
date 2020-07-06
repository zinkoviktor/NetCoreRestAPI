using DataLayer.Entities;
using DataLayer.Repositories;
using DataLayer.UnitOfWorks.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.UnitOfWorks
{
    public class CategoryUnitOfWork<TId> : ICategoryUnitOfWork<TId>
    {
        private ICategoryRepository<TId> _categoryRepository;

        public CategoryUnitOfWork(ICategoryRepository<TId> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public CategoryEntity<TId> GetById(TId id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<CategoryEntity<TId>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<CategoryEntity<TId>> Create(ICollection<CategoryEntity<TId>> entities)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<CategoryEntity<TId>> Update(ICollection<CategoryEntity<TId>> entities)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<CategoryEntity<TId>> Delete(ICollection<CategoryEntity<TId>> entities)
        {
            throw new System.NotImplementedException();
        }

        public int Save()
        {
            throw new System.NotImplementedException();
        }
    }
}
