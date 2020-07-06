using DataLayer.Entities;

namespace DataLayer.UnitOfWorks.Interfaces
{
    public interface ICategoryUnitOfWork<TId> : IUnitOfWork<CategoryEntity<TId>, TId>
    {
    }
}
