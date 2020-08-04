using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.Repositories.Intefaces;
using DataLayer.UnitOfWorks.Interfaces;

namespace DataLayer.UnitOfWorks
{
    public class CategoryUnitOfWork : BaseUnitOfWork<CategoryModel, int>, ICategoryUnitOfWork
    {
        public CategoryUnitOfWork(IUnitOfWorkDbContext dbContext, ICategoryRepository categoryRepository) :
            base(dbContext, categoryRepository)
        {          
        }
    }
}
