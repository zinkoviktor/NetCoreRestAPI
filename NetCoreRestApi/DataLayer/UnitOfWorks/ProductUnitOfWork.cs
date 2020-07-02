using DataLayer.Entities;
using DataLayer.Repositories;
using DataLayer.UnitOfWorks.Interfaces;
using System.Linq;

namespace DataLayer.UnitOfWorks
{
    public class ProductUnitOfWork : IProductUnitOfWork
    {
        private IProductRepository _productRepository;

        public ProductUnitOfWork(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
       
        public IQueryable<ProductEntity> Create(ProductEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ProductEntity> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ProductEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public ProductEntity GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public int Save()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ProductEntity> Update(ProductEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
