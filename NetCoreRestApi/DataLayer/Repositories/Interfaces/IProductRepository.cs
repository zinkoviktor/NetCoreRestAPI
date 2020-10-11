using DataLayer.Models;

namespace DataLayer.Repositories
{
    public interface IProductRepository
        : IRepository<ProductModel, int>
    {
    }
}
