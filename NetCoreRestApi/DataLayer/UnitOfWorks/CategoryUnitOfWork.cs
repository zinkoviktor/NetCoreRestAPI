using DataLayer.Entities;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.UnitOfWorks.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.UnitOfWorks
{
    public class CategoryUnitOfWork : BaseUnitOfWork<CategoryEntity, int>, ICategoryUnitOfWork
    {
        private ICategoryRepository _categoryRepository;

        public CategoryUnitOfWork(ICategoryRepository categoryRepository, IDbContext dbContext) :
            base(dbContext)
        {
            _categoryRepository = categoryRepository;
        }

        public IQueryable<CategoryEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<CategoryEntity> Create(ICollection<CategoryModel> models)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<CategoryEntity> Update(ICollection<CategoryModel> models)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<CategoryEntity> Delete(ICollection<CategoryModel> models)
        {
            throw new System.NotImplementedException();
        }
    }
}
