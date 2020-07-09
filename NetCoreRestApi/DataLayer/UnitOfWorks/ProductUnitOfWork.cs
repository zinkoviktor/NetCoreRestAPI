using DataLayer.Entities;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayer.UnitOfWorks.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.UnitOfWorks
{
    public class ProductUnitOfWork : BaseUnitOfWork<ProductEntity, int>, IProductUnitOfWork
    {
        private IProductRepository _productRepository;

        public ProductUnitOfWork(IProductRepository productRepository, IDbContext dbContext) :
            base(dbContext)
        {
            _productRepository = productRepository;
        }

        public IQueryable<ProductEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ProductEntity> Create(ICollection<ProductModel> models)
        {
            throw new System.NotImplementedException();
        }        

        public IQueryable<ProductEntity> Update(ICollection<ProductModel> models)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ProductEntity> Delete(ICollection<ProductModel> models)
        {
            throw new System.NotImplementedException();
        }
    }
}
