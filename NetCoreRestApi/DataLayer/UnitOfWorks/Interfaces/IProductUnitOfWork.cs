using DataLayer.Models;

namespace DataLayer.UnitOfWorks.Interfaces
{
    public interface IProductUnitOfWork 
        : IUnitOfWork<ProductModel, int>
    {
    }
}
