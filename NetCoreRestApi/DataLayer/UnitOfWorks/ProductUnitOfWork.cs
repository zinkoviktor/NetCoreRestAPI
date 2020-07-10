using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.UnitOfWorks.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.UnitOfWorks
{
    public class ProductUnitOfWork : BaseUnitOfWork<ProductModel, int>, IProductUnitOfWork
    {
        private IProductRepository _productRepository;

        public ProductUnitOfWork(IProductRepository productRepository, IDbContext dbContext) :
            base(dbContext)
        {
            _productRepository = productRepository;
        }

        public IQueryable<ProductModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ProductModel> Create(ICollection<ProductModel> models)
        {
            throw new System.NotImplementedException();
        }        

        public IQueryable<ProductModel> Update(ICollection<ProductModel> models)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ProductModel> Delete(ICollection<ProductModel> models)
        {
            throw new System.NotImplementedException();
        }
    }
}
