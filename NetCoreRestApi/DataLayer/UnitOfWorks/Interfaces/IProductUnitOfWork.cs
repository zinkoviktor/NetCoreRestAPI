using DataLayer.Entities;
using DataLayer.Models;

namespace DataLayer.UnitOfWorks.Interfaces
{
    public interface IProductUnitOfWork : IUnitOfWork<ProductModel, ProductEntity, int>
    {
    }
}
