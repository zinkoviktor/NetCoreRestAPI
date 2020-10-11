using DataLayer.Models;
using DataLayer.UnitOfWorks.Interfaces;

namespace BusinessLayer.Managers
{
    public class CategoryManager : BaseManager<CategoryModel, int>, ICategoryManager
    {
        public CategoryManager(ICategoryUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
