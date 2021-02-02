using DataLayer.interfaces;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.UnitOfWorks.Interfaces;

namespace DataLayer.UnitOfWorks
{
    public class ProductUnitOfWork : BaseUnitOfWork<ProductModel, int>, IProductUnitOfWork
    {

        public ProductUnitOfWork(ITransactionManager transactionManager, IProductRepository productRepository) :
            base(transactionManager, productRepository)
        {
        }
    }
}
