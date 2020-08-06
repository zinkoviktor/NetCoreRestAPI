using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.Repositories.Intefaces;
using DataLayer.UnitOfWorks.Interfaces;

namespace DataLayer.UnitOfWorks
{
    public class ProductUnitOfWork : BaseUnitOfWork<ProductModel, int>, IProductUnitOfWork
    {     

        public ProductUnitOfWork(IUnitOfWorkContext dbContext, IProductRepository productRepository) :
            base(dbContext, productRepository)
        {          
        }
    }
}
