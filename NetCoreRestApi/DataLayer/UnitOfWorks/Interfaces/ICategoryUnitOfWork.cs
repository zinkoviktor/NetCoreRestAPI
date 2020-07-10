using DataLayer.Entities;
using DataLayer.Models;

namespace DataLayer.UnitOfWorks.Interfaces
{
    public interface ICategoryUnitOfWork : IUnitOfWork<CategoryModel, CategoryEntity, int>
    {
    }
}
