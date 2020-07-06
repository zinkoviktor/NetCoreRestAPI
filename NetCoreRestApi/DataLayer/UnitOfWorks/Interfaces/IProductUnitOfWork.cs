using DataLayer.Entities;

namespace DataLayer.UnitOfWorks.Interfaces
{
    public interface IProductUnitOfWork<TId> : IUnitOfWork<ProductEntity<TId>, TId>
    {
    }
}
