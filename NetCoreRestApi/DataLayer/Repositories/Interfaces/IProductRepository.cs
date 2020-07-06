using DataLayer.Models;

namespace DataLayer.Repositories
{
    public interface IProductRepository<TId> : IRepository<ProductModel<TId>, TId>
    {
    }
}
