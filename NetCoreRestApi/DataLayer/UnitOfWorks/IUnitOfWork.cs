using DataLayer.Models;
using DataLayer.Repositories;

namespace DataLayer.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IRepository<ProductModel> Products { get; }
        IRepository<CategoryModel> Categories { get; }
        int Save();
    }
}
