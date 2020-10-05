using DataLayer.Models;

namespace DataLayer.UnitOfWorks.Interfaces
{
    public interface ICategoryUnitOfWork
        : IUnitOfWork<CategoryModel, int>
    {
    }
}
