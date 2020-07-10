using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.UnitOfWorks.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.UnitOfWorks
{
    public class CategoryUnitOfWork : BaseUnitOfWork<CategoryModel, int>, ICategoryUnitOfWork
    {
        private ICategoryRepository _categoryRepository;

        public CategoryUnitOfWork(ICategoryRepository categoryRepository, IDbContext dbContext) :
            base(dbContext)
        {
            _categoryRepository = categoryRepository;
        }

        public IQueryable<CategoryModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<CategoryModel> Create(ICollection<CategoryModel> models)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<CategoryModel> Update(ICollection<CategoryModel> models)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<CategoryModel> Delete(ICollection<CategoryModel> models)
        {
            throw new System.NotImplementedException();
        }
    }
}
