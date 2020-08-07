using DataLayer.Models;
using DataLayer.UnitOfWorks.Interfaces;

namespace BusinessLayer.Managers
{
    public class ProductManager : BaseManager<ProductModel, int>, IProductManager
    {
        public ProductManager(IProductUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}