using DataLayer.interfaces;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.UnitOfWorks.Interfaces;

namespace DataLayer.UnitOfWorks
{
    public class CategoryUnitOfWork : BaseUnitOfWork<CategoryModel, int>, ICategoryUnitOfWork
    {
        public CategoryUnitOfWork(ITransactionManager transactionManager, ICategoryRepository categoryRepository) :
            base(transactionManager, categoryRepository)
        {
        }
    }
}
